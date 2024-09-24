using DapperProject.Dtos.CategoryDtos;
using DapperProject.Services.CategoryServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DapperProject.ViewComponents.DefaultPagePartials
{
    public class HomePageSearchPropertyComponentPartial : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public HomePageSearchPropertyComponentPartial(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.categories = await GetCategories();
            return View();
        }

        private async Task<List<ResultCategoryDto>> GetCategories()
        {
            return await _categoryService.GetAllCategoryAsync();
        }
    }
}
