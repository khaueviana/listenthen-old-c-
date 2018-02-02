using ListenThen.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ListenThen.WebApi.Controllers
{
    public class OneToOneMeetingController : Controller
    {
        private readonly IOneToOneMeetingAppService _oneToOneMeetingAppService;

        public OneToOneMeetingController(IOneToOneMeetingAppService oneToOneMeetingAppService)
        {
            _oneToOneMeetingAppService = oneToOneMeetingAppService;
        }

        public IActionResult Index()
        {
            return Ok();
        }
    }
}