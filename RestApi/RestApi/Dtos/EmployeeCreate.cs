using System;

namespace RestApi.Dtos
{
    public class EmployeeCreate
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public DateTime BirthDate { get; set; }

    }
}
