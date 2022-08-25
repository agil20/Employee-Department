using System.Collections.Generic;

namespace RestApi.Dtos
{
    public class EmployeeListDto
    {
        public int TotalCount { get; set; }
        public List<EmployeeReturnDto> Items { get; set; }
    }
}
