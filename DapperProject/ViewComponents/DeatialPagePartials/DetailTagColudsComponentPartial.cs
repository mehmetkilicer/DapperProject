using DapperProject.Services.TagServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperProject.ViewComponents.DeatialPagePartials
{
    public class DetailTagColudsComponentPartial : ViewComponent
    {
        private readonly ITagService _tagService;

        public DetailTagColudsComponentPartial(ITagService tagService)
        {
            _tagService = tagService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _tagService.GetAllTagAsync();
            return View(values);
        }
    }
}
