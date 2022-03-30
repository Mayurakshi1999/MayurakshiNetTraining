using ADO.NetConnection.BO;
using ADO.NetConnection.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ADO.NetConnection
{
    class Program
    {
        static void Main(string[] args)
        {
            var dal = new StudentDAL();

            //dal.DeleteStudent(785);
            var studentList = new List<Student>();
            studentList = dal.GetStudents();
            dal.CreateStudentWithSP(new Student
            {
                FN = "Mary",
                LN = "Paul",
                RollNo = 786,
                Marks = 104.12
            });

            var s = dal.GetStudentByRollNumber(1234);
            var x = dal.UpdateStudent(new Student
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
            });
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
                            var st = new Student();
                            Console.WriteLine($"Enter following details for Student {j+1}");
                            Console.WriteLine("Enter first name");
                            st.FN = Console.ReadLine();

                            Console.WriteLine("Enter last name");
                            st.LN = Console.ReadLine();

                            Console.WriteLine("Enter rollno");
                            st.RollNo = int.Parse(Console.ReadLine());

                            Console.WriteLine("Enter Marks");
                            st.Marks = double.Parse(Console.ReadLine());

                            studentList.Add(st);
                        }

                    }
                    else
                    {
                        Console.WriteLine("invalid input");
                    }
                }
                else if (input == "2")
                {

                    for (int i = 0; i < size; i++)
                    {
                        Student st = studentList[i];
                        Console.WriteLine($"Thank you for providing the details. Following are your details for student {i+1}-");
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

        static void Main1()
        {
            var length = 10;
            var i = 0;
            for (i = 0; i < length; i++)
            {
                //code execution block
            }

            length = 5;

            while (i<=length)
            {
                //code execution block
                i++;
            }

            do
            {
                i++;
                //code execution block
                //i++;
            }
            while (i <= 5);

            var studentList = new List<Student>();

            foreach (Student item in studentList)
            {
                //code execution block
                Console.WriteLine(item.FN);
                item.LN = "ABC";
            }

            //Find specific student
            var rollNo = Convert.ToInt32(Console.ReadLine());
            var fn = Console.ReadLine();
            var student = studentList.Where(x => x.RollNo==rollNo).FirstOrDefault();

            var students = studentList.Where(x => x.FN == fn).ToList();
        }
    }
}

