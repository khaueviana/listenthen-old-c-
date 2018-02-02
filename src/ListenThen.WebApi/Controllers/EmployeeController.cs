using ListenThen.Application.Interfaces;
using ListenThen.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ListenThen.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Employee")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeAppService _employeeAppService;
        private readonly IJobTitleAppService _jobTitleAppService;
        public EmployeeController(IEmployeeAppService employeeAppService, IJobTitleAppService jobTitleAppService)
        {
            _employeeAppService = employeeAppService;
            _jobTitleAppService = jobTitleAppService;
        }

        [HttpPost("Create")]
        public IActionResult Register()
        {
            var jobTitle = _jobTitleAppService.GetById(new Guid("48BE7303-649C-40D8-1A92-08D55DC65866"));

            var viewModel = new EmployeeViewModel
            {
                Email = "teste@teste.com.br",
                Genre = "Male",
                JobTitle = new JobTitleViewModel
                {
                    Id = new Guid("C1EBE077-C5B0-49F5-3FE3-08D55DCDFB1D")
                },
                Name = "Supp",
                Surname = "Lier"
            };

            _employeeAppService.Register(viewModel);

            return Ok();
        }
    }
}