using Intellimedia.Models;
using Intellimedia.RepositoriesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Intellimedia.Controllers.ApiControllers.V1
{
    [RoutePrefix("employee")]
    public class EmployeeController : ApiController
    {
        ApplicationDbContext context = new ApplicationDbContext();
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IPersonnelTimeRepository _personnelTimeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository, IPersonnelTimeRepository personnelTimeRepository)
        {
            _employeeRepository = employeeRepository;
            _personnelTimeRepository = personnelTimeRepository;
        }

        [Route("add")]
        [HttpPost]
        public IHttpActionResult Add(EmployeeViewModel employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var newTime = new PersonnelTime()
            {
                TimeOfBeginning = employee.TimeOfBeginning,
                TimeOfEnding = employee.TimeOfEnding,
                Name = employee.Name
            };
            _personnelTimeRepository.Add(newTime, context);
            var newEmployee = new Employee()
            {
                DateOfAdding = DateTime.Now,
                Gender = employee.Gender,
                ContactInformation = employee.ContactInformation,
                Name = employee.Name,
                TimeId = newTime.Id
            };
            _employeeRepository.Add(newEmployee, context);
            employee.Id = newEmployee.Id;
            employee.TimeId = newTime.Id;
            employee.DateOfAdding = newEmployee.DateOfAdding;
            return Ok(employee);
        }

        [Route("edit")]
        [HttpPost]
        public IHttpActionResult Edit(EmployeeViewModel employee)
        { 
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var newEmployee = new Employee()
            {
                Id = employee.Id,
                DateOfAdding = DateTime.Now,
                Gender = employee.Gender,
                ContactInformation = employee.ContactInformation,
                Name = employee.Name,
                TimeId = employee.TimeId
            };
            _employeeRepository.Update(newEmployee, context);
            var newTime = new PersonnelTime()
            {
                Id = employee.TimeId,
                TimeOfBeginning = employee.TimeOfBeginning,
                TimeOfEnding = employee.TimeOfEnding,
                Name = employee.Name
            };
            _personnelTimeRepository.Update(newTime, context);
            employee.Id = newEmployee.Id;
            employee.TimeId = newTime.Id;
            return Ok(employee);
        }

        [Route("remove")]
        [HttpPost]
        public IHttpActionResult Remove(Employee employee)
        {
            _employeeRepository.Remove(x => x.Id == employee.Id, context);
            _personnelTimeRepository.Remove(x => x.Id == employee.TimeId, context);
            return Ok();
        }


        [Route("get")]
        [HttpGet]
        public IHttpActionResult Get(int skip)
        {
            var timesIds = new List<int>();
            var employees = _employeeRepository.GetAll(context, skip);
            foreach (var employee in employees)
            {
                timesIds.Add(employee.TimeId); 
            };
            var times = _personnelTimeRepository.GetMany(x => timesIds.Contains(x.Id), context);

            var result = new List<EmployeeViewModel>();
            foreach (var employee in employees)
            {
                result.Add(new EmployeeViewModel()
                {
                    Id = employee.Id,
                    Gender = employee.Gender,
                    ContactInformation = employee.ContactInformation,
                    Name = employee.Name,
                    TimeId = employee.TimeId,
                    TimeOfBeginning = times.Where(x => x.Id == employee.TimeId).FirstOrDefault().TimeOfBeginning,
                    TimeOfEnding = times.Where(x => x.Id == employee.TimeId).FirstOrDefault().TimeOfEnding,
                    DateOfAdding = employee.DateOfAdding
                });
            };
            var employeesCount = _employeeRepository.Count(context);
            return Ok(new { employees = result, count = employeesCount});
        }

        [Route("chart")]
        [HttpGet]
        public IHttpActionResult Chart()
        {
            var times = _personnelTimeRepository.GetAll(context, 0, 100).ToList();
            var result = new
            {
                Duration = new List<int>(),
                Beginning = new List<int>(),
                Ending = new List<int>()
            };

            for (var i = 0; i < times.Count(); i++)
            {
                result.Duration.Add(Math.Abs(times[i].TimeOfBeginning - times[i].TimeOfEnding));
                result.Beginning.Add(times[i].TimeOfBeginning);
                result.Ending.Add(times[i].TimeOfEnding);
            }

            return Ok(result);
        }

    }
}