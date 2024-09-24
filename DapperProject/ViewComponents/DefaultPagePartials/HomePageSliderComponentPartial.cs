using DapperProject.Services.SliderServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperProject.ViewComponents.DefaultPagePartials
{
    public class HomePageSliderComponentPartial : ViewComponent
    {
        private readonly ISliderService _sliderService;

        public HomePageSliderComponentPartial(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _sliderService.GetAllSliderAsync();
            return View(values);
        }
    }
}
