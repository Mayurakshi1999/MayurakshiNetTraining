using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationDotNetFramework1.BO;
using WebApplicationDotNetFramework1.DAL;

namespace WebApplicationDotNetFramework1.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        private readonly StudentDAL _studentDAL;
        public StudentController()
        {
            _studentDAL = new StudentDAL();
        }
        // GET: Student
        public ActionResult GetAllStudents()
        {
            var students = _studentDAL.GetAllStudents();
            return View("~/Views/Student/Students.cshtml", students);
        }
        public ActionResult GetAllStudentsJsonView()
        {
            return View("~/Views/Student/StudentJsonView.cshtml");
        }
        public JsonResult GetAllStudentsJSON()
        {
            var students = _studentDAL.GetStudents();
            return Json(students, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult CreateStudent(StudentBO student)
        {
            if (!String.IsNullOrEmpty(student.FN) && !String.IsNullOrEmpty(student.LN) && student.RollNo != null)
            {
                _studentDAL.CreateStudent(student);
                return RedirectToAction("GetAllStudents");
            }
            else
            {
                ViewBag.ValidationError = "Please fill First Name, Last Name & Roll No."; 
            }
            return View(new StudentBO()); 
        }
        [HttpGet]
        public ActionResult CreateStudent()
        {

            return View(new StudentBO());
        }
        [HttpGet]
        public ActionResult CreateStudentAjax()
        {
            return View(new StudentBO());
        }
        [HttpPost]
        public JsonResult CreateStudentAjax(StudentBO student)
        {
            var error = string.Empty;
            if (!String.IsNullOrEmpty(student.FN) && !String.IsNullOrEmpty(student.LN) && student.RollNo != null)
            {
                var success = _studentDAL.CreateStudent(student);
                return Json(new {Success=true,Error=error}, JsonRequestBehavior.AllowGet);
            }
            else
            {
                error = "Please fill First Name, Last Name, Roll No";
                return Json(new { Success = false, Error = error }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult EditStudent(int Id)
        {
            var student = _studentDAL.GetStudentbyId(Id);
            return View(student);
        }
        [HttpPost]
        public ActionResult EditStudent(StudentBO student)
        {
            if (!String.IsNullOrEmpty(student.FN) && !String.IsNullOrEmpty(student.LN) && student.RollNo != null)
            {
                _studentDAL.UpdateStudentbyId(student);
                return RedirectToAction("GetAllStudents");
            }
            else
            {
                ViewBag.ValidationError = "Please fill First Name, Last Name, Roll No";
            }
            return View(new StudentBO());
        }


        public ActionResult DeleteStudent(int Id)
        {
            StudentDAL student = new StudentDAL();
            student.DeleteStudent(Id);
            return RedirectToAction("GetAllStudents");
        }
            
    }
}