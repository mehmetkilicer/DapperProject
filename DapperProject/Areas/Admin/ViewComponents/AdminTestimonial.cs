using DapperProject.Services.TestimonialServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperProject.Areas.Admin.ViewComponents
{
    public class AdminTestimonial : ViewComponent
    {
        private readonly ITestimonialService _testimonialService;

        public AdminTestimonial(ITestimonialService testimonialService)
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
