using DapperProject.Dtos.TestimonialDtos;
using DapperProject.Services.TestimonialServices;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DapperProject.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class TestimonialController : Controller
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _testimonialService.GetAllTestimonialAsync());
        }
        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            await _testimonialService.DeleteTestimonialAsync(id);
            return RedirectToAction("Index");
        }
        public IActionResult CreateTestimonial()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
      
                await _testimonialService.CreateTestimonialAsync(createTestimonialDto);
                return RedirectToAction("Index");

        }
        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            return View(await _testimonialService.GetTestimonialAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
       
                await _testimonialService.UpdateTestimonialAsync(updateTestimonialDto);
                return RedirectToAction("Index");
 
        }
    }
}

