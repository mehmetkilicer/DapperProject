using DapperProject.Dtos.PropertyDtos;

namespace DapperProject.Services.PropertyServices
{
    public interface IPropertyService 
    {
        Task<List<ResultPropertyDto>> GetAllPropertyAsync();
        Task<ResultPropertyForDetailDto> GetPropertyForDetailAsync(int id);
        Task<List<ResultPropertyWithCategoryAndLocationDto>> GetAllPropertyWithCategoryAndLocationAsync();
        Task<List<ResultPropertyByIsFeatureDto>> GetAllPropertyByIsFeatureAsync();
        Task<List<ResultPropertyByIsFeatureDto>> GetLast4PropertyAsync();
        Task<int> CreatePropertyAsync(CreatePropertyDto dto);
        Task DeletePropertyAsync(int id);
        Task UpdatePropertyAsync(UpdatePropertyDto dto);
        Task<GetByIdPropertyDto> GetPropertyAsync(int id);
        Task<List<ResultPropertyWithCategoryAndLocationDto>> Search(SearchPropertyDto dto);
        Task<int> GetTestimonialCount();
        Task<int> GetPropertyCount();
        Task<int> GetAgentCount();
        Task<int> PropertyForRentCount();
        Task<int> PropertyForSaleCount();
        Task<GetByIdPropertyWithCategoryAndLocationDto> GetByIdPropertyWithIncludeAsync(int id);

        //Task<List<ResultRecentPropertiesDto>> GetRecentPropertiesList();
    }
}
