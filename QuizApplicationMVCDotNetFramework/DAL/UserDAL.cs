using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizApplicationMVCDotNetFramework.DB;
using QuizApplicationMVCDotNetFramework.BO;

namespace QuizApplicationMVCDotNetFramework.DAL
{
    public class UserDAL
    {
        private readonly studentEntities1 _db;
        public UserDAL()
        {
            _db = new studentEntities1();
        }
        public int CreateUser(UserBO user)
        {

            var success = true;
            int id = 0;
            try
            {
                _db.Usertable.Add(new Usertable
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Userguid = user.UserGuid,

                });
                _db.SaveChanges();
                id = _db.Usertable.Max(u => u.Userid);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                success = false;
                throw;
            }
            return id;
        }
        //public bool CalculateMarks()
        //{



        //}

    }
}