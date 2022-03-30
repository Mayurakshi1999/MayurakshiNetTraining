using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using WebApplicationDotNetCore1.BO;
using WebApplicationDotNetCore1.DAL;

namespace WebApplicationDotNetCore.Controllers
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