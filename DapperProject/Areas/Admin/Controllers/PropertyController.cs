using DapperProject.Dtos.PropertyDtos;
using DapperProject.Services.CategoryServices;
using DapperProject.Services.LocationServices;
using DapperProject.Services.PropertyServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace DapperProject.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class PropertyController : Controller
    {
        private readonly IPropertyService _properyService;
        private readonly ICategoryService _categoryService;
        private readonly ILocationService _locationService;

        public PropertyController(IPropertyService properyService, ILocationService locationService, ICategoryService categoryService)
        {
            _properyService = properyService;
            _locationService = locationService;
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _properyService.GetAllPropertyWithCategoryAndLocationAsync());
        }
        public async Task<IActionResult> DeleteProperty(int id)
        {
            await _properyService.DeletePropertyAsync(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> CreateProperty()
        {
            ViewBag.categories = new SelectList(await _categoryService.GetAllCategoryAsync(), "CategoryId", "CategoryName");
            ViewBag.locations = new SelectList(await _locationService.GetAllLocationAsync(), "LocationId", "Location");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProperty(CreatePropertyDto createPropertyDto)
        {
            createPropertyDto.IsFeatured = false;

            // ModelState'in geçerliliğini kontrol edin
            if (!ModelState.IsValid)
            {
                ViewBag.categories = new SelectList(await _categoryService.GetAllCategoryAsync(), "CategoryId", "CategoryName");
                ViewBag.locations = new SelectList(await _locationService.GetAllLocationAsync(), "LocationId", "Location");
                return View(createPropertyDto); // Geçersizse, kullanıcıya girdiği verileri geri gönderin
            }

            await _properyService.CreatePropertyAsync(createPropertyDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateProperty(int id)
        {
            ViewBag.categories = new SelectList(await _categoryService.GetAllCategoryAsync(), "CategoryId", "CategoryName");
            ViewBag.locations = new SelectList(await _locationService.GetAllLocationAsync(), "LocationId", "Location");

            var property = await _properyService.GetByIdPropertyWithIncludeAsync(id);
            if (property == null)
            {
                return NotFound(); // Eğer property bulunamazsa 404 döndür
            }

            // Property modelini UpdatePropertyDto'ya aktarın
            var updatePropertyDto = new UpdatePropertyDto
            {
                PropertyId = property.PropertyId, // PropertyId'yı kopyalayın
                PropertyName = property.PropertyName,
                VideoUrl = property.VideoUrl,
                Address = property.Address,
                Description = property.Description,
                ForRent = property.ForRent,
                ForSale = property.ForSale,
                BedroomCount = property.BedroomCount,
                BathroomCount = property.BathroomCount,
                Price = property.Price,
                AreaSize = property.AreaSize,
                IsFeatured = property.IsFeatured,
                BuildAge = property.BuildAge,
                ImageUrl1 = property.ImageUrl1,
                ImageUrl2 = property.ImageUrl2,
                ImageUrl3 = property.ImageUrl3,
                LocationId = property.LocationId,
                CategoryId = property.CategoryId,
            };

            return View(updatePropertyDto); // UpdatePropertyDto modelini view'a gönder
        }



        [HttpPost]
        public async Task<IActionResult> UpdateProperty(UpdatePropertyDto updatePropertyDto)
        {
            // ModelState'in geçerliliğini kontrol edin
            if (!ModelState.IsValid)
            {
                ViewBag.categories = new SelectList(await _categoryService.GetAllCategoryAsync(), "CategoryId", "CategoryName");
                ViewBag.locations = new SelectList(await _locationService.GetAllLocationAsync(), "LocationId", "Location");
                return View(updatePropertyDto); // Geçersizse, kullanıcıya girdiği verileri geri gönderin
            }

            await _properyService.UpdatePropertyAsync(updatePropertyDto);
            return RedirectToAction("Index");
        }



    }
}

