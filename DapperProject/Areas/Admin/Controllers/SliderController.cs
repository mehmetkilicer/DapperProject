using DapperProject.Dtos.SliderDtos;
using DapperProject.Services.SliderServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperProject.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class SliderController : Controller
    {
     
            private readonly ISliderService _sliderService;

            public SliderController(ISliderService sliderService)
            {
                _sliderService = sliderService;
            }

            public async Task<IActionResult> Index()
            {
                return View(await _sliderService.GetAllSliderAsync());
            }
            public async Task<IActionResult> DeleteSlider(int id)
            {
                await _sliderService.DeleteSliderAsync(id);
                return RedirectToAction("Index");
            }
            public IActionResult CreateSlider()
            {
                return View();
            }
            [HttpPost]
            public async Task<IActionResult> CreateSlider(CreateSliderDto createSliderDto)
            {
                await _sliderService.CreateSliderAsync(createSliderDto);
                return RedirectToAction("Index");
            }
            public async Task<IActionResult> UpdateSlider()
            {
                return View(await _sliderService.GetAllSliderAsync());
            }
            [HttpPost]
            public async Task<IActionResult> UpdateSlider(UpdateSliderDto updateSliderDto)
            {
                var value = await _sliderService.GetAllSliderAsync();
                return View(value);
            }
        }
    }

