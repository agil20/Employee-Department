using System;

namespace RestApi.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public  int DepartmentId { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
