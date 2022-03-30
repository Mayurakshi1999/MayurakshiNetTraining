using ConsoleAppEntityFrameworkDotNetCore.BO;
using ConsoleAppEntityFrameworkDotNetCore.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEntityFrameworkDotNetCore.DAL
{
    public class StudentDAL
    {
        private readonly TrainingDbContext _db;//wrapper of database
        public StudentDAL()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configuration.GetConnectionString("DBConnectionString");
            var dbContextOptions = new DbContextOptionsBuilder<TrainingDbContext>().UseSqlServer(connectionString).Options;
            _db = new TrainingDbContext(dbContextOptions);
        }
        public bool CreateStudent(StudentBO student)
        {
            var success = true;
            try
            {
                var branch = student.Branch;
                int? branchId = null;
                if (!string.IsNullOrEmpty(branch))
                {
                    branchId = _db.Branch.Where(x => x.Name == branch).FirstOrDefault()?.Id;
                    if (branchId == null)
                    {
                        var createBranch = _db.Branch.Add(new Branch { Name = branch });
                        _db.SaveChanges();
                        branchId = createBranch.Entity.Id;
                    }
                }

                _db.Student1.Add(new Student1
                {
                    FirstName = student.FN,
                    LastName = student.LN,
                    RollNo = student.RollNo,
                    Marks = (int?)student.Marks,
                    BranchId=branchId,
                });
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                success = false;
                throw;
            }
            return success;
        }

        /*public bool CreateStudentWithSP(StudentBO student)
        {
            try
            {
                var result = _db.Database.ExecuteSqlInterpolated($"CreateStudent @firstname={student.FirstName}, @lastname={student.LastName}, @rollno={student.Roll}, @marks={student.MarksSecured}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
                return false;
            }
            return true;
        }

        public bool DeleteStudent(int rollNumber)
        {
            try
            {
                var students = _db.Student1.Where(x => x.RollNumber == rollNumber);
                _db.Student1.RemoveRange(students);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
                return false;
            }
            return true;
        }

        public StudentBO GetStudentByRollNumber(int rollNo)
        {
            var student = _db.Student1.Where(r => r.RollNumber == rollNo).Select(x => new StudentBO
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Roll = x.RollNumber,
                MarksSecured = x.Marks,
                Branch = x.Branch.Name
            }).FirstOrDefault();

            return student;
        }*/

        public List<StudentBO> GetStudents()
        {
            var list = _db.Student1.Select(x => new StudentBO
            {
                FN = x.FirstName,
                LN = x.LastName,
                RollNo = x.RollNo,
                Marks = x.Marks,
                Branch = x.FirstName
            }).ToList();
            return list;
        }

        /*public bool UpdateStudent(StudentBO student)
        {
            try
            {
                var st = _db.Student1.Where(x => x.RollNumber == student.Roll).FirstOrDefault();
                st.FirstName = student.FirstName;
                st.LastName = student.LastName;
                st.Marks = (decimal?)student.MarksSecured;
                _db.Student1.Add(st);
                _db.Entry(st).State = EntityState.Modified;
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
                return false;
            }
            return true;
        }*/


        /*public int GetStudentCount()
        {

        }*/
    }
}

