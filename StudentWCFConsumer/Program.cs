// See https://aka.ms/new-console-template for more information
using StudentService;

Console.WriteLine("Hello, World!");
//var service = new StudenterviceClient();
//var request = new StudentInfoRequest
//{
//    Header = new HeaderInfo
//    {
//        TransactionID = Guid.NewGuid().ToString()
//    },
//    Body = new StudentBO
//    {
//        //FirstName= "Mayu",
//        //LastName= "Paul",
//        //Marks = 100,
//        //RollNo = 21
//        FirstName = Console.ReadLine(),
//        LastName = Console.ReadLine(),
//        RollNo = Convert.ToInt32(Console.ReadLine()),
//        Marks = Convert.ToInt32(Console.ReadLine())

//    }

//};
//var response = service.CreateStudent(request);
//Console.WriteLine(response.Header.TransactionID);
//Console.WriteLine(response.Header.CallStatus);
int size = 0;

for (; ; )
{
    Console.WriteLine("1. Create Student.");
    Console.WriteLine("2. Update Student Details.");
    Console.WriteLine("3. Delete a Student by Roll.");


    string input = Console.ReadLine();
    if (input == "1")
    {
        Console.WriteLine("Enter the First name, last name, roll no and marks of the student");
        var service = new StudenterviceClient();
        var request = new StudentInfoRequest
        {
            Header = new HeaderInfo
            {
                TransactionID = Guid.NewGuid().ToString()
            },
            Body = new StudentBO
            {
                FirstName = Console.ReadLine(),
                LastName = Console.ReadLine(),
                RollNo = Convert.ToInt32(Console.ReadLine()),
                Marks = Convert.ToInt32(Console.ReadLine())
            }

        };
        var response = service.CreateStudent(request);
        Console.WriteLine(response.Header.TransactionID);
        Console.WriteLine(response.Header.CallStatus);

    }

    //UPDATE METHOD
    else if (input == "2")
    {
        Console.WriteLine("Enter the Roll No of the student record you want to edit:");
        var Roll = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the changed First Name of the student:");
        var FN = Console.ReadLine();
        Console.WriteLine("Enter the changed Last Name of the student:");
        var LN = Console.ReadLine();
        Console.WriteLine("Enter the changed Marks :");
        var M = Convert.ToInt32(Console.ReadLine());
        var service = new StudenterviceClient();
        var request = new StudentInfoRequest
        {
            Header = new HeaderInfo
            {
                TransactionID = Guid.NewGuid().ToString()
            },
            Body = new StudentBO
            {
                FirstName = FN,
                LastName = LN,
                RollNo = Roll,
                Marks = M,
            }
        };


        var response = service.UpdateStudent(request);
        Console.WriteLine(response.Header.TransactionID);
        Console.WriteLine(response.Header.CallStatus);

    }

    //DELETE METHOD
    else if (input == "3")
    {
        Console.WriteLine("Enter the changed Roll Number of the student:");
        var service = new StudenterviceClient();
        var request = new StudentInfoRequest
        {
            Header = new HeaderInfo
            {
                TransactionID = Guid.NewGuid().ToString()
            },

            Body = new StudentBO
            {

                RollNo = Convert.ToInt32(Console.ReadLine()),
            }
        };

        var response = service.DeleteStudent(request);
        Console.WriteLine(response.Header.TransactionID);
        Console.WriteLine(response.Header.CallStatus);
    }
}