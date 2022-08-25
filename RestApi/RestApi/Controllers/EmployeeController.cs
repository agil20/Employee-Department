using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApi.Data;
using RestApi.Dtos;
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
            var query = _context.Employees.AsQueryable();


            List<EmployeeReturnDto> employeeReturns = _mapper.Map<List<EmployeeReturnDto>>(query.ToList());
          EmployeeListDto cetogory = _mapper.Map<EmployeeListDto>(employeeReturns);
            return Ok (  cetogory);
        }
        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            Employee employee = _context.Employees.FirstOrDefault(p => p.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            EmployeeReturnDto employeeReturn = _mapper.Map<EmployeeReturnDto>(employee);

            return Ok(employeeReturn);



        }
        //[HttpPost]

        //public IActionResult CreateEmployee(EmployeeCreate employeecreate)
        //{

        //    if (employeecreate==null)
        //    {
        //        return NotFound();
        //    }

        //    Employee employee = _mapper.Map<Employee>(employeecreate);
        //    employee.CreateDate = DateTime.Now;
        //    _context.Employees.Add(employee);
        //    _context.SaveChanges();
        //    return Ok();


        //}
    }
}
