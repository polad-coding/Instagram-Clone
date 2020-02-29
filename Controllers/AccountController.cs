using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Helpers;
using Dapper;
using InstagramClone.Models;
using InstagramClone.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace InstagramClone.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;
        private List<PostViewModel> posts;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            posts = new List<PostViewModel>();
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetFollowings(string id)
        {
            List<UserViewModel> followings = new List<UserViewModel>();

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var p = new DynamicParameters();
                p.Add("@User_Id", id);

                followings = connection.Query<UserViewModel>("dbo.GetAllFollowingUsers", p, commandType: CommandType.StoredProcedure).ToList();

                for (int i = 0; i < followings.Count; i++)
                {
                    p = new DynamicParameters();
                    p.Add("@Curr_User_Id", User.FindFirstValue(ClaimTypes.NameIdentifier));
                    p.Add("@User_Id", followings[i].Id);
                    p.Add("@Responce", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                    connection.Execute("dbo.IsUserFollowing", p, commandType: CommandType.StoredProcedure);

                    bool isFollowing = Convert.ToBoolean(p.Get<int>("@Responce"));

                    followings[i].Current_User_Following = isFollowing;
                }

            }

            ViewBag.CurrUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return PartialView(followings);
        }


        [HttpGet]
        public IActionResult GetFollowers(string id)
        {
            List<UserViewModel> followers = new List<UserViewModel>();

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var p = new DynamicParameters();
                p.Add("@User_Id", id);

                followers = connection.Query<UserViewModel>("dbo.GetAllFollowerUsers", p, commandType: CommandType.StoredProcedure).ToList();

                for (int i = 0; i < followers.Count; i++)
                {
                    p = new DynamicParameters();
                    p.Add("@Curr_User_Id", User.FindFirstValue(ClaimTypes.NameIdentifier));
                    p.Add("@User_Id", followers[i].Id);
                    p.Add("@Responce", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                    connection.Execute("dbo.IsUserFollowing", p, commandType: CommandType.StoredProcedure);

                    bool isFollowing = Convert.ToBoolean(p.Get<int>("@Responce"));

                    followers[i].Current_User_Following = isFollowing;
                }

            }

            ViewBag.CurrUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);


            return PartialView(followers);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(LogInViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result =
                    await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("UserAccount", "Account");
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect login or password");
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult AddPost()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPost(string caption, IFormFile img)
        {

            if (img != null)
            {
                byte[] imageData = null;

                using (var binaryReader = new BinaryReader(img.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)img.Length);
                }

                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {

                    var p = new DynamicParameters();
                    p.Add("@User_Id", User.FindFirstValue(ClaimTypes.NameIdentifier));
                    p.Add("@User_Caption", caption);
                    p.Add("@Picture", imageData);
                    p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                    connection.Execute("dbo.AddPost", p, commandType: CommandType.StoredProcedure);

                    int id = p.Get<int>("@Id");

                    posts.Add(new PostViewModel() { Id = id, IUser_Id = User.FindFirstValue(ClaimTypes.NameIdentifier), Picture = imageData, Creator_Caption = caption });
                }

            }

            return RedirectToAction("UserAccount", "Account", new { id = "null" });
        }

        [HttpGet]
        public IActionResult ChangeProfile()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChangeProfile(ChangeProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    byte[] imageData = null;
                    if (model.ProfilePicture != null)
                    {
                        using (var binaryReader = new BinaryReader(model.ProfilePicture.OpenReadStream()))
                        {
                            imageData = binaryReader.ReadBytes((int)model.ProfilePicture.Length);
                        }
                    }


                    var p = new DynamicParameters();
                    p.Add("@Id", User.FindFirstValue(ClaimTypes.NameIdentifier));
                    p.Add("@UserName", model.UserName);
                    p.Add("@FullName", model.FullName);
                    char? toPass = model.Gender == null ? (char?)null : (model.Gender == "Men" ? 'm' : 'f');
                    p.Add("@Gender", toPass);
                    p.Add("@Email", model.Email);
                    p.Add("@Bio", model.Bio);
                    p.Add("@WebSiteLink", model.WebSiteLink);
                    p.Add("@ProfilePicture", imageData, DbType.Binary);

                    connection.Execute("dbo.UpdateUserProfile", p, commandType: CommandType.StoredProcedure);

                }
            }
            return View();
        }

        [AcceptVerbs("GET", "POST")]
        public JsonResult IsEmailExists(string Email)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var p = new DynamicParameters();
                p.Add("@Email", Email);

                int result = connection.QueryFirst<int>("dbo.IsMailUnique", p, commandType: CommandType.StoredProcedure);

                if (Convert.ToBoolean(result))
                {
                    return Json("This email is already in use!");
                }
            }


            return Json(true);
        }

        public JsonResult IsUserNameExists(string UserName)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var p = new DynamicParameters();
                p.Add("@UserName", UserName);

                int result = connection.QueryFirst<int>("dbo.IsUserNameUnique", p, commandType: CommandType.StoredProcedure);

                if (Convert.ToBoolean(result))
                {
                    return Json("This user name is already in use!");
                }
            }

            return Json(true);
        }

        public PartialViewResult FollowUser(string id)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var p = new DynamicParameters();
                p.Add("@Follower_Id", User.FindFirstValue(ClaimTypes.NameIdentifier));
                p.Add("@Following_Id", id);

                connection.Execute("dbo.FollowUser", p, commandType: CommandType.StoredProcedure);
            }


            return PartialView();
        }

        public PartialViewResult UnfollowUser(string id)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var p = new DynamicParameters();
                p.Add("@Follower_Id", User.FindFirstValue(ClaimTypes.NameIdentifier));
                p.Add("@Following_Id", id);

                connection.Execute("dbo.UnfollowUser", p, commandType: CommandType.StoredProcedure);
            }

            return PartialView();

        }


        public IActionResult GetAllFollowingUsers(string id)
        {
            IEnumerable<UserViewModel> followingUsers;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var p = new DynamicParameters();

                p.Add("@User_Id", id);

                followingUsers = connection.Query<UserViewModel>("dbo.GetAllFollowingUsers", p, commandType: CommandType.StoredProcedure);

            }

            return View(followingUsers);
        }

        public IActionResult GetAllFollowerUsers(string id)
        {
            IEnumerable<UserViewModel> followerUsers;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var p = new DynamicParameters();

                p.Add("@User_Id", id);

                followerUsers = connection.Query<UserViewModel>("dbo.GetAllFollowerUsers", p, commandType: CommandType.StoredProcedure);

            }

            return View(followerUsers);
        }

        public IActionResult UserAccount(string Id)
        {

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("SignIn", "Account");
            }

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var p = new DynamicParameters();
                UserViewModel currUser;

                if (Id == "null" || Id == null)
                {
                    p.Add("@Id", User.FindFirstValue(ClaimTypes.NameIdentifier));
                    currUser = connection.QueryFirstOrDefault<UserViewModel>("dbo.IsUserExists", p, commandType: CommandType.StoredProcedure);
                }
                else
                {
                    p.Add("@Id", Id);
                    currUser = connection.QueryFirstOrDefault<UserViewModel>("dbo.IsUserExists", p, commandType: CommandType.StoredProcedure);
                }

                if (currUser == null)
                {
                    return RedirectToAction("Error", "Home");
                }

                p = new DynamicParameters();

                p.Add("@Id", currUser.Id);
                posts = connection.Query<PostViewModel>("dbo.GetPostsByUserId", p, commandType: CommandType.StoredProcedure).ToList();

                p = new DynamicParameters();
                p.Add("@Follower_Id", User.FindFirstValue(ClaimTypes.NameIdentifier));
                p.Add("@Following_Id", Id);

                int following = connection.QueryFirst<int>("dbo.CheckIfUserFollowing", p, commandType: CommandType.StoredProcedure);

                p = new DynamicParameters();
                if (Id == null || Id == "null")
                {
                    p.Add("@User_id", User.FindFirstValue(ClaimTypes.NameIdentifier));
                }
                else
                {
                    p.Add("@User_id", Id);
                }

                UserStatsModel userStats = connection.QueryFirst<UserStatsModel>("dbo.FindNumberOfFollowingsAndFollowers", p, commandType: CommandType.StoredProcedure);

                ViewBag.CurrUser = currUser;
                ViewBag.Following = following;
                ViewBag.UserStats = userStats;
            }

            return View(posts);
        }

        public IActionResult GetAuthorGeneralInfo(string id)
        {
            UserViewModel user;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var p = new DynamicParameters();

                p.Add("@User_Id", id);

                user = connection.QueryFirst<UserViewModel>("dbo.GetUserById", p, commandType: CommandType.StoredProcedure);

                if (User.FindFirstValue(ClaimTypes.NameIdentifier) != id)
                {
                    p = new DynamicParameters();

                    p.Add("@Follower_Id", User.FindFirstValue(ClaimTypes.NameIdentifier));
                    p.Add("@Following_Id", id);

                    bool following = Convert.ToBoolean(connection.QueryFirst<int>("dbo.CheckIfUserFollowing", p, commandType: CommandType.StoredProcedure));

                    user.Current_User_Following = following;
                }
                else
                {
                    user.Current_User_Following = null;
                }
            }

            return PartialView(user);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                //TODO - Add check of unique userName
                User user = new User { Email = model.Email, UserName = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);

                    using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                    {
                        var p = new DynamicParameters();
                        p.Add("@Id", user.Id);
                        p.Add("@Email", user.Email);

                        connection.Execute("dbo.CreateInstagramUser", p, commandType: CommandType.StoredProcedure);
                    }

                    return RedirectToAction("UserAccount", "Account");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        public IActionResult GetAllUsers()
        {
            List<UserViewModel> users;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                users = connection.Query<UserViewModel>("select * from dbo.InstagramUser").ToList();
            }


            return View(users);
        }

    }
}