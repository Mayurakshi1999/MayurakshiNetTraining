using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuizApplicationMVCDotNetFramework.BO;
using QuizApplicationMVCDotNetFramework.DAL;


namespace QuizApplicationMVCDotNetFramework.Controllers
{

    public class QuizController : Controller
    {
        // GET: Quiz
        public ActionResult Index()
        {
            return View();
        }
        private readonly QuizDAL _quizDAL;
        public QuizController()
        {
            _quizDAL = new QuizDAL();
        }

        // GET: Demo
        [HttpGet]
        public ActionResult GetQuiz(int Qid = 1) //get the questions from DB
        {

            var quiz = _quizDAL.GetQuiz(Qid);
            return View("~/Views/Quiz/GetQuiz.cshtml", quiz);

        
        }
        [HttpPost]
        public ActionResult GetQuiz(QuizBO quiz, string submit) //get the answers update them to DB
        {
            var questions = _quizDAL.GetQuiz();
            quiz.Userguid = Convert.ToString(Session["usersessionid"]);
            quiz.Userid = _quizDAL.GetUserId(quiz.Userguid);
            var ans2 = _quizDAL.GetAnswer(quiz);
            //increment to next question
            if (submit == "Next")
            {
                return RedirectToAction("GetQuiz", new { Qid = quiz.Qid + 1 });
            }
            //decrement to previous question
            else if (submit == "Previous")
            {
                return RedirectToAction("GetQuiz", new { Qid = quiz.Qid - 1 });
            }
            else
            {
                //return RedirectToAction("ShowResult");
                return RedirectToAction("ShowResultVM");
            }
        }
        [HttpGet]
        public ActionResult GetMarks()
        {
            //var question = _quizDAL.GetCorrectAns(1);
            return View("~/Views/Quiz/ResultPage.cshtml");
        }
        public ActionResult ShowResult()
        {
            var Userguid = Convert.ToString(Session["usersessionid"]);
            var Userid = _quizDAL.GetUserId(Userguid);
            IEnumerable<AnswerBO> result = _quizDAL.GetResult(Userid);
            return View("ShowResult", result);
        }

        public ActionResult ShowResultVM()
        {
            var Userguid = Convert.ToString(Session["usersessionid"]);
            var Userid = _quizDAL.GetUserId(Userguid);
            ResultsBO result = _quizDAL.GetResultVM(Userid);
            return View("ShowResultVM", result);
        }
        public ActionResult Test()
        {
            return View();
        }
    }
}




    
