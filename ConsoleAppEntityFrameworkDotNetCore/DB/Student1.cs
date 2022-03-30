using System;
using System.Collections.Generic;

namespace ConsoleAppEntityFrameworkDotNetCore.DB
{
    public partial class Student1
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? RollNo { get; set; }
        public int? Marks { get; set; }
        public int? BranchId { get; set; }
        public DateTime? DateofBirth { get; set; }

        public virtual Branch? Branch { get; set; }
    }
}
