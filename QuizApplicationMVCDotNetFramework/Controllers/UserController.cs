using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuizApplicationMVCDotNetFramework.BO;
using QuizApplicationMVCDotNetFramework.DAL;

namespace QuizApplicationMVCDotNetFramework.Controllers
{
    public class UserController : Controller
    {
        private readonly UserDAL _UserDAL;

        public UserController()
        {
            _UserDAL = new UserDAL();

        }
        public ActionResult CreateUser()
        {
            return View(new UserBO());
        }


        [HttpPost] //post data from ui to server
        public ActionResult CreateUser(UserBO user)
        {
            if (!string.IsNullOrEmpty(user.FirstName) && !string.IsNullOrEmpty(user.LastName) && !string.IsNullOrEmpty(user.Email))
            {
                user.UserGuid = Convert.ToString(Guid.NewGuid());
                Session["usersessionid"] = Convert.ToString(user.UserGuid);
                _UserDAL.CreateUser(user);
                return RedirectToAction("GetQuiz", "Quiz"); //redirect to quiz page
            }
            //new user or existing user. 
            //or check if email exists, generate same user guid and assign it to the session.
            else
            {
                ViewBag.ValidationError = "Please Fill in First Name, Last Name & Email Id.";
            }
            return View(new UserBO());

        }

    }
}