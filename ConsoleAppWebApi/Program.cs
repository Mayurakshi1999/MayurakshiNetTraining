// See https://aka.ms/new-console-template for more information
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

Console.WriteLine("Hello, World!");

var apiClient = new ApiClient("https://localhost:7288/");
var apiInstance = new StudentsApi(apiClient);

try
{
    int x = 1;
    while (x>0)
    {
        Console.WriteLine("What function do you want to perform:");
        Console.WriteLine("1. Display all students");
        Console.WriteLine("2. Find Student By Id");
        Console.WriteLine("3. Create Student");
        Console.WriteLine("4. Edit Student");
        Console.WriteLine("5. Delete Student");
        Console.WriteLine("Enter 0 to Exit");

        var p = Convert.ToInt32(Console.ReadLine());

        if (p == 1)
        {
            List<StudentBO> result = apiInstance.ApiStudentsGetAllStudentsGet();
            foreach (var val in result)
            {
                Console.WriteLine($"Entry No: {val?.Id}");
                Console.WriteLine($"FirstName: {val?.FirstName}");
                Console.WriteLine($"LastName: {val?.LastName}");
                Console.WriteLine($"RollNo: {val?.RollNo}");
                Console.WriteLine($"Marks: {val?.Marks}");
                Console.WriteLine($"Branch: {val?.BranchName}");
                Console.WriteLine(" ");
            }

        }
        else if (p == 2)
        {
            Console.WriteLine("Type the id");
            var student = apiInstance.ApiStudentsGetStudentbyIdGet(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine($"FirstName: {student?.FirstName}");
            Console.WriteLine($"LastName: {student?.LastName}");
            Console.WriteLine($"RollNo: {student?.RollNo}");
            Console.WriteLine($"Marks: {student?.Marks}");
            Console.WriteLine($"Branch: {student?.BranchName}");
            Console.WriteLine(" ");
        }
        else if (p == 3)
        {
            Console.WriteLine("Type the student details");
            var st = new StudentBO();

            Console.WriteLine("Enter Id");
            st.Id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter first name");
            st.FirstName = Console.ReadLine();

            Console.WriteLine("Enter last name");
            st.LastName = Console.ReadLine();

            Console.WriteLine("Enter rollno");
            st.RollNo = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Marks");
            st.Marks = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter BranchId");
            st.BranchId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter BranchName");
            st.BranchName = Console.ReadLine();

            apiInstance.ApiStudentsCreateStudentPost(st);
            Console.WriteLine(" ");


        }
        else if (p == 4)
        {
            Console.WriteLine("Enter the Id of the Student whose details you want to edit");
            var student = apiInstance.ApiStudentsGetStudentbyIdGet(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine($"FirstName: {student?.FirstName}");
            Console.WriteLine($"LastName: {student?.LastName}");
            Console.WriteLine($"RollNo: {student?.RollNo}");
            Console.WriteLine($"Marks: {student?.Marks}");
            Console.WriteLine($"Branch: {student?.BranchName}");

            Console.WriteLine("Enter the new First Name");
            var newFN = Console.ReadLine();
            student.FirstName = newFN;

            Console.WriteLine("Enter the new Last Name");
            var newLN = Console.ReadLine();
            student.LastName = newLN;

            Console.WriteLine("Enter the new Roll No");
            var newRN = Convert.ToInt32(Console.ReadLine());
            student.RollNo = newRN;

            Console.WriteLine("Enter the new Marks");
            var newM = Convert.ToInt32(Console.ReadLine());
            student.Marks = newM;

            Console.WriteLine("Enter the new Branch Name");
            var newBN = Console.ReadLine();
            student.BranchName = newBN;

            apiInstance.ApiStudentsEditStudentPost(student);
            Console.WriteLine(" ");

        }
        else if (p==5)
        {
            try
            {
                Console.WriteLine("Enter the Id of the Student you want to delete");
                apiInstance.ApiStudentsDeleteStudentDelete(Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine("Student Deleted Successfully");
                Console.WriteLine(" ");

            }
            catch (Exception ex)
            {
                Console.WriteLine("+Exception when calling StudentApi.ApiStudentsDeleteStudentDelete: " + ex.Message);
            }
        }
        else if ( p == 0)
        {
            break;
        }
        else
        {
            Console.WriteLine("Invalid Input");
        }


        x++;

    
    }

        
}
catch (Exception e)
{
    Console.WriteLine("Exception when calling AspDotNetCoreWebApi.ConsoleAppWebApi: " + e.Message);

}

