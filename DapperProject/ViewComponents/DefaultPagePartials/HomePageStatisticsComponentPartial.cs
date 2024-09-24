using DapperProject.Services.PropertyServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperProject.ViewComponents.DefaultPagePartials
{
    public class HomePageStatisticsComponentPartial : ViewComponent
    {
        private readonly IPropertyService  _properyService;

        public HomePageStatisticsComponentPartial(IPropertyService properyService)
        {
            _properyService = properyService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.testimonialcount = await _properyService.GetTestimonialCount();
            ViewBag.propertiescount = await _properyService.GetPropertyCount();
            ViewBag.agentcount = await _properyService.GetAgentCount();
            ViewBag.rentcount = await _properyService.PropertyForRentCount();
            ViewBag.salecount = await _properyService.PropertyForSaleCount();
            return View();
        }
    }
}
