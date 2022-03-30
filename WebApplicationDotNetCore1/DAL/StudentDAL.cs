using WebApplicationDotNetCore1.BO;
using WebApplicationDotNetCore1.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationDotNetCore1.DAL
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
                    DateofBirth=student.DateOfBirth
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
        }*/

        public bool DeleteStudent(int Id)
        {
            try
            {
                var student = _db.Student1.Where(x => x.Id==Id);
                _db.Student1.RemoveRange(student);
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

        public StudentBO GetStudentbyId(int Id)
        {
            var student = _db.Student1.Where(r => r.Id==Id).Select(x => new StudentBO
            {
                Id = x.Id, //get the id
                FN = x.FirstName,
                LN = x.LastName,
                RollNo = x.RollNo,
                Marks = x.Marks,
                BranchId = x.Branch.Id,
                Branch=x.Branch.Name,
                DateOfBirth= x.DateofBirth,
            }).FirstOrDefault();

            return student;
        }

        public List<StudentBO> GetAllStudents()
        {
            var list = _db.Student1.Select(x => new StudentBO
            {
                Id = x.Id, //fetch the id
                FN = x.FirstName,
                LN= x.LastName,
                RollNo = x.RollNo,
                Marks = x.Marks,
                BranchId = x.Branch.Id,
                Branch= x.Branch.Name,
                DateOfBirth = x.DateofBirth,
            }).ToList();

            return list;
        }


        public bool UpdateStudentbyId(StudentBO student)
        {
            try
            {
                var st = _db.Student1.Where(x => x.Id == student.Id).FirstOrDefault();
                st.FirstName = student.FN;
                st.LastName = student.LN;
                st.Marks = (int?)student.Marks;
                st.RollNo = student.RollNo;
                st.DateofBirth=student.DateOfBirth;
                _db.Student1.Add(st);
                _db.Entry(st).State = EntityState.Modified;
                if (student.BranchId.HasValue)
                {
                    var branch = _db.Branch.Find(student.BranchId); //finding record from db using primary key search
                    branch.Name = student.Branch; //change it to name
                    _db.Branch.Add(branch); //add it to the table
                    _db.Entry(branch).State = EntityState.Modified; //
                }
                else
                {
                    if (!string.IsNullOrEmpty(student.Branch))
                    {
                        var newbranch = _db.Branch.Add(new Branch { Name = student.Branch });
                        st.Branch = newbranch.Entity;
                    }
                }
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


        /*public int GetStudentCount()
        {

        }*/
    }
}

