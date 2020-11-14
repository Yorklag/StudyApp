using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace StudyApp
{
    class Player
    {
        public string Name { get; set; }
        public int PlayerNumber { get; set; }
        public List<Response> Responses { get; set; }
        public Player()
        {
            Responses = new List<Response>();
        }
    }
}
