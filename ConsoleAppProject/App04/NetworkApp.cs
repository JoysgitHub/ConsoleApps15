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
            ConsoleHelper.OutputHeading("      Joy's News Daily ");



            string[] choices = new string[]
            {
                "Add Message", "Add Photo", "Display All Posts", "Quit"
            };

            bool WantToQuit = false;

            do
            {

                int choice = ConsoleHelper.SelectChoice(choices);
                switch (choice)
                {
                    case 1: PostMessage(); break;
                    case 2: PostPhoto(); break;
                    case 3: DisplayAll(); break;
                    case 4: WantToQuit = true; break;
                }

            } while (!WantToQuit);
        }

        private void DisplayAll()
        {
            news.Display();
        }

        private void PostPhoto()
        {
            throw new NotImplementedException();
        }

        private void PostMessage()
        {
            throw new NotImplementedException();
        }
    }

}