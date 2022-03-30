using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizApplicationMVCDotNetFramework.BO
{
    public class UserBO
    {
        private int _UserId;
        private string _FirstName;
        private string _LastName;
        private string _Email;
        private int _Marks;
        private string _userguid;

        public int? UserId
        {
            get;

            set;
        }
        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }
        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        public String UserGuid
        {
            get { return _userguid; }
            set { _userguid = value; }
        }

        private String myVar;

        public String MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }

        //public int Marks
        //{
        //    get { return Marks; }
        //    set { _Marks = value; }
        //}

    }
}