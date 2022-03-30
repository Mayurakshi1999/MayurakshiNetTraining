using AspDotNetCoreWebApi.BO;

namespace AspDotNetCoreWebApi.DAL
{
    public interface IStudentDAL
    {
        IEnumerable<StudentBO> GetStudents();
        StudentBO GetStudent(int id);
        bool CreateStudent(StudentBO student);
        bool UpdateStudentbyId(StudentBO student);
        bool DeleteStudent(int Id);
    }
}
