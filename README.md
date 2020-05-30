# Instagram Clone Project
##### A little bit of lyrics
The best way to learn some material is to use it on practise. Following this principle i made a strong-willed decision to create the project on base of ASP .NET Core framework and put it on the Internet. The one thing left to do is to decide what project i will build, it needed to be challenging and not to complex (because its was my first experiense as a "Full Stack" developer) at the same time. In the end my desicion fell to the project called Instagram Clone. As the name suggests the main idea is to create the closest copy of worldwide known platform Instagram. And now less lyrics, more specifics.
##### Database structure
![DB schema](wwwroot/Pics/ic-diagram.png)
At the left side you can see the tables created by Identity API and on the right side you can see my tables. As you can see i have "instagramuser" table, at the moment i created it i didn't know that in order to add additional properties to AspNetUser table you can basically add these properties to the class inherited from IdentityUser and then apply the migrations, so i have done it in that way. All interactions with DB are performed throught Dapper Micro ORM using the stored procedures. During the development i realized that this is not the best way i have chosen, and it would be better if i have just used EF, but half of the job was done so i decided to continue in the same way. You can find all queries in [this file](DBQueries.sql).
##### Front-end 
My relationships with lady Front-end is a little bit complicated and this part was the most difficult for me, because only now i have started learning Angular front-end framework, during the development process i was using only plain `.cshtml`, `.css` and `.js` files. which became really boring and messy in some moment. Also must point out that for now my application is not fully responsive, in the way that **it's not addapted for mobile devices**.
##### Back-end
The project type that i have choosen was **ASP .NET Core MVC**. So no revelations here, everything as usual.
##### Functionality
The project is fully functionable and deployed to my [site](https://www.liveofaperson.com), so if you are interested please register and look around. However before getting to the juicy part let me explain what you can do on the site, so you don't miss a single feature:
1. **Register and Login** - Identity API provides the agile login functionality.
2. **Add Posts** - just press the button at the center of the navigation bar, corresponding modal will open.
3. **Change Profile Information** - press "change profile" button to edit or add extra information about you.
4. **Check the List of Followers and Followings** - press at the followers or followings indexes to get the list users that you follow or you are following.
5. **Add Captions, Like Photo, Bookmark the Post, Delete Post** - click on the post and take a fun. (to see bookmarked posts, press to **SAVED** section; also you can only delete post if it belongs to you)
6. **Find other users and their posts** - press on the compass button, on the right side of the navigation bar. You will see posts of other people, you can comment them, follow the author or see the author profile.
##### Epilogue


