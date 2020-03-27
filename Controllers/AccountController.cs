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

            return RedirectToAction("SignIn");
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("LogOut");
            }

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
            ViewBag.UserProfileId = id;

            return PartialView(followings);
        }


        public IActionResult GetProperLikeIcon(int postId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var p = new DynamicParameters();
                p.Add("@Post_Id", postId);
                p.Add("@User_Id", User.FindFirstValue(ClaimTypes.NameIdentifier));


                bool isLiked = Convert.ToBoolean(connection.QueryFirst<int>("dbo.IsLikedByUser", p, commandType: CommandType.StoredProcedure));

                ViewBag.IsLiked = isLiked;
                ViewBag.PostId = postId;
            }

            return PartialView();
        }

        public IActionResult UnlikePhoto(int postId)
        {
            int numberOfLikes;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var p = new DynamicParameters();
                p.Add("@Post_Id", postId);
                p.Add("@User_Id", User.FindFirstValue(ClaimTypes.NameIdentifier));
                p.Add("@Number_Of_Likes", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);


                connection.Execute("dbo.UnlikePhoto", p, commandType: CommandType.StoredProcedure);

                numberOfLikes = p.Get<int>("@Number_Of_Likes");

            }

            return Content($"Liked by {numberOfLikes} users", "text/html");
        }

        public IActionResult LikePhoto(int postId)
        {
            int numberOfLikes;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var p = new DynamicParameters();
                p.Add("@Post_Id", postId);
                p.Add("@User_Id", User.FindFirstValue(ClaimTypes.NameIdentifier));
                p.Add("@Number_Of_Likes", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.LikePhoto", p, commandType: CommandType.StoredProcedure);

                numberOfLikes = p.Get<int>("@Number_Of_Likes");

            }

            return Content($"Liked by {numberOfLikes} users", "text/html");
        }

        public IActionResult GetProperBookmarksIcon(int postId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var p = new DynamicParameters();
                p.Add("@Post_Id", postId);
                p.Add("@User_Id", User.FindFirstValue(ClaimTypes.NameIdentifier));

                bool isBookmarked = Convert.ToBoolean(connection.QueryFirst<int>("dbo.CheckIfBookmarked", p, commandType: CommandType.StoredProcedure));

                ViewBag.IsBookmarked = isBookmarked;
                ViewBag.PostId = postId;

            }
            return PartialView();
        }

        public IActionResult BookmarkPost(int postId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var p = new DynamicParameters();
                p.Add("@Post_Id", postId);
                p.Add("@User_Id", User.FindFirstValue(ClaimTypes.NameIdentifier));

                connection.Execute("dbo.BookmarkPost", p, commandType: CommandType.StoredProcedure);

            }


            return new EmptyResult();
        }

        public IActionResult UnbookmarkPost(int postId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var p = new DynamicParameters();
                p.Add("@Post_Id", postId);
                p.Add("@User_Id", User.FindFirstValue(ClaimTypes.NameIdentifier));

                connection.Execute("dbo.UnbookmarkPost", p, commandType: CommandType.StoredProcedure);

            }

            return new EmptyResult();
        }

        public IActionResult GetFollowUnfollowButton(string userId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var p = new DynamicParameters();
                p.Add("@Follower_Id", User.FindFirstValue(ClaimTypes.NameIdentifier));
                p.Add("@Following_Id", userId);

                bool isFollowing = Convert.ToBoolean(connection.QueryFirst<int>("dbo.CheckIfUserFollowing", p, commandType: CommandType.StoredProcedure));

                ViewBag.IsFollowing = isFollowing;
                ViewBag.UserId = userId;

            }

            return PartialView();
        }

        public IActionResult GetAllBookmarks()
        {
            List<PostViewModel> posts;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var p = new DynamicParameters();
                p.Add("@User_Id", User.FindFirstValue(ClaimTypes.NameIdentifier));

                posts = connection.Query<PostViewModel>("dbo.GetBookmarksByUserId", p, commandType: CommandType.StoredProcedure).ToList();

            }


            return PartialView(posts);
        }

        public IActionResult GetAllPosts(string userId)
        {
            List<PostViewModel> posts;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var p = new DynamicParameters();
                p.Add("@Id", userId);

                posts = connection.Query<PostViewModel>("dbo.GetPostsByUserId", p, commandType: CommandType.StoredProcedure).ToList();

            }


            return PartialView(posts);
        }

        public IActionResult GetPostStats(int postId)
        {
            
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var p = new DynamicParameters();
                p.Add("@Post_Id",postId);


                var responce = connection.QueryFirst<PostStatsModel>("dbo.GetPostStats", p, commandType: CommandType.StoredProcedure);

                ViewBag.Number_Of_Likes = responce.Number_Of_Likes == null ? 0 : responce.Number_Of_Likes;
                ViewBag.Number_Of_Captions = responce.Number_Of_Captions == null ? 0 : responce.Number_Of_Captions;
            }




            return PartialView();
        }

        [HttpPost]
        public IActionResult AddComment(string text, int postId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var p = new DynamicParameters();
                p.Add("@Author_Id", User.FindFirstValue(ClaimTypes.NameIdentifier));
                p.Add("@Text", text);
                p.Add("@Post_Id", postId);

                connection.Execute("dbo.AddCaption", p, commandType: CommandType.StoredProcedure);

            }

            return RedirectToAction("GetAllCaptions", new { postId = postId });
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
            ViewBag.UserProfileId = id;


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

                    posts.Add(new PostViewModel() { Id = id, IUser_Id = User.FindFirstValue(ClaimTypes.NameIdentifier), Picture = imageData});
                }

            }

            return RedirectToAction("UserAccount", "Account", new { id = "null" });
        }

        public IActionResult GetAllCaptions(string postId)
        {
            List<CaptionViewModel> captions;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {

                var p = new DynamicParameters();
                p.Add("@Post_Id", postId);

                captions = connection.Query<CaptionViewModel>("dbo.GetAllPostCaptions", p, commandType: CommandType.StoredProcedure).ToList();
                
            }

            captions = captions.OrderBy((m) => m.Creation_Time ).ToList();

            return PartialView(captions);
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
                    return Json(false);
                }
            }


            return Json(true);
        }

        [HttpPost]
        public IActionResult EditProfile(ChangeProfileViewModel model)
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

            return RedirectToAction("UserAccount", "Account", new { id = User.FindFirstValue(ClaimTypes.NameIdentifier) });
        }

        public JsonResult IsUserNameExists(string User_Name)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var p = new DynamicParameters();
                p.Add("@UserName", User_Name);

                int result = connection.QueryFirst<int>("dbo.IsUserNameUnique", p, commandType: CommandType.StoredProcedure);

                if (Convert.ToBoolean(result))
                {
                    return Json(false);
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

        public IActionResult Navigate()
        {
            return View();
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
                ViewBag.Posts = posts;
            }

            return View(new ChangeProfileViewModel());
        }

        public IActionResult GetAuthorGeneralInfo(string id, int postId)
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

            ViewBag.PostId = postId;

            return PartialView(user);
        }

        public IActionResult DeletePost(string userId, int postId)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var p = new DynamicParameters();

                p.Add("@Post_Id", postId);

                connection.Execute("dbo.DeletePost", p, commandType: CommandType.StoredProcedure);

            }


            return RedirectToAction("UserAccount", "Account", new { id = userId });
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
                User user = new User { Email = model.Email, UserName = model.User_Name };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);

                    using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                    {
                        var p = new DynamicParameters();
                        p.Add("@Id", user.Id);
                        p.Add("@UserName", model.User_Name);
                        p.Add("@Email", model.Email);
                        p.Add("@FullName", model.Full_Name);

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