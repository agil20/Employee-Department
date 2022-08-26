using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApi.Data;
using RestApi.Dtos;
using RestApi.Filter;
using RestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {


        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public EmployeeController(AppDbContext context, IMapper mapper = null)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var query = _context.Employees.Include(n => n.Department).AsQueryable();


            List<EmployeeReturnDto> employeeReturns = _mapper.Map<List<EmployeeReturnDto>>(query.ToList());
            EmployeeListDto employeeListDto = _mapper.Map<EmployeeListDto>(employeeReturns);
            return Ok(employeeListDto);
        }
        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            Employee employee = _context.Employees.Include(e=>e.Department).FirstOrDefault(p => p.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            EmployeeReturnDto employeeReturn = _mapper.Map<EmployeeReturnDto>(employee);

            return Ok(employeeReturn);



            }
        [HttpPost]

        public IActionResult CreateEmployee(EmployeeCreateDto employeecreate)
        {

            if (employeecreate == null)
            {
                return NotFound();
            }

            Employee employee = _mapper.Map<Employee>(employeecreate);
            employee.CreateDate = DateTime.Now;

            _context.Employees.Add(employee);
            _context.SaveChanges();
            return Ok();


        }
        [HttpDelete]

        public IActionResult DeleteEmployee(int id)
        {

            Employee employee = _context.Employees.FirstOrDefault(p => p.Id == id);
            if (employee == null)
            {
                return NotFound();

            }
            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return Ok();





        }
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, EmployeeUpdateDto employeeDto)
        {

            Employee employee = _context.Employees.FirstOrDefault(e => e.Id == id);
            if (employeeDto.Name != null)
            {
                employee.Name = employeeDto.Name;
            }
            if (employee.Surname != null)
            {
                employee.Surname = employeeDto.Surname;
            }
            if (employeeDto.DepartmentId != 0)
            {
                employee.DepartmentId = employeeDto.DepartmentId;
            }
            _context.SaveChanges();
            return Ok();




            }
    //    [HttpGet("{Filter}")]
    //    public IActionResult Filter( [FromQuery] FilterEmployee filter)
    //    {
    //        switch (filter.Filter)
    //        {
    //            case RestApi.Filter.Filter.Age:
    //                break ;
    //            case RestApi.Filter.Filter.Xperience:
    //                break;
    //            default:
    //                break;
    //        }


    //    }



    }
}
