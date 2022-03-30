using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationDotNetFramework1.BO
{
    public class StudentBO
    {
        private string _FN;
        private string _LN;
        private int? _rollno;
        private double? _marks;

        private DateTime? _dob;

        public string FN
        {
            get
            {
                return _FN;
            }
            set
            {
                _FN = value;
            }
        }

        public string LN
        {
            get
            {
                return _LN;
            }
            set
            {
                _LN = value;
            }
        }

        public int? RollNo
        {
            get
            {
                return _rollno;
            }
            set
            {
                _rollno = value;
            }
        }

        public double? Marks
        {
            get
            {
                return _marks;
            }
            set
            {
                _marks = value;
            }
        }

        public int Id { get; set; }

        public DateTime? DateOfBirth
        {
            get

            {
                return _dob;
            }
            set
            {
                _dob = value;
            }
        } //dd-MM-yyyy

        public string Branch { get; set; }
        public int? BranchId { get; set; }
    }
}
