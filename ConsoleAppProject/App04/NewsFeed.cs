using ConsoleAppProject.Helpers;
using System;
using System.Collections.Generic;
using System.Xml.Linq;


namespace ConsoleAppProject.App04
{
    ///<summary>
    /// The NewsFeed class stores news posts for the news feed in a social network 
    /// application.
    /// 
    /// Display of the posts is currently simulated by printing the details to the
    /// terminal.
    /// 
    /// This version does not save the data to disk, and it provides 
    /// search, delete, like and dislike functions.
    ///</summary>
    ///<author>
    ///  Joyson Cardoso
    ///  version 0.1
    ///</author> 
    public class NewsFeed
    {
        //creates a list for new posts
        private readonly List<Post> posts;


        ///<summary>
        /// Construct a news feed with test posts.
        ///</summary>
        public NewsFeed()
        {
            posts = new List<Post>();

            MessagePost post = new MessagePost("Bay", "I love the Moon!!!");
            AddMessagePost(post);

            PhotoPost photoPost = new PhotoPost("Han","Sun1.jpg" ,"I love the Sun!!!");
            AddPhotoPost(photoPost);
        }


        ///<summary>
        /// Add a text post to the news feed.
        /// 
        /// @param text  The text post to be added.
        ///</summary>
        public void AddMessagePost(MessagePost message)
        {
            posts.Add(message);
        }

        ///<summary>
        /// Add a photo post to the news feed.
        /// 
        /// @param photo  The photo post to be added.
        ///</summary>
        public void AddPhotoPost(PhotoPost photo)
        {
            posts.Add(photo);
        }

        ///<summary>
        ///This method searches for the post id inputed using the findPost method and returns
        ///the post and stores it in the post variable, Which if found is then removed form the list 
        ///using the Remove function.
        ///</summary>
        public void RemovePost(int id)
        {
            Post post = FindPost(id);

            if (post == null)
            {
                Console.WriteLine($" \nPost with ID = {id} does not exist!!\n");
            }
            else
            {
                Console.WriteLine($" \nThe following Post {id} has been removed!\n");
                posts.Remove(post);
                post.Display();
                
            }
            
        }

        ///This method is used to find the post using the PostID and returns it to the 
        ///Removepost() function.
        public Post FindPost(int id)
        {
            foreach(Post post in posts)
            {
                if(post.PostId == id)
                {
                    return post;
                }
            }

            return null;
        }

        ///<summary>
        /// Show the news feed. Currently: print the news feed details to the
        /// terminal. 
        ///</summary>      
        public void Display()
        {
            // display all text posts
            foreach (Post post in posts)
            {
                post.Display();
                Console.WriteLine();   // empty line between posts
            }

        }


        ///This Method is used to find a paticular author and print thier post.
        ///it uses a foreach loop to loop through the posts list and uses an if statment
        ///to check if the input name matches the username element in each post. If the name matches 
        ///it prints the post else it prints author not found in the post for wach dost and its ID.

        public void AuthorDisplay(string name)
        {

            foreach (Post post in posts)
            {
                if(post.Username == name)
                {
                    post.Display();
                    Console.WriteLine();   // empty line between posts
                }
                else  Console.WriteLine($"       Author Not Found in Post {post.PostId}");                
            }
        }


      
        ///This method uses the PostId to find the post he user wants to comment on by comparing
        ///The id to the post id elemt if it matches it adds the user comment to its comment list.

        public void AddComment(int id)
        {
            foreach (Post post in posts)
            {
                if (post.PostId == id)
                {
                    Console.WriteLine();
                    Console.Write("Comment: ");
                    string comment = Console.ReadLine();
                    post.AddComment(comment);
                    Console.WriteLine();
                }
            }
        }

        ///This method handles the like and dislike functionality. It Uses the input id 
        ///and uses a foreach loop to find the id post in the post lists. If the PostID is 
        ///found it prompts the user to enter 1 to like and 2 to dislike. The conditional 
        ///statment is used to call the Like() or UnLike() which adds a like or subtracts
        ///a like from the post.

        public void LikeOrDislikePosts(int id)
        {
            foreach (Post post in posts)
            {
                if (post.PostId == id)
                {

                    string[] choices = { "To Like","To Dislike" };
                    int choiceNo = ConsoleHelper.SelectChoice(choices);

                    if (choiceNo == 1)
                    {
                        post.Like();
                    }
                    else post.Unlike();

                }
            }
        }
    }
}
