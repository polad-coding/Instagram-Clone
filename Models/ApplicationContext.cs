using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstagramClone.Models
{
    public class ApplicationContext : IdentityDbContext<User>
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            if (Database.EnsureCreated())
            {
                //TODO - Refactor this sql queries to be read from the external file
                Database.ExecuteSqlRaw(@"
                                        create table InstagramUser(
	                                        Id varchar(450) Primary Key,
	                                        Username varchar(255),
	                                        Full_Name varchar(255),
	                                        Gender char(1),
	                                        Profile_Picture_Uri text,
	                                        Email varchar(255),
	                                        Bio text,
	                                        Web_Site_Link varchar(255)
                                        );

                                        create table Post(
	                                        Id bigint identity(1,1) Primary Key,
	                                        IUser_Id varchar(450),
	                                        Creator_Caption text,
	                                        Number_Of_Likes bigint,
	                                        Number_Of_Captions bigint,
	                                        Picture_URI text
                                        );

                                        create table Caption(
	                                        Id bigint identity(1,1) Primary Key,
	                                        Author_Id varchar(450),
	                                        Caption_Text text,
	                                        Post_Id bigint,
	                                        Creation_Time datetime
                                        );

                                        create table AccountStats(
	                                        Id bigint identity(1,1) Primary Key,
	                                        IUser_Id varchar(450),
	                                        Number_Of_Posts bigint,
	                                        Number_Of_Followers bigint,
	                                        Number_Of_Followings bigint
                                        );

                                        create table UserRelationships(
	                                        Id bigint identity(1,1) Primary Key,
	                                        Follower_Id varchar(450),
	                                        Following_Id varchar(450)
                                        );

                                        create table Bookmarks(
	                                        Id bigint identity(1,1) Primary Key,
	                                        IUser_Id varchar(450),
	                                        Post_Id bigint
                                        );

                                        ALTER TABLE AccountStats
                                        ADD CONSTRAINT FK_AccStats_User FOREIGN KEY (IUser_Id)
                                        REFERENCES InstagramUser (Id);

                                        ALTER TABLE Post
                                        ADD CONSTRAINT FK_Post_User FOREIGN KEY (IUser_Id)
                                        REFERENCES InstagramUser (Id);

                                        ALTER TABLE Caption
                                        ADD CONSTRAINT FK_Caption_User FOREIGN KEY (Author_Id)
                                        REFERENCES InstagramUser (Id);

                                        ALTER TABLE Caption
                                        ADD CONSTRAINT FK_Caption_Post FOREIGN KEY (Post_Id)
                                        REFERENCES Post (Id);

                                        ALTER TABLE UserRelationships
                                        ADD CONSTRAINT FK_UserRelationships_User FOREIGN KEY (Follower_Id)
                                        REFERENCES InstagramUser (Id);

                                        ALTER TABLE Bookmarks
                                        ADD CONSTRAINT FK_Bookmarks_User FOREIGN KEY (IUser_Id)
                                        REFERENCES InstagramUser (Id);

                                        ALTER TABLE Bookmarks
                                        ADD CONSTRAINT FK_Bookmarks_Post FOREIGN KEY (Post_Id)
                                        REFERENCES Post (Id);
");
            }
        }

    }
}
