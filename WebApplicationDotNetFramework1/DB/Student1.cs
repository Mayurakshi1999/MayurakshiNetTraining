//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplicationDotNetFramework1.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Student1
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<int> RollNo { get; set; }
        public Nullable<int> Marks { get; set; }
        public Nullable<int> BranchId { get; set; }
        public Nullable<System.DateTime> DateofBirth { get; set; }
    
        public virtual Branch Branch { get; set; }
    }
}