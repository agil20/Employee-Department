using System;

namespace RestApi.Dtos
{
    public class EmployeeCreateDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int DepartmentId { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
