using DapperProject.Services.PropertyServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperProject.ViewComponents.DeatialPagePartials
{
    public class PropertyDetailsComponentPartial : ViewComponent
    {
        private readonly IPropertyService _propertyService;

        public PropertyDetailsComponentPartial(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var value = await _propertyService.GetByIdPropertyWithIncludeAsync(id);
            return View(value);
        }   
    }
}
