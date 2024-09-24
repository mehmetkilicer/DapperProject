using DapperProject.Services.TestimonialServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperProject.ViewComponents.DefaultPagePartials
{
    public class HomePageTestimonialComponentPartial : ViewComponent
    {
        private readonly ITestimonialService _testimonialService;

        public HomePageTestimonialComponentPartial(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _testimonialService.GetAllTestimonialAsync();
            return View(values);
        }
    }
}
