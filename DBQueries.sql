create table InstagramUser(
	Id varchar(450) Primary Key,
	Username varchar(255) unique,
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
	Picture varbinary(max)
);

create table Caption(
	Id bigint identity(1,1) Primary Key,
	Author_Id varchar(450),
	Caption_Text text,
	Post_Id bigint,
	Creation_Time datetime
);

create table Likes (
	Id bigint identity(1,1) primary key,
	From_User varchar(450),
	Post_Id bigint
)

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

ALTER TABLE Likes
ADD CONSTRAINT FK_Likes_IUser FOREIGN KEY (From_User)
REFERENCES InstagramUser (Id);

ALTER TABLE Likes
ADD CONSTRAINT FK_Likes_Post FOREIGN KEY (Post_Id)
REFERENCES Post (Id);


------Stored procedures--------

CREATE PROCEDURE AddCaption ( IN A_Author_Id varchar(450), IN A_Text text, IN A_Post_Id bigint) BEGIN insert into Caption (Author_Id,Caption_Text,Post_Id,Creation_Time) values (A_Author_Id,A_Text,A_Post_Id,CURRENT_TIMESTAMP); update Post set Number_Of_Captions = COALESCE(Number_Of_Captions + 1,1) where Id = A_Post_Id; END 

CREATE PROCEDURE AddPost ( OUT A_Id bigint, IN A_User_Id varchar(450), IN A_User_Caption text, IN A_Picture longblob) BEGIN DECLARE last_id INT; insert into Post (IUser_Id,Number_Of_Likes,Number_Of_Captions,Picture) values (A_User_Id,null,1,A_Picture); select LAST_INSERT_ID() into last_id; set A_Id = last_id; insert into Caption (Author_Id,Caption_Text,Post_Id,Creation_Time) values (A_User_Id,A_User_Caption,A_Id,GETDATE()); END 

CREATE PROCEDURE BookmarkPost ( IN A_Post_Id bigint, IN A_User_Id varchar(450)) BEGIN insert into Bookmarks (IUser_Id,Post_Id) values (A_User_Id,A_Post_Id); END 

---forgot check if bookmarked---

CREATE PROCEDURE CheckIfUserFollowing ( A_Follower_Id varchar(450), A_Following_Id varchar(450)) BEGIN select count(*) from UserRelationships where Follower_Id = A_Follower_Id and Following_Id = A_Following_Id; END 

---forgot createinstagramuser---

CREATE PROCEDURE DeletePost (IN A_Post_Id bigint) BEGIN delete from Bookmarks where Post_Id = A_Post_Id; delete from Caption where Post_Id = A_Post_Id; delete from Likes where Post_Id = A_Post_Id; delete from Post where Id = A_Post_Id; END 

CREATE PROCEDURE FindNumberOfFollowingsAndFollowers (IN A_User_id varchar(450)) BEGIN select (select count(*) from UserRelationships where Follower_Id = A_User_id) as NumberOfFollowings,(select count(*) from UserRelationships where Following_Id = A_User_id) as NumberOfFollowers; END 

CREATE PROCEDURE FollowUser (IN A_Follower_Id varchar(450), IN A_Following_Id varchar(450)) BEGIN insert into UserRelationships (Follower_Id, Following_Id) values (A_Follower_Id,A_Following_Id); END 

CREATE PROCEDURE GetAllFollowerUsers (IN A_User_Id varchar(450)) BEGIN select Id,UserName,Full_name,Gender,Email,Bio,Web_Site_Link,Profile_Picture_URI from (select ur.Follower_Id from UserRelationships as ur where Following_Id = A_User_Id) as res inner join InstagramUser as iu on res.Follower_Id = iu.Id; END 

CREATE PROCEDURE GetAllFollowingUsers (IN A_User_Id varchar(450)) BEGIN select Id,UserName,Full_name,Gender,Email,Bio,Web_Site_Link,Profile_Picture_URI from (select ur.Following_Id from UserRelationships as ur where Follower_Id = A_User_Id) as res inner join InstagramUser as iu on res.Following_Id = iu.Id; END 

CREATE PROCEDURE GetAllPostCaptions (IN A_Post_Id bigint) BEGIN select Caption_Id,Author_Id,Username,Caption_Text,Creation_Time,Profile_Picture_URI from (select Id as Caption_Id,Author_Id,Caption_Text,Creation_Time from Caption where Post_Id = A_Post_Id) as captions inner join InstagramUser as iu on captions.Author_Id = iu.Id; END 

CREATE PROCEDURE GetAllPosts () BEGIN select * from Post order by Creation_Time; END 

