using AspDotNetCoreWebApi.BO;
using AspDotNetCoreWebApi.DB;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AspDotNetCoreWebApi.DAL
{
    public class StudentDAL : IStudentDAL
    {
        private readonly TrainingDbContext _db;
        private readonly ILogger<StudentDAL> _logger;
        public StudentDAL(TrainingDbContext db, ILogger<StudentDAL> logger)
        {
            _db= db;
            _logger= logger;
        }
        public bool CreateStudent(StudentBO student)
        {
            var success = true;
            try
            {
                var branch = student.BranchName;
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
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    RollNo = student.RollNo,
                    Marks = (int?)student.Marks,
                    BranchId=branchId
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
        public bool UpdateStudentbyId(StudentBO student)
        {
            try
            {
                var st = _db.Student1.Where(x => x.Id == student.Id).FirstOrDefault();
                st.FirstName = student.FirstName;
                st.LastName = student.LastName;
                st.Marks = (int?)student.Marks;
                st.RollNo = student.RollNo;
                _db.Student1.Add(st);
                _db.Entry(st).State = EntityState.Modified;
                if (student.BranchId.HasValue && student.BranchId>0)
                {
                    var branch = _db.Branch.Find(student.BranchId); //finding record from db using primary key search
                    branch.Name = student.BranchName; //change it to name
                    _db.Branch.Add(branch); //add it to the table
                    _db.Entry(branch).State = EntityState.Modified; //
                }
                else
                {
                    if (!string.IsNullOrEmpty(student.BranchName))
                    {
                        var newbranch = _db.Branch.Add(new Branch { Name = student.BranchName });
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
        public IEnumerable<StudentBO> GetStudents()
        {
            return _db.Student1.Select(x => new StudentBO
            {
                Id=x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                RollNo = x.RollNo,
                Marks = x.Marks,
                BranchId = x.BranchId,
                BranchName = x.Branch.Name
            }).ToList();
        }
        public StudentBO GetStudent(int id)
        {
            return _db.Student1.Where(x =>x.Id==id).Select(x => new StudentBO
            {
                Id=x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                RollNo = x.RollNo,
                Marks = x.Marks,
                BranchId = x.BranchId,
                BranchName = x.Branch.Name
            }).FirstOrDefault();
        }
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
    }
}
