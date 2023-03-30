using ConsoleAppProject.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppProject.App04
{
    public class NetworkApp
    {
        private NewsFeed news = new NewsFeed();
        public void DisplayMenu()
        {
            ConsoleHelper.OutputHeading("Joy's News Daily ");



            string[] choices = new string[]
            {
                "Post Message","Post Image","Remove Post",
                "Display All Posts", "Display By Author",
                "Display By Date","Add Comment",
                "Like Or Dislike Posts","Quit"
            };

            bool WantToQuit = false;

            do
            {

                int choice = ConsoleHelper.SelectChoice(choices);
                Console.WriteLine("--------------------------------------------------");

                switch (choice)
                {
                    case 1: PostMessage(); break;
                    case 2: PostImage(); break;
                    case 3: RemovePost(); break;
                    case 4: DisplayAll(); break;
                    case 5: DisplayByAuthor(); break;
                    case 6: DisplayByDate(); break;
                    case 7: AddComment(); break;
                    case 8: LikeOrDislikePosts(); break;
                    case 9: WantToQuit = true; break;
                }

            } while (!WantToQuit);
        }

        private void LikeOrDislikePosts()
        {
            ConsoleHelper.OutputTitle($"      Liking A Post");
            int id = (int)ConsoleHelper.InputNumber("Please enter the post id > ",
                1, Post.GetNumberOfPosts());

            news.LikeOrDislikePosts(id);
        }

        private void AddComment()
        {
            ConsoleHelper.OutputTitle($"      Adding a Comment");
            int id = (int)ConsoleHelper.InputNumber("Please enter the post id > ",
                1, Post.GetNumberOfPosts());

            news.AddComment(id);
        }

        private void DisplayByDate()
        {
            throw new NotImplementedException();
        }

        private void DisplayByAuthor()
        {
            ConsoleHelper.OutputTitle($"      Displaying by Author");
            Console.Write("Please Enter Author > ");
            string authorname = Console.ReadLine();
            news.AuthorDisplay(authorname);
        }

        private void RemovePost()
        {
            ConsoleHelper.OutputTitle($"      Removing a Post");
            int id = (int)ConsoleHelper.InputNumber(" Please enter the post id > ", 
                1, Post.GetNumberOfPosts());

            news.RemovePost(id);
        }

        private void PostImage()
        {
            ConsoleHelper.OutputTitle("Posting an Image/Photo");
            string author = InputName();

            Console.Write(" Please enter your image filename>"); 
            string filename = Console.ReadLine();

            Console.Write(" Please enter your image caption>"); 
            string caption = Console.ReadLine();

            PhotoPost post = new PhotoPost(author, filename, caption); 
            news.AddPhotoPost(post);

            ConsoleHelper.OutputTitle("You have just posted this image:");
            post.Display();
        }

        private void DisplayAll()
        {
            news.Display();
        }

        //private void PostPhoto()
        //{
        //    throw new NotImplementedException();
        //}

        private void PostMessage()
        {
            ConsoleHelper.OutputTitle("Posting an Message");
            string author = InputName();

            Console.Write(" Please enter your message > "); 
            string message = Console.ReadLine();

            MessagePost post = new MessagePost(author, message);
            news.AddMessagePost(post);

            ConsoleHelper.OutputTitle(" You have just posted this message: ");
            post.Display();
        }


        private string InputName()
        {
            Console.Write("Please Enter Your Name> ");
            string author = Console.ReadLine();
            return author;
        }

    }

}