using DapperProject.Dtos.PaginatedListDtos;
using DapperProject.Dtos.PropertyDtos;
using DapperProject.Services.PaginatedServices;
using DapperProject.Services.PropertyServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperProject.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IPaginatedListService<ResultPropertyWithCategoryAndLocationDto> _paginatedListService;
        private readonly IPropertyService _propertyService;

        public PropertyController(IPropertyService propertyService, IPaginatedListService<ResultPropertyWithCategoryAndLocationDto> paginatedListService)
        {
            _propertyService = propertyService;
            _paginatedListService = paginatedListService;
        }

        public async Task<IActionResult> Index(int pageIndex = 1)
        {
            int pageSize = 6;
            var values = await _propertyService.GetAllPropertyWithCategoryAndLocationAsync();
            var paginatedList = await _paginatedListService.CreateAsync(values, pageIndex, pageSize);

            return View(paginatedList);
        }

        public async Task<IActionResult> Detail(int id)
        {

            return View(id);
        }
        [HttpGet]
        public async Task<IActionResult> SearchProperty()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SearchProperty(SearchPropertyDto dto)
        {
            if (dto.IsForRent == false && dto.IsForSale == false)
            {
                dto.IsForSale = true;
                dto.IsForRent = false;
            }
            var values = await _propertyService.Search(dto);
            if (!values.Any())
            {
                ViewBag.message = "Aradığınız Kriterlerde Bir Seçenek Bulamadık !";
                return View(values);
            }
            else
            {
                return View(values);
            }

        }
    }
}
