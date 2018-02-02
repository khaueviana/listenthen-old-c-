using ListenThen.Application.Interfaces;
using ListenThen.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ListenThen.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/JobTitle")]
    public class JobTitleController : Controller
    {
        public IJobTitleAppService _jobTitleAppService;

        public JobTitleController(IJobTitleAppService jobTitleAppService)
        {
            _jobTitleAppService = jobTitleAppService;
        }

        [HttpPost]
        public IActionResult Post([FromBody]JobTitleViewModel viewModel)
        {
            _jobTitleAppService.Add(viewModel);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody]JobTitleViewModel viewModel, Guid id)
        {
            _jobTitleAppService.Update(viewModel);

            return Ok();
        }

        [HttpGet]
        public IActionResult Get(Guid id)
        {
            return Ok(_jobTitleAppService.GetById(id));
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            _jobTitleAppService.Remove(id);

            return Ok();
        }
    }
}