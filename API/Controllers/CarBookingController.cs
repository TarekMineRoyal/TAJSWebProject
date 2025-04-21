using DataAccess.Entities;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CarBookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> CreateCarBooking(CreateCarBookingDTO createCarBookingDTO)
        {
            var duration 
        }
    }
}
