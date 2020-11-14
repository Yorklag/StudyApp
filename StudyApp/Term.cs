using System;
using System.Collections.Generic;
using System.Text;

namespace StudyApp
{
    class Term
    {
        public string term { get; set; }
        public string definition { get; set; }
        public int randnum { get; set; }
        public int termnum { get; set; }
        public void ShowTerm()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"What is a(n) {term}\n");
            Console.ResetColor();
        }
    }
}
