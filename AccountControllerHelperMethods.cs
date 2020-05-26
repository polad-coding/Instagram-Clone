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
            p.Add("A_Id", userId);
            p.Add("A_UserName", userInfo.User_Name);
            p.Add("A_Email", userInfo.Email);
            p.Add("A_FullName", userInfo.Full_Name);

            connection.Execute("CreateInstagramUser", p, commandType: CommandType.StoredProcedure);
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
            p.Add("A_User_Id", userId);

            followings = connection.Query<UserViewModel>("GetAllFollowingUsers", p, commandType: CommandType.StoredProcedure).ToList();

            return followings;
        }

        public static List<UserViewModel> GetAllFollowers(IDbConnection connection, string userId)
        {
            List<UserViewModel> followers = new List<UserViewModel>();

            var p = new DynamicParameters();
            p.Add("A_User_Id", userId);

            followers = connection.Query<UserViewModel>("GetAllFollowerUsers", p, commandType: CommandType.StoredProcedure).ToList();

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
            p.Add("A_Curr_User_Id", currUserId);
            p.Add("A_User_Id", followingUserId);
            p.Add("A_Responce", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

            connection.Execute("IsUserFollowing", p, commandType: CommandType.StoredProcedure);
            var result = p.Get<ulong?>("A_Responce");
            bool isFollowing = result == 0 ? false : true;

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
        public static long AddPost(IDbConnection connection,string userId, byte[] imageData, string caption)
        {
            var p = new DynamicParameters();
            p.Add("A_User_Id", userId);
            p.Add("A_User_Caption", caption);
            p.Add("A_Picture", imageData);
            p.Add("A_Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

            connection.Execute("AddPost", p, commandType: CommandType.StoredProcedure);

            long newId = p.Get<long>("A_Id");

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
            p.Add("A_Id", userId);
            p.Add("A_UserName", model.User_Name);
            p.Add("A_FullName", model.FullName);
            p.Add("A_Gender", genderToPass);
            p.Add("A_Email", model.Email);
            p.Add("A_Bio", model.Bio);
            p.Add("A_WebSiteLink", model.WebSiteLink);
            p.Add("A_ProfilePicture", imageData, DbType.Binary);

            connection.Execute("UpdateUserProfile", p, commandType: CommandType.StoredProcedure);
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

            p.Add("A_User_Id", Id);

            UserViewModel currUser = connection.QueryFirstOrDefault<UserViewModel>("IsUserExists", p, commandType: CommandType.StoredProcedure);

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

            p.Add("A_User_Id", Id);

            UserStatsModel userStats = connection.QueryFirst<UserStatsModel>("FindNumberOfFollowingsAndFollowers", p, commandType: CommandType.StoredProcedure);

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

            p.Add("A_Id", id);
            List<PostViewModel> posts = connection.Query<PostViewModel>("GetPostsByUserId", p, commandType: CommandType.StoredProcedure).ToList();

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

            p.Add("A_Curr_User_Id", curr_user_id);

            List<UserViewModel> users = connection.Query<UserViewModel>("GetAllUsers", p, commandType: CommandType.StoredProcedure).ToList();

            return users;
        }
    }
}
