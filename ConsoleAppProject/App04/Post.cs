﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConsoleAppProject.App04
{   
    /// <summary>
    /// This class is used to create the post object for each post.
    /// </summary>
    public class Post
    {
        //Variables for each post
        public int PostId { get; }

        private static int instances = 0;

        private int likes;

        //List to store comments for each post.
        private readonly List<String> comments;


        // username of the post's author
        [StringLength(20), Required]
        public String Username { get; }

        public DateTime Timestamp { get; }

        //Constructor for PostID, Username, Likes, timestamp and comment list for each post.
        public Post(string author)
        {
            instances++;
            PostId = instances;

            this.Username = author;
            Timestamp = DateTime.Now;

            likes = 0;
            comments = new List<String>();        

        }

        /// <summary>
        /// Record one more 'Like' indication from a user.
        /// </summary>
        public void Like()
        {
            likes++;
        }

        ///<summary>
        /// Record that a user has withdrawn his/her 'Like' vote.
        ///</summary>
        public void Unlike()
        {
            if (likes > 0)
            {
                likes--;
            }
        }

        ///<summary>
        /// Add a comment to this post.
        /// </summary>
        /// <param name="text">
        /// The new comment to add.
        /// </param>        
        public void AddComment(String text)
        {
            comments.Add(text);
        }


        ///<summary>
        /// Create a string describing a time point in the past in terms 
        /// relative to current time, such as "30 seconds ago" or "7 minutes ago".
        /// Currently, only seconds and minutes are used for the string.
        /// </summary>
        /// <param name="time">
        ///  The time value to convert (in system milliseconds)
        /// </param> 
        /// <returns>
        /// A relative time string for the given time
        /// </returns>      
        private String FormatElapsedTime(DateTime time)
        {
            DateTime current = DateTime.Now;
            TimeSpan timePast = current - time;

            long seconds = (long)timePast.TotalSeconds;
            long minutes = seconds / 60;

            if (minutes > 0)
            {
                return minutes + " minutes ago";
            }
            else
            {
                return seconds + " seconds ago";
            }
        }


        ///<summary>
        /// Display the details of this post.
        /// 
        /// Print to the text terminal
        ///</summary>
        public virtual void Display()
        {
            Console.WriteLine();
            Console.WriteLine($"    PostID: {PostId}");
            Console.WriteLine($"    Author: {Username}");
            Console.WriteLine($"    Time Elpased: {FormatElapsedTime(Timestamp)}");
            Console.WriteLine();

            if (likes > 0)
            {
                Console.WriteLine($"    Likes:  {likes}  people like this.");
            }
            else
            {
                Console.WriteLine(" 0 people like this");
            }

            if (comments.Count == 0)
            {
                Console.WriteLine("    No comments.");
            }
            else
            {
                foreach(String comment in comments)
                {
                    Console.WriteLine($"      Comment: {comment}");
                }
            }

            Console.WriteLine("--------------------------------------------------");
        }
         
        //This method returns the number of posts.
        public static int GetNumberOfPosts()
        {
            return instances;
        }

        public NewsFeed NewsFeed
        {
            get => default;
            set
            {
            }
        }
    }
}