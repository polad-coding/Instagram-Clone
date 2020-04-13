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
        private string connectionString { get; set; }

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            posts = new List<PostViewModel>();
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        /// <summary>
        /// Log the user out and redirect to sign in page.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("SignIn");
        }

        /// <summary>
        /// Get the SignIn page view.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult SignIn()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("LogOut");
            }

            return View();
        }

        /// <summary>
        /// Get all follwings.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult GetFollowings(string id)
        {
            List<UserViewModel> followings;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {

                followings = AccountControllerHelperMethods.GetAllFollowings(connection, id);

                for (int i = 0; i < followings.Count; i++)
                {
                    followings[i].Current_User_Following = true;
                }

            }

            ViewBag.CurrUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.UserProfileId = id;

            return PartialView(followings);
        }

        /// <summary>
        /// Check if post is liked and display respective button.
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public IActionResult GetProperLikeIcon(int postId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
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

        /// <summary>
        /// Unlike the post.
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public IActionResult UnlikePhoto(int postId)
        {
            int numberOfLikes;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
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

        /// <summary>
        /// Like the post.
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public IActionResult LikePhoto(int postId)
        {
            int numberOfLikes;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
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

        /// <summary>
        /// Check if post is bookmarked and get the proper icon.
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public IActionResult GetProperBookmarksIcon(int postId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
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

        /// <summary>
        /// Bookmark the given post.
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public IActionResult BookmarkPost(int postId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@Post_Id", postId);
                p.Add("@User_Id", User.FindFirstValue(ClaimTypes.NameIdentifier));

                connection.Execute("dbo.BookmarkPost", p, commandType: CommandType.StoredProcedure);

            }

            return new EmptyResult();
        }

        /// <summary>
        /// Unbookmark the given post.
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public IActionResult UnbookmarkPost(int postId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@Post_Id", postId);
                p.Add("@User_Id", User.FindFirstValue(ClaimTypes.NameIdentifier));

                connection.Execute("dbo.UnbookmarkPost", p, commandType: CommandType.StoredProcedure);

            }

            return new EmptyResult();
        }

        /// <summary>
        /// For each user get proper button.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IActionResult GetFollowUnfollowButton(string userId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
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

        /// <summary>
        /// Get all bookmarks for current user.
        /// </summary>
        /// <returns></returns>
        public IActionResult GetAllBookmarks()
        {
            List<PostViewModel> posts;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@User_Id", User.FindFirstValue(ClaimTypes.NameIdentifier));

                posts = connection.Query<PostViewModel>("dbo.GetBookmarksByUserId", p, commandType: CommandType.StoredProcedure).ToList();

            }


            return PartialView(posts);
        }

        /// <summary>
        /// Get all posts for current user.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IActionResult GetAllPosts(string userId)
        {
            List<PostViewModel> posts;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@Id", userId);

                posts = connection.Query<PostViewModel>("dbo.GetPostsByUserId", p, commandType: CommandType.StoredProcedure).ToList();

            }

            return PartialView(posts);
        }

        /// <summary>
        /// Get number of likes and number of captions for current post.
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public IActionResult GetPostStats(int postId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@Post_Id", postId);

                var responce = connection.QueryFirst<PostStatsModel>("dbo.GetPostStats", p, commandType: CommandType.StoredProcedure);

                ViewBag.Number_Of_Likes = responce.Number_Of_Likes == null ? 0 : responce.Number_Of_Likes;
                ViewBag.Number_Of_Captions = responce.Number_Of_Captions == null ? 0 : responce.Number_Of_Captions;
            }

            return PartialView();
        }

        /// <summary>
        /// Add new caption.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="postId"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddComment(string text, int postId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@Author_Id", User.FindFirstValue(ClaimTypes.NameIdentifier));
                p.Add("@Text", text);
                p.Add("@Post_Id", postId);

                connection.Execute("dbo.AddCaption", p, commandType: CommandType.StoredProcedure);

            }

            return RedirectToAction("GetAllCaptions", new { postId = postId });
        }

        /// <summary>
        /// Get all followers for given user and check if current user if following them (to display the proper button).
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetFollowers(string id)
        {
            List<UserViewModel> followers = new List<UserViewModel>();

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {

                followers = AccountControllerHelperMethods.GetAllFollowers(connection, id);

                for (int i = 0; i < followers.Count; i++)
                {
                    bool isFollowing = AccountControllerHelperMethods.IsCurrentUserFollowing(connection, User.FindFirstValue(ClaimTypes.NameIdentifier), followers[i].Id);

                    followers[i].Current_User_Following = isFollowing;
                }

            }

            ViewBag.CurrUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.UserProfileId = id;

            return PartialView(followers);
        }


        /// <summary>
        /// Sign in the user.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(LogInViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

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

        [HttpPost]
        public IActionResult AddPost(string caption, IFormFile img)
        {
            byte[] imageData = null;

            using (var binaryReader = new BinaryReader(img.OpenReadStream()))
            {
                imageData = binaryReader.ReadBytes((int)img.Length);
            }

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                int postId = AccountControllerHelperMethods.AddPost(connection, User.FindFirstValue(ClaimTypes.NameIdentifier), imageData, caption);

                posts.Add(new PostViewModel() { Id = postId, IUser_Id = User.FindFirstValue(ClaimTypes.NameIdentifier), Picture = imageData });
            }

            return RedirectToAction("UserAccount", "Account", new { id = "null" });
        }

        /// <summary>
        /// Get all captions for given post and sort them by date and time.
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public IActionResult GetAllCaptions(string postId)
        {
            List<CaptionViewModel> captions;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@Post_Id", postId);

                captions = connection.Query<CaptionViewModel>("dbo.GetAllPostCaptions", p, commandType: CommandType.StoredProcedure).ToList();
            }

            captions = captions.OrderBy((m) => m.Creation_Time).ToList();

            return PartialView(captions);
        }

        /// <summary>
        /// Change profile with the given data.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult ChangeProfile(ChangeProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
                {
                    byte[] imageData = null;

                    if (model.ProfilePicture != null)
                    {
                        using (var binaryReader = new BinaryReader(model.ProfilePicture.OpenReadStream()))
                        {
                            imageData = binaryReader.ReadBytes((int)model.ProfilePicture.Length);
                        }
                    }

                    AccountControllerHelperMethods.ChangeProfile(connection, model, User.FindFirstValue(ClaimTypes.NameIdentifier), imageData);

                }
            }
            return View();
        }

        /// <summary>
        /// During the registration and change profile procedure check if the given email address is correct.
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        public JsonResult IsEmailExists(string Email)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@Email", Email);

                string matchId = connection.QueryFirst<string>("dbo.IsMailUnique", p, commandType: CommandType.StoredProcedure);

                if (matchId != null && matchId != User.FindFirstValue(ClaimTypes.NameIdentifier))
                {
                    return Json(false);
                }

            }

            return Json(true);
        }

        /// <summary>
        /// During the change profile procedure check if the given user name is correct.
        /// </summary>
        /// <param name="User_Name"></param>
        /// <returns></returns>
        public JsonResult IsUserNameExists(string User_Name)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@UserName", User_Name);

                string matchId = connection.QueryFirst<string>("dbo.IsUserNameUnique", p, commandType: CommandType.StoredProcedure);

                if (matchId != null && matchId != User.FindFirstValue(ClaimTypes.NameIdentifier))
                {
                    return Json(false);
                }
            }

            return Json(true);
        }

        /// <summary>
        /// Follow the given user.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult FollowUser(string id)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@Follower_Id", User.FindFirstValue(ClaimTypes.NameIdentifier));
                p.Add("@Following_Id", id);

                connection.Execute("dbo.FollowUser", p, commandType: CommandType.StoredProcedure);
            }

            return new EmptyResult();
        }

        /// <summary>
        /// Unfollow the given user.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult UnfollowUser(string id)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@Follower_Id", User.FindFirstValue(ClaimTypes.NameIdentifier));
                p.Add("@Following_Id", id);

                connection.Execute("dbo.UnfollowUser", p, commandType: CommandType.StoredProcedure);
            }

            return new EmptyResult();

        }

        /// <summary>
        /// Get posts of all users.
        /// </summary>
        /// <returns></returns>
        public IActionResult Navigate()
        {
            List<PostViewModel> posts;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var p = new DynamicParameters();

                posts = connection.Query<PostViewModel>("dbo.GetAllPosts", p, commandType: CommandType.StoredProcedure).ToList();
            }

            return View(posts);
        }

        /// <summary>
        /// Return the user account.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public IActionResult UserAccount(string Id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("SignIn", "Account");
            }

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                if (Id == "null" || Id == null)
                {
                    Id = User.FindFirstValue(ClaimTypes.NameIdentifier);
                }

                UserViewModel currUser = AccountControllerHelperMethods.GetUser(Id, connection);
                UserStatsModel userStats = AccountControllerHelperMethods.GetUserStats(Id, connection);

                if (currUser == null)
                {
                    return RedirectToAction("Error", "Home");
                }

                posts = AccountControllerHelperMethods.GetAllUserPosts(Id, connection);

                ViewBag.CurrUser = currUser;
                ViewBag.UserStats = userStats;
                ViewBag.Posts = posts;
            }

            return View(new ChangeProfileViewModel());
        }

        /// <summary>
        /// Check if current user if following the author of the given post and pass this info into the view.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="postId"></param>
        /// <returns></returns>
        public IActionResult GetAuthorGeneralInfo(string id, int postId)
        {
            UserViewModel user;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {

                user = AccountControllerHelperMethods.GetUser(id, connection);

                if (User.FindFirstValue(ClaimTypes.NameIdentifier) != id)
                {
                    bool following = AccountControllerHelperMethods.IsCurrentUserFollowing(connection, User.FindFirstValue(ClaimTypes.NameIdentifier), id);

                    user.Current_User_Following = following;
                }
                else
                {
                    user.Current_User_Following = false;
                }
            }

            ViewBag.PostId = postId;

            return PartialView(user);
        }

        /// <summary>
        /// Delete user's post.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="postId"></param>
        /// <returns></returns>
        public IActionResult DeletePost(string userId, int postId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var p = new DynamicParameters();

                p.Add("@Post_Id", postId);

                connection.Execute("dbo.DeletePost", p, commandType: CommandType.StoredProcedure);
            }

            return RedirectToAction("UserAccount", "Account", new { id = userId });
        }

        /// <summary>
        /// Return Register page view.
        /// </summary>
        /// <returns></returns>
        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// Create new user and sign him in.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User { Email = model.Email, UserName = model.User_Name };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);

                    using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
                    {
                        AccountControllerHelperMethods.CreateInstagramUser(connection, user.Id, model);
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

        /// <summary>
        /// Get all users.
        /// </summary>
        /// <returns></returns>
        public IActionResult GetAllUsers()
        {

            List<UserViewModel> users;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                users = AccountControllerHelperMethods.GetAllUsers(User.FindFirstValue(ClaimTypes.NameIdentifier), connection);

                foreach (var user in users)
                {
                    bool isFollowing = AccountControllerHelperMethods.IsCurrentUserFollowing(connection, User.FindFirstValue(ClaimTypes.NameIdentifier), user.Id);
                    user.Current_User_Following = isFollowing;
                }
            }

            return View(users);
        }

    }
}