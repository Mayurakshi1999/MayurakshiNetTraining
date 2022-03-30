using BO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServiceApplication
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class StudentService : IStudentervice
    {
        private readonly StudentDAL _studentDAL;
        public StudentService()
        {
            _studentDAL = new StudentDAL();
        }
        public StudentInfoResponse CreateStudent(StudentInfoRequest request)
        {
            var response = _studentDAL.CreateStudent(request);
            return response;
        }
        public StudentInfoResponse GetStudentById(StudentInfoRequest request)
        {
            var response = _studentDAL.GetStudentById(request);
            return response;
        }
        public StudentInfoResponse UpdateStudent(StudentInfoRequest request)
        {
            var response = _studentDAL.UpdateStudent(request);
            return response;
        }

        public StudentInfoResponse DeleteStudent(StudentInfoRequest request)
        {
            var response = _studentDAL.DeleteStudent(request);
            return response;
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public string Welcome()
        {
            return "Welcome to WCF coding";
        }
    }
}
