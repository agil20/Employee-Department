using RestApi.Models;
using System;

namespace RestApi.Dtos
{
    public class EmployeeReturnDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime CreateDate { get; set; }
        public Department Department{ get; set; }

    }
}
