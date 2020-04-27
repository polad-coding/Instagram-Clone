using Dapper;
using InstagramClone.Models;
using InstagramClone.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;

namespace InstagramClone
{
    public class AccountControllerHelperMethods
    {

        /// <summary>
        /// Create instagram user.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="userId"></param>
        /// <param name="userInfo"></param>
        public static void CreateInstagramUser(IDbConnection connection, string userId, RegisterViewModel userInfo)
        {
            var p = new DynamicParameters();
            p.Add("@Id", userId);
            p.Add("@UserName", userInfo.User_Name);
            p.Add("@Email", userInfo.Email);
            p.Add("@FullName", userInfo.Full_Name);

            connection.Execute("dbo.CreateInstagramUser", p, commandType: CommandType.StoredProcedure);
        }

        /// <summary>
        /// Get all users that current user following.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static List<UserViewModel> GetAllFollowings(IDbConnection connection, string userId)
        {
            List<UserViewModel> followings = new List<UserViewModel>();

            var p = new DynamicParameters();
            p.Add("@User_Id", userId);

            followings = connection.Query<UserViewModel>("dbo.GetAllFollowingUsers", p, commandType: CommandType.StoredProcedure).ToList();

            return followings;
        }

        public static List<UserViewModel> GetAllFollowers(IDbConnection connection, string userId)
        {
            List<UserViewModel> followers = new List<UserViewModel>();

            var p = new DynamicParameters();
            p.Add("@User_Id", userId);

            followers = connection.Query<UserViewModel>("dbo.GetAllFollowerUsers", p, commandType: CommandType.StoredProcedure).ToList();

            return followers;
        }

        /// <summary>
        /// Check if current user following the given user.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="currUserId"></param>
        /// <param name="followingUserId"></param>
        /// <returns></returns>
        public static bool IsCurrentUserFollowing(IDbConnection connection, string currUserId, string followingUserId)
        {
            var p = new DynamicParameters();
            p.Add("@Curr_User_Id", currUserId);
            p.Add("@User_Id", followingUserId);
            p.Add("@Responce", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

            connection.Execute("dbo.IsUserFollowing", p, commandType: CommandType.StoredProcedure);

            bool isFollowing = Convert.ToBoolean(p.Get<int>("@Responce"));

            return isFollowing;
        }

        /// <summary>
        /// Add post.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="userId"></param>
        /// <param name="imageData"></param>
        /// <param name="caption"></param>
        /// <returns></returns>
        public static int AddPost(IDbConnection connection,string userId, byte[] imageData, string caption)
        {
            var p = new DynamicParameters();
            p.Add("@User_Id", userId);
            p.Add("@User_Caption", caption);
            p.Add("@Picture", imageData);
            p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

            connection.Execute("dbo.AddPost", p, commandType: CommandType.StoredProcedure);

            int newId = p.Get<int>("@Id");

            return newId;
        }

        /// <summary>
        /// Change the profile.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="model"></param>
        /// <param name="userId"></param>
        /// <param name="imageData"></param>
        public static void ChangeProfile(IDbConnection connection, ChangeProfileViewModel model, string userId, byte[] imageData)
        {
            char? genderToPass = model.Gender == null ? (char?)null : (model.Gender == "Men" ? 'm' : 'f');

            var p = new DynamicParameters();
            p.Add("@Id", userId);
            p.Add("@UserName", model.User_Name);
            p.Add("@FullName", model.FullName);
            p.Add("@Gender", genderToPass);
            p.Add("@Email", model.Email);
            p.Add("@Bio", model.Bio);
            p.Add("@WebSiteLink", model.WebSiteLink);
            p.Add("@ProfilePicture", imageData, DbType.Binary);

            connection.Execute("dbo.UpdateUserProfile", p, commandType: CommandType.StoredProcedure);
        }

        /// <summary>
        /// Get the given user.
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static UserViewModel GetUser(string Id, IDbConnection connection)
        {
            var p = new DynamicParameters();

            p.Add("@User_Id", Id);

            UserViewModel currUser = connection.QueryFirstOrDefault<UserViewModel>("dbo.IsUserExists", p, commandType: CommandType.StoredProcedure);

            return currUser;
        }

        /// <summary>
        /// Get user followers and followings for the given user.
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static UserStatsModel GetUserStats(string Id, IDbConnection connection)
        {
            var p = new DynamicParameters();

            p.Add("@User_Id", Id);

            UserStatsModel userStats = connection.QueryFirst<UserStatsModel>("dbo.FindNumberOfFollowingsAndFollowers", p, commandType: CommandType.StoredProcedure);

            return userStats;
        }

        /// <summary>
        /// Get all posts of the given user.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static List<PostViewModel> GetAllUserPosts(string id, IDbConnection connection)
        {
            var p = new DynamicParameters();

            p.Add("@Id", id);
            List<PostViewModel> posts = connection.Query<PostViewModel>("dbo.GetPostsByUserId", p, commandType: CommandType.StoredProcedure).ToList();

            return posts;
        }

        /// <summary>
        /// Get all users.
        /// </summary>
        /// <param name="curr_user_id"></param>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static List<UserViewModel> GetAllUsers(string curr_user_id, IDbConnection connection)
        {
            var p = new DynamicParameters();

            p.Add("@Curr_User_Id", curr_user_id);

            List<UserViewModel> users = connection.Query<UserViewModel>("dbo.GetAllUsers", p, commandType: CommandType.StoredProcedure).ToList();

            return users;
        }
    }
}
