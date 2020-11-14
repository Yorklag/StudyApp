/*
 * Programing 101 study program by Michael Tendy
 * 
 * Layout inspired by assignment page
 * termsort line from LukeH on StackOverflow
 * Array sorting method found at https://www.tutorialsteacher.com/articles/sort-object-array-by-specific-property-in-csharp
 * ascii art gotten through https://patorjk.com/software/taag/
 * 
 * help with creation of response list in player object and help with NullReferenceException caused by lack of inistalization of said list provided by Steve Tendy
 */
using System;
using System.Xml;

namespace StudyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console title and starting of game
            Console.Title = "Programing 101 study program by Michael Tendy";
            Session session = new Session();
            session.Start();
        }
    }
}
