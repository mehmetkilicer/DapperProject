using DapperProject.Dtos.AgentDtos;
using DapperProject.Dtos.LocationDtos;
using DapperProject.Services.LocationServices;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DapperProject.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class LocationController : Controller
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _locationService.GetAllLocationAsync());
        }
        public IActionResult CreateLocation()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateLocation(CreateLocationDto createLocationDto)
        {
            await _locationService.CreateLocationAsync(createLocationDto);
            return RedirectToAction("Index");

        }
        public async Task<IActionResult> DeleteLocation(int id)
        {
            await _locationService.DeleteLocationAsync(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdateLocation(int id)
        {
            return View(await _locationService.GetByIdLocationAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> UpdateLocation(UpdateLocationDto updateLocationDto)
        {
            await _locationService.UpdateLocationAsync(updateLocationDto);
            return RedirectToAction("Index");

        }
    }
}
