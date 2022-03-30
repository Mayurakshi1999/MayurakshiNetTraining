using ConsoleAppEntityFrameworkDotNetCore.BO;
using ConsoleAppEntityFrameworkDotNetCore.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppEntityFrameworkDotNetCore
{
    public class Program
    {
        static void Main(string[] args)
        {
            var dal = new StudentDAL();

            /*dal.DeleteStudent(785);
            var studentList = new List<Student>();
            studentList = dal.GetStudents();
            dal.CreateStudentWithSP(new Student
            {
                FN = "Mary",
                LN = "Paul",
                RollNo = 786,
                Marks = 104.12
            });

            var s = dal.GetStudentByRollNumber(1234);*/
            var studentList = new List<BO.StudentBO>();
            /*var x = dal.UpdateStudent(new Student
            {
                FN = "Harry",
                LN = "Paul",
                RollNo = 785,
                Marks = 104.12
            });
            x = dal.CreateStudent(new Student
            {
                FN = "Mary",
                LN = "Paul",
                RollNo = 786,
                Marks = 104.12
            });*/
            int size = 0;
            for (; ; )
            {
                Console.WriteLine("1. Enter inputs");
                Console.WriteLine("2. Print Data");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    Console.WriteLine("Number of students");

                    var i = Convert.ToInt32(Console.ReadLine());
                    size = i;

                    if (i != 0)
                    {
                        for (int j = 0; j < i; j++)
                        {
                            var st = new BO.StudentBO();
                            Console.WriteLine($"Enter following details for Student {j+1}");

                            Console.WriteLine("Enter first name");
                            st.FN = Console.ReadLine();

                            Console.WriteLine("Enter last name");
                            st.LN = Console.ReadLine();

                            Console.WriteLine("Enter rollno");
                            st.RollNo = int.Parse(Console.ReadLine());

                            Console.WriteLine("Enter Marks");
                            st.Marks = double.Parse(Console.ReadLine());

                            dal.CreateStudent(st);
                        }

                    }
                    else
                    {
                        Console.WriteLine("invalid input");
                    }
                }
                else if (input == "2")
                {
                    studentList = dal.GetStudents();
                    foreach (var st in studentList)
                    {
                        Console.WriteLine($"FirstName-{st.FN}");
                        Console.WriteLine($"LastName-{st.LN}");
                        Console.WriteLine($"Rollnum-{st.RollNo}");
                        Console.WriteLine($"Marks-{st.Marks}");
                    }

                }
                else
                {
                    Console.WriteLine("Invalid input");
                    break;
                }
            }
        }

    }
}