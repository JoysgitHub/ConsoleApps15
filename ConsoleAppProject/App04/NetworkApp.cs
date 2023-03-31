using ConsoleAppProject.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppProject.App04
{   /// <summary>
    /// This class handles the main command line interface for the app.
    /// It uses different methods to handle the inputs and calls the appropriate
    /// method from the NewsFeed class.
    /// </summary>
    public class NetworkApp
    {
        //This creates an object of the NewsFeed class.
        private NewsFeed news = new NewsFeed();

        public NewsFeed NewsFeed
        {
            get => default;
            set
            {
            }
        }

        /// <summary>
        /// This is first method that is called from the program.cs main method.
        /// First it prints the main menu choices and then prompts the user to input 
        /// a choice between 1-8 and calls the appropriate function.
        /// It uses an infinite while loop to keep printing the menu until the user chooses to quit.
        /// </summary>
        public void DisplayMenu()
        {
            string[] choices = new string[]
            {
                "Post Message","Post Image","Remove Post",
                "Display All Posts", "Display By Author",
                "Add Comment",
                "Like Or Dislike Posts","Quit"
            };

            bool WantToQuit = false;

            do
            {
                ConsoleHelper.OutputHeading("Joy's News Daily ");

                int choice = ConsoleHelper.SelectChoice(choices);
                Console.WriteLine("--------------------------------------------------");

                switch (choice)
                {
                    case 1: PostMessage(); break;
                    case 2: PostImage(); break;
                    case 3: RemovePost(); break;
                    case 4: DisplayAll(); break;
                    case 5: DisplayByAuthor(); break;
                    case 6: AddComment(); break;
                    case 7: LikeOrDislikePosts(); break;
                    case 8: WantToQuit = true; break;
                }

            } while (!WantToQuit);
        }

        /// <summary>
        /// This method is called when the users decides to like or dislike a post it prints the title
        /// and then prompts the user to enter a post id. After the user enters an PostId the input is passed to 
        /// the NewsFeed function.
        /// </summary>
        private void LikeOrDislikePosts()
        {
            ConsoleHelper.OutputTitle($"Liking / Dislike A Post");
            int id = (int)ConsoleHelper.InputNumber("Please enter the post id > ",
                1, Post.GetNumberOfPosts());

            news.LikeOrDislikePosts(id);
        }

        /// <summary>
        /// This functoin is called when a user wants to add a comment to a paticular post. 
        /// First it prints a title and then prompts the user to enter a PostId. 
        /// The PostID is passed to the addComment function in the NewsFeed class.
        /// </summary>
        private void AddComment()
        {
            ConsoleHelper.OutputTitle($"Adding a Comment");
            int id = (int)ConsoleHelper.InputNumber("Please enter the post id > ",
                1, Post.GetNumberOfPosts());

            news.AddComment(id);
        }

        /// <summary>
        /// This function is called when the user wants to display a post by a paticular 
        /// author. After displaying the title it prompts the user to enter the name 
        /// of the author they want to be searched. This string input is then passed to 
        /// the AuthorDisplay function in the NewsFeed.
        /// </summary>
        private void DisplayByAuthor()
        {
            ConsoleHelper.OutputTitle($"Displaying by Author");
            Console.Write("Please Enter Author > ");
            string authorname = Console.ReadLine();
            news.AuthorDisplay(authorname);
        }

        /// <summary>
        /// This method is called when the user wants to remove a paticular post.
        /// it does this by prompting the user to enter a PostID. This int is then 
        /// passes it to the RemovePost method in the NewsFeed class.
        /// </summary>
        private void RemovePost()
        {
            ConsoleHelper.OutputTitle($"Removing a Post");
            int id = (int)ConsoleHelper.InputNumber("Please enter the post id > ", 
                1, Post.GetNumberOfPosts());

            news.RemovePost(id);
        }
            
        /// <summary>
        /// This method is called when the user decides to post a Image Post.
        /// First it takes three inputs. The Author name, the Image filename and the Image caption.
        /// then it creates a new object for the new post using the PhotoPost class and is passed to 
        /// the AddPhotoPost method in the NewsFeed class which stores it in thre posts list.
        /// After this it displays the new post and lets the user know that they have created a new post.
        /// </summary>
        private void PostImage()
        {
            ConsoleHelper.OutputTitle("Posting an Image/Photo");
            string author = InputName();

            Console.Write("Please enter your image filename>"); 
            string filename = Console.ReadLine();

            Console.Write("Please enter your image caption>"); 
            string caption = Console.ReadLine();

            PhotoPost post = new PhotoPost(author, filename, caption); 
            news.AddPhotoPost(post);

            ConsoleHelper.OutputTitle("You have just posted this image:");
            post.Display();
        }

        /// <summary>
        /// This function is called when the user wants to print all the posts.
        /// It does this by using the Display() function in NewsFeed Class.
        /// </summary>
        private void DisplayAll()
        {
            news.Display();
        }

       /// <summary>
       /// This method is called when the user decides to post a new simple message post. 
       /// It does this by prompting the user to enter the Author name, A message. Then 
       /// it creates a new post object using the MessagePost class and passes it to the 
       /// AddMessagePost in the NewsFeed class which adds it to the posts list. 
       /// After this it lets the user know that the message is posted by displaying the message
       /// on screen.
       /// </summary>
        private void PostMessage()
        {
            ConsoleHelper.OutputTitle("Posting an Message");
            string author = InputName();

            Console.Write("Please enter your message > "); 
            string message = Console.ReadLine();

            MessagePost post = new MessagePost(author, message);
            news.AddMessagePost(post);

            ConsoleHelper.OutputTitle(" You have just posted this message: ");
            post.Display();
        }

        /// <summary>
        /// This function is called when the user is prompted to enter author name.
        /// It reads the user input and stores it in the author variable and returns it.
        /// This is done to avoide code duplication.
        /// </summary>
        /// <returns>author</returns>
        private string InputName()
        {
            Console.Write("Please Enter Your Name> ");
            string author = Console.ReadLine();
            return author;
        }

    }

}