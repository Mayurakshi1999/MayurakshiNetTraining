using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizApplicationMVCDotNetFramework.BO
{
    public class AnswerBO
    {
        private int _userid;
        private int _qid;
        private string _question;
        private string _answer;
        private string _chosenans;

        public int UserId
        {
            get { return _userid; }
            set { _userid = value; }
        }

        public int QId
        {
            get { return _qid; }
            set { _qid = value; }
        }
        public String Question
        {
            get { return _question; }
            set { _question = value; }
        }
        public string Answer
        {
            get { return _answer; }
            set { _answer = value; }
        }
        public string ChosenAnswer
        {
            get { return _chosenans; }
            set { _chosenans = value; }
        }


    }
}