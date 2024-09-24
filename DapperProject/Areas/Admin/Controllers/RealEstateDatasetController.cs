using DapperProject.Services.KaggleDatasetServices;
using DapperProject.Services.RealEstateListingServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RealEstateDatasetController : Controller
    {
        private readonly IDataSetService _dataSetService;

        public RealEstateDatasetController(IDataSetService dataSetService)
        {
            _dataSetService = dataSetService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _dataSetService.GetAllDataAsync();
            return View(values);
        }
    }
}
