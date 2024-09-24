using DapperProject.Services.StatisticsServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperProject.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class DashboardController : Controller
    {
        private readonly IStatisticsService _statisticsService;

        public DashboardController(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }

        public async Task< IActionResult> Index()
        {
            ViewBag.propertCount= await _statisticsService.PropertyCount();
            ViewBag.saleCount = await _statisticsService.SaleCount();
            ViewBag.rentCount = await _statisticsService.RentCount();
            ViewBag.cityCount = await _statisticsService.GettAllCityCountAsync();
            ViewBag.avgPrice = await _statisticsService.AvgPrice();
            return View();
        }

    }
}
