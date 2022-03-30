using User_defined;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Linq;

List<student> studentList = null;
int size = 0;
int x = 0;

while (x>=0)
{
    Console.WriteLine("1. Enter Student Details.");
    Console.WriteLine("2. Display Student Details.");
    Console.WriteLine("3. Find a Name.");
    String input = Console.ReadLine();
    if (input == "1")
    {
        Console.WriteLine("Enter the number of students:");

        int i = Convert.ToInt32(Console.ReadLine());
        size = i;
        studentList = new List<student>();

        if (i != 0)
        {
            int j = 0;
            while(j<i)
            {

                student student = new student();
                Console.WriteLine($"Enter details for student{j + 1}");

                Console.WriteLine("Enter First Name");
                student.FirstName = Console.ReadLine();

                Console.WriteLine("Enter LastName");
                student.LastName = Console.ReadLine();

                Console.WriteLine("Enter Roll Number");
                student.RollNumber = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Marks Secured");
                student.MarksSecured = Convert.ToDouble(Console.ReadLine());
                studentList.Add(student);
                j++;
                
            }
        }

    }

    else if (input == "2")
    {

        Console.WriteLine("Thank You for sharing your Information. Your Details are as follows:");
       
            foreach (var student in studentList){
                Console.WriteLine($"FirstName: {student.FirstName}");
                Console.WriteLine($"LastName: {student.LastName}");
                Console.WriteLine($"Roll Number: {student.RollNumber}");
                Console.WriteLine($"Marks Secured: {student.MarksSecured}");
            }
    }
    else if(input == "3")
    {
        Console.WriteLine("Enter the name"); 
        string name = Console.ReadLine();
        var res = from l in studentList
                  where l.FirstName.Contains(name)
                  select l;

        // Executing LINQ Query
        foreach (var q in res)
        {
            Console.WriteLine($"FirstName: {q.FirstName}");
            Console.WriteLine($"LastName: {q.LastName}");
            Console.WriteLine($"Roll Number: {q.RollNumber}");
            Console.WriteLine($"Marks Secured: {q.MarksSecured}");
        }
    }



    else
    {
        Console.WriteLine("Invalid Input");
        break;
    }
    Console.WriteLine("Enter 1 to view main menu or 0 to exit");
    int p = Convert.ToInt32(Console.ReadLine());
    if (p == 1)
    {
        x++;
    }
    else
    {
        break;
    }


}


