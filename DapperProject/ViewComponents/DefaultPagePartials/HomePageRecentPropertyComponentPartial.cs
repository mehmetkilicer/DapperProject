using DapperProject.Services.PropertyServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperProject.ViewComponents.DefaultPagePartials
{
    public class HomePageRecentPropertyComponentPartial : ViewComponent
    {
        private readonly IPropertyService _propertyService;

        public HomePageRecentPropertyComponentPartial(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _propertyService.GetLast4PropertyAsync();
            return View(values);
        }
    }

}
