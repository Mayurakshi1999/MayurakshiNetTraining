using BO;
using DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL
{
    public class StudentDAL
    {
        private readonly studentEntities _db;
        public StudentDAL()
        {
            _db = new studentEntities();
        }
        public StudentInfoResponse CreateStudent(StudentInfoRequest request)
        {
            StudentInfoResponse student = new StudentInfoResponse();
            try
            {
                _db.Student1.Add(new Student1
                {
                    FirstName= request.Body.FName,
                    LastName= request.Body.LName,
                    RollNo = request.Body.RollNo,
                    Marks = request.Body.Marks

                });
                _db.SaveChanges();
                student.Header = new HeaderInfo
                {
                    CallStatus = "Success",
                    TransactionID = request?.Header?.TransactionID
                };

                

            }
            catch(Exception ex)
            {
                student.Header = new HeaderInfo
                {
                    CallStatus = "Error",
                    TransactionID = request?.Header?.TransactionID

                };

            }
            return student;
        }
        public StudentInfoResponse GetStudentById(StudentInfoRequest request)
        {
            StudentInfoResponse student = new StudentInfoResponse();
            try
            {
                var st = _db.Student1.Where(x => x.Id == request.Body.Id).FirstOrDefault();


                student.Header = new HeaderInfo
                {
                    CallStatus = "Success",
                    TransactionID = request?.Header?.TransactionID
                };
            }
            catch (Exception ex)
            {
                student.Header = new HeaderInfo
                {
                    CallStatus = "Error",
                    TransactionID = request?.Header?.TransactionID

                };

            }
            return student;
        }
        public StudentInfoResponse UpdateStudent(StudentInfoRequest request)
        {
            StudentInfoResponse student = new StudentInfoResponse();
            try
            {

                var st = _db.Student1.Where(x => x.RollNo == request.Body.RollNo).FirstOrDefault();
                st.FirstName = request.Body.FName;
                st.LastName = request.Body.LName;
                st.Marks = (int?)request.Body.Marks;
                _db.Student1.Add(st);
                _db.Entry(st).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                student.Header = new HeaderInfo
                {
                    CallStatus = "Success",
                    TransactionID = request?.Header?.TransactionID
                };
            }
            catch (Exception ex)
            {
                student.Header = new HeaderInfo
                {
                    CallStatus = "Error",
                    TransactionID = request?.Header?.TransactionID

                };

            }
            return student;
        }
        public StudentInfoResponse DeleteStudent(StudentInfoRequest request)
        {
            StudentInfoResponse student = new StudentInfoResponse();

            try
            {
                var st = _db.Student1.Where(x => x.RollNo == request.Body.RollNo);
                _db.Student1.RemoveRange(st);
                _db.SaveChanges();

                student.Header = new HeaderInfo
                {
                    CallStatus = "Success",
                    TransactionID = request?.Header?.TransactionID
                };
            }
            catch (Exception ex)
            {
                student.Header = new HeaderInfo
                {
                    CallStatus = "Error",
                    TransactionID = request?.Header?.TransactionID

                };

            }
            return student;

        }
        
    }
}