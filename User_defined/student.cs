using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_defined
{
    public class student
    {
        private string _fristName;
        private string _lastName;
        private int _rollNumber;
        private double _marksSecured;

        public string FirstName
        {
            get
            {
                return _fristName;
            }
            set
            {
                _fristName = value;
            }
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
            }
        }
        public int RollNumber
        {
            get
            {
                return _rollNumber;
            }
            set
            {
                _rollNumber = value;
            }
        }
        public double MarksSecured
        {
            get
            { 
                return _marksSecured;
            }
            set
            {
                _marksSecured = value;
            }
        }



    }
}
