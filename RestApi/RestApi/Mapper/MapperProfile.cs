
using AutoMapper;
using RestApi.Dtos;
using RestApi.Models;
using System.Collections.Generic;

namespace RestApi.Mapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Employee, EmployeeReturnDto>();
               
                
                
            CreateMap<Employee, EmployeeUpdateDto>().ReverseMap();
            CreateMap<Employee, EmployeeCreateDto>().ReverseMap();

            CreateMap<List<EmployeeReturnDto>, EmployeeListDto>()
             .ForMember(l => l.TotalCount, map => map.MapFrom(s => s.Count))
             .ForMember(l => l.Items, map => map.MapFrom(s => s));
        }
    }
}
