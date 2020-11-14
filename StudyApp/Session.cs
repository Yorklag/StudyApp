using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;

namespace StudyApp
{
    class Session
    {
        public int NumPlayers { get; set; }
        public Player CurPlayer { get; set; }

        //I got tired of writing Console.ForegroundColor = ConsoleColor  and  Console.ResetColor()   so i made these 3 methods to make it faster
        public void green(string input)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(input);
            Console.ResetColor();
        }
        public void cyan(string input)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(input);
            Console.ResetColor();
        }
        public void yellow(string input)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(input);
            Console.ResetColor();
        }
        public void Start()
        {
            Console.WindowWidth = 185;
            Console.WindowHeight = 50;
            //ascii art gotten through https://patorjk.com/software/taag/
            Console.WriteLine(@"__/\\\\\\\\\\\\\\\___________________________________________________________________________________________________________________________________________/\\\________________        
 _\///////\\\/////___________________________________________________________________________________________________________________________________________\/\\\________________       
  _______\/\\\________/\\\__________________________________________________/\\\_______________________________________________/\\\___________________________\/\\\_____/\\\__/\\\_      
   _______\/\\\_______\///_____/\\\\\__/\\\\\_______/\\\\\\\\_____________/\\\\\\\\\\\_____/\\\\\_______________/\\\\\\\\\\__/\\\\\\\\\\\__/\\\____/\\\________\/\\\____\//\\\/\\\__     
    _______\/\\\________/\\\__/\\\///\\\\\///\\\___/\\\/////\\\___________\////\\\////____/\\\///\\\____________\/\\\//////__\////\\\////__\/\\\___\/\\\___/\\\\\\\\\_____\//\\\\\___    
     _______\/\\\_______\/\\\_\/\\\_\//\\\__\/\\\__/\\\\\\\\\\\_______________\/\\\_______/\\\__\//\\\___________\/\\\\\\\\\\____\/\\\______\/\\\___\/\\\__/\\\////\\\______\//\\\____   
      _______\/\\\_______\/\\\_\/\\\__\/\\\__\/\\\_\//\\///////________________\/\\\_/\\__\//\\\__/\\\____________\////////\\\____\/\\\_/\\__\/\\\___\/\\\_\/\\\__\/\\\___/\\_/\\\_____  
       _______\/\\\_______\/\\\_\/\\\__\/\\\__\/\\\__\//\\\\\\\\\\______________\//\\\\\____\///\\\\\/______________/\\\\\\\\\\____\//\\\\\___\//\\\\\\\\\__\//\\\\\\\/\\_\//\\\\/______ 
        _______\///________\///__\///___\///___\///____\//////////________________\/////_______\/////_______________\//////////______\/////_____\/////////____\///////\//___\////________


                                                                                       Press  any  key  to  begin");
            Console.ReadKey();
            Console.Clear();
            NumPlayers = 0;
            Random rnd = new Random();
            List<Player> players = new List<Player>();
            Console.WriteLine("How many players will there be in this study session? Please input a positive whole number.");
            //asks for how many players will be playing the game and forces them to input a positive integer
            while (NumPlayers < 1) {
                try
                {
                    NumPlayers = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Please put in a positive whole number");
                }
            }
            //makes as many players as were indicated above and gets the name for each player while assining them a playernumber for future reference.
            Console.Clear();
            for (int i = 0; i < NumPlayers; i++)
            {
                players.Add(new Player() { });
                players[i].PlayerNumber = i + 1;                
                // while the player's name string is empty it will repeated this section making you unable to enter in no name.
                // however you can still add in one space and it will accept that as a name.
                do
                {
                    Console.WriteLine($"Player{players[i].PlayerNumber} please input the name you would like to go by for the study session.");
                    players[i].Name = Console.ReadLine();
                } while (players[i].Name == "");
                Console.Clear();
                Console.WriteLine($"For this study session player{players[i].PlayerNumber} will go by the name {players[i].Name}\n\nPress any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
            
            //creates a list of terms and assigns the terms and answers leaving randnum, termnum, and response to be assigned later
            List<Term> terms = new List<Term>();
            terms.Add(new Term() { term = "Integer(int)", definition = "a whole number"});
            terms.Add(new Term() { term = "Double", definition = "a number with a possible decimal"});
            terms.Add(new Term() { term = "Keyword", definition = "a special word reserved by c# for specific uses"});
            terms.Add(new Term() { term = "Void", definition = "a keyword that makes a method return no values"});
            terms.Add(new Term() { term = "Class", definition = "a template for creating objects"});
            terms.Add(new Term() { term = "Array", definition = "a container storing a predifined number of elements" });
            terms.Add(new Term() { term = "While loop", definition = "will run portion of code for as long as condition is true" });
            terms.Add(new Term() { term = "For loop", definition = "will run portion of code a certain number of times" });
            terms.Add(new Term() { term = "Static", definition = "allows use without initalizing the object" });
            terms.Add(new Term() { term = "Public", definition = "makes something usable/accessable by anything in program" });
            terms.Add(new Term() { term = "Private", definition = "makes something usable/accessable only by the object it's a part of" });
            terms.Add(new Term() { term = "Conditional statement", definition = "a conditional statement returns true or false" });
            terms.Add(new Term() { term = "String", definition = "an element that represents text" });
            terms.Add(new Term() { term = "List", definition = "a container storing a changable number of elements" });
            terms.Add(new Term() { term = "Null", definition = "error definition not found" });
            // if there are more than one player it greets them with the word everyone. if there is only one player it greets them with their name
            string Greeting = "everyone";
            if(players.Count == 1)
            {
                Greeting = players[0].Name;
            }

            Console.WriteLine($"Welcome, {Greeting}, to a study session for c# programing terms. You will be tested on your knowledge and understanding of the terms below.\n\n");
            int termnumassignment = 1;

            // prints out each term and assigns it a number in order so we can sort it back to the same order later.
            foreach(Term t in terms)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"{t.term}, ");
                Console.ResetColor();
                t.termnum = termnumassignment++;
            }
            Console.WriteLine($"\nPress any key to continue with instructions");
            
            Console.ReadKey();
            //in order to randomise the order of the terms you are given i assign them each a random number 1 - 100 and sort them by that number.
            foreach(Term t in terms)
            {
                t.randnum = rnd.Next(100);
            }
            terms.Sort((x, y) => x.randnum.CompareTo(y.randnum));
            string hold = "";
            while (hold.ToLower() != "answer")
            {
                Console.Clear();
                Console.Write($"This study session will be multiple choice.\nEach ");
                cyan("term ");
                Console.Write($"will be given to you in a random order.\nYou will have as much time as you need to pick which");
                yellow("choise ");
                Console.Write($"you think matches the ");
                green("definition ");
                Console.Write($".\nAfter you ");
                yellow("answer");
                Console.Write(" all ");
                cyan("questions ");
                Console.Write("you will be shown ");
                cyan("the terms, ");
                green("their definitions, ");
                Console.Write("and ");
                yellow("your answer.");
                Console.Write($"\n\nwhen you feel you understand type the third word on the fourth line to continue\n");

                hold = Console.ReadLine();
            }
            foreach (Term t in terms)
            {
                //makes an array of 4 possible responses to pick from for multiple choice
                PossibleResponses[] possibleResponses = new PossibleResponses[4];
                //makes three of the answers random definions from any term and assigns a random number for randomising the order of responses
                for (int i = 0; i < possibleResponses.Length - 1; i++)
                {
                    possibleResponses[i] = new PossibleResponses() { Response = terms[rnd.Next(terms.Count)].definition, Randnum = rnd.Next(100) };
                }
                //makes the fourth answer the definition of the question and makes assaign a random number
                possibleResponses[3] = new PossibleResponses() { Response = t.definition, Randnum= rnd.Next(100) };
                //implimentation of array sort from https://www.tutorialsteacher.com/articles/sort-object-array-by-specific-property-in-csharp
                Array.Sort(possibleResponses, new ResponseComparer());
                //an array of strings to list out multiple choice options
                String[] letters = new String[4];
                letters[0] = "A";
                letters[1] = "B";
                letters[2] = "C";
                letters[3] = "D";
                foreach (Player p in players)
                {
                    Console.Clear();
                    Console.WriteLine($"{p.Name}");
                    //this will write the term to the console
                    t.ShowTerm();
                    //this will read the players definition and save it to the response variable of each term
                    Console.WriteLine("Type in the letter of the answer.");
                    
                    for (int i = 0; i < possibleResponses.Length; i++)
                    {
                        Console.WriteLine($"{letters[i]}) {possibleResponses[i].Response}");
                    }
                    ConsoleKey answer = Console.ReadKey().Key;
                    bool notAnswered = true;
                    while (notAnswered)
                    {
                        switch (answer)
                        {
                            //gets the letter of the answer you entered and saves that as your response for the term while saving to term number for matching up questions and answers
                            case ConsoleKey.A:
                                p.Responses.Add(new Response() { ResponseInput = possibleResponses[0].Response, ResponseNumber = t.termnum });
                                notAnswered = false;
                                break;
                            case ConsoleKey.B:
                                p.Responses.Add(new Response() { ResponseInput = possibleResponses[1].Response, ResponseNumber = t.termnum });
                                notAnswered = false;
                                break;
                            case ConsoleKey.C:
                                p.Responses.Add(new Response() { ResponseInput = possibleResponses[2].Response, ResponseNumber = t.termnum });
                                notAnswered = false;
                                break;
                            case ConsoleKey.D:
                                p.Responses.Add(new Response() { ResponseInput = possibleResponses[3].Response, ResponseNumber = t.termnum });
                                notAnswered = false;
                                break;
                            default:
                                answer = Console.ReadKey().Key;
                                break;
                        }
                    }
                    //p.Responses.Add(new Response() { ResponseInput = Console.ReadLine(), ResponseNumber = t.termnum });
                }
            }
            // sorts the list of terms to be back in order
            terms.Sort((x, y) => x.termnum.CompareTo(y.termnum));
            // sorts the list of responses for each player to be back in order
            foreach (Player p in players)
            {
                p.Responses.Sort((x, y) => x.ResponseNumber.CompareTo(y.ResponseNumber));
            }
            Console.Clear();
            Console.Write($"That was the last term you responded to. press any key to see ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("the term, ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("the definition, ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("and your answer.");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
            //writes to console the number of the term, the definition, and the response provided by each player.
            //if no response provided, it simply writes "no response" in a different color in order to separate it from actual answers
            //this allows for terms with the definition of "no response" and showing the difference between answers and empty responses
            foreach (Player p in players)
            {
                //makes 0 int to track the number of questions you got right
                int numRight = 0;
                Console.WriteLine($"These are the responses for {p.Name}");
                foreach (Term t in terms)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"{t.termnum}: ");
                    cyan($"{t.term}: ");
                    green($"{t.definition}: ");
                    //if you got the question right it displays it in yellow and increments the numRight variable, if you got it wrong it displays it in red
                    if (p.Responses[t.termnum-1].ResponseInput == t.definition)
                    {
                        yellow($"{p.Responses[t.termnum - 1].ResponseInput}\n");
                        Console.ResetColor();
                        numRight++;

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"{p.Responses[t.termnum - 1].ResponseInput}\n");
                        Console.ResetColor();
                    }
                }
                Console.WriteLine($"\nYou got {numRight} questions correct\n\n");
            }
            Console.WriteLine("After you are looking over your answers you can hit y to start all over again or hit any other key to close the program. thanks for studying.");
            //reads next key pressed by player and if that key is y it starts the whole program over again from the beginning
            var restart = Console.ReadKey();
            if(restart.Key == ConsoleKey.Y)
            {
                Console.Clear();
                Start();
            }




            



        }
    }
}
