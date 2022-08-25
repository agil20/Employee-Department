
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

            CreateMap<List<EmployeeReturnDto>, EmployeeListDto>()
             .ForMember(l => l.TotalCount, map => map.MapFrom(s => s.Count))
             .ForMember(l => l.Items, map => map.MapFrom(s => s));
        }
    }
}