CREATE PROCEDURE GetAllPostsByUserId (IN A_User_Id varchar(450)) BEGIN select * from Post where IUser_Id = A_User_Id; END 

CREATE PROCEDURE GetAllUsers (IN A_Curr_User_Id varchar(450)) BEGIN select * from InstagramUser where Id != A_Curr_User_Id; END 

CREATE PROCEDURE GetBookmarksByUserId (IN A_User_Id varchar(450)) BEGIN select p.* from (select * from Bookmarks where IUser_Id = A_User_Id) as result inner join Post as p on result.Post_Id = p.Id ; END 

CREATE PROCEDURE GetPostsByUserId (IN A_Id varchar(450)) BEGIN select p.Id,p.IUser_Id,p.Number_Of_Likes,p.Number_Of_Captions,p.Picture from Post as p where p.IUser_Id = A_Id; END 

CREATE PROCEDURE GetPostStats (IN A_Post_Id bigint) BEGIN select Number_Of_Likes,Number_Of_Captions from Post where Id = A_Post_Id; END 

CREATE PROCEDURE GetUserById (IN A_User_Id varchar(450)) BEGIN select * from InstagramUser as iu where iu.Id = A_User_Id; END 

CREATE PROCEDURE IsLikedByUser (IN A_Post_Id bigint, IN A_User_Id varchar(450)) BEGIN select count(*) from Likes where From_User = A_User_Id and Post_Id = A_Post_Id; END 

CREATE PROCEDURE IsMailUnique (IN A_Email varchar(255)) BEGIN select Id from InstagramUser where Email = A_Email; END 

CREATE PROCEDURE IsUserExists (IN A_User_Id varchar(450)) BEGIN select * from InstagramUser where Id = A_User_Id; END 

CREATE PROCEDURE IsUserFollowing ( IN A_Curr_User_Id varchar(450), IN A_User_Id varchar(450), OUT A_Responce bit) BEGIN set A_Responce = (select count(*) from UserRelationships as ur where ur.Follower_Id = A_Curr_User_Id and ur.Following_Id = A_User_Id); END 

CREATE PROCEDURE IsUserNameUnique ( IN A_UserName varchar(255)) BEGIN select Id from InstagramUser where Username = A_UserName; END 

CREATE PROCEDURE LikePhoto ( IN A_Post_Id bigint, IN A_User_Id varchar(450), OUT A_Number_Of_Likes int) BEGIN insert into Likes (From_User,Post_Id) values (A_User_Id,A_Post_Id); update Post set Number_Of_Likes = coalesce(Number_Of_Likes + 1,1) where Id = A_Post_Id; select A_Number_Of_Likes = (select Number_Of_Likes from Post where Id = A_Post_Id); END 

CREATE PROCEDURE UnbookmarkPost ( IN A_Post_Id bigint, IN A_User_Id varchar(450)) BEGIN delete from Bookmarks where IUser_Id = A_User_Id and Post_Id = A_Post_Id; END 

CREATE PROCEDURE UnfollowUser ( IN A_Follower_Id varchar(450), IN A_Following_Id varchar(450)) BEGIN delete from UserRelationships where Follower_Id = A_Follower_Id and Following_Id = A_Following_Id; END 

CREATE PROCEDURE UnlikePhoto ( IN A_Post_Id bigint, IN A_User_Id varchar(450), OUT A_Number_Of_Likes int) BEGIN delete from Likes where From_User = A_User_Id and Post_Id = A_Post_Id; update Post set Number_Of_Likes = Number_Of_Likes - 1 where Id = A_Post_Id; select A_Number_Of_Likes = (select Number_Of_Likes from Post where Id = A_Post_Id); END 

CREATE PROCEDURE UpdateUserProfile ( IN A_Id varchar(450), IN A_UserName varchar(255), IN A_FullName varchar(255), IN A_Gender char(1), IN A_Email varchar(255), IN A_Bio text, IN A_WebSiteLink varchar(255), IN A_ProfilePicture longblob) BEGIN update InstagramUser set Username = ifNull(A_UserName,Username), Full_Name = A_FullName, Gender = A_Gender, Email = ifNull(A_Email,Email), Bio = A_Bio, Web_Site_Link = A_WebSiteLink, Profile_Picture_URI = ifNull(A_ProfilePicture,Profile_Picture_URI) where Id = A_Id; update AspNetUsers set UserName = ifNull(A_UserName,UserName), NormalizedUserName = ifNull(upper(A_UserName),NormalizedUserName), Email = ifNull(A_Email,Email), NormalizedEmail = ifNull(upper(A_Email),NormalizedEmail) where Id = A_Id; END 