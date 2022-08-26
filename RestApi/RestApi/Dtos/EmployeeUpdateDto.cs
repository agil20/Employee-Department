using System;

namespace RestApi.Dtos
{
    public class EmployeeUpdateDto
    {
      public string Name { get; set; }
        public string Surname { get; set; }
        public  int DepartmentId { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
