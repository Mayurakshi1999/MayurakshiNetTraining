using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizApplicationMVCDotNetFramework.BO
{
    public class QuizBO
    {
        public int Qid { get; set; }
        public string Question { get; set; }


        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public string CorrectAns { get; set; }
        public string Option { get; set; }

        public int Ansid { get; set; }
        public string Answer { get; set; }
        public int Userid { get; set; }
        public string Userguid { get; set; }

        //public Dictionary<int, string> Options { get; set; }
    }
}