using System.Collections.Generic;

namespace QuizApplicationMVCDotNetFramework.BO
{
    public class ResultsBO
    {
        private string _firstName;
        private string _lastName;
        private string _email;
        private int _marks;
        private int _totalMarks;
        private IEnumerable<AnswerBO> _answers;

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public int Marks
        {
            get { return _marks; }
            set { _marks = value; }
        }

        public IEnumerable<AnswerBO> Answers
        {
            get { return _answers; }
            set { _answers = value; }
        }

        public int TotalMarks
        {
            get { return _totalMarks; }
            set { _totalMarks = value; }
        }
    }
}