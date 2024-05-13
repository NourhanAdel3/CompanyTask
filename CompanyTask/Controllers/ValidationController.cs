//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace CompanyTask.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ValidationController : ControllerBase
//    {
//            private readonly GoogleLocationService _locationService;

//            public ValidationController(GoogleLocationService locationService)
//            {
//                _locationService = locationService;
//            }
//        [HttpGet("{address}")]
//        public IActionResult ValidateAddress(string address)
//        {
//            var point = _locationService.GetLatLongFromAddress(address);

//            if (point == null)
//            {
//                return BadRequest("Address validation failed.");
//            }
//            else
//            {
//                return Ok(new { Latitude = point.Latitude, Longitude = point.Longitude });
//            }
//        }
//    }
//}
