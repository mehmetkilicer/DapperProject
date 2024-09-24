using DapperProject.Dtos.CategoryDtos;

namespace DapperProject.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task DeleteCategoryAsync(int id);
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task<List<GetCategoryWithCountDto>> GetCategoryWithCount();

        Task<GetByIdCategoryDto> GetCategoryAsync(int id);
        Task<int> GetCategoryCount();

    }
}
