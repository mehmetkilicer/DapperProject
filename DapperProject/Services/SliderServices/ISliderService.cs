using DapperProject.Dtos.SliderDtos;

namespace DapperProject.Services.SliderServices
{
    public interface ISliderService
    {
        Task<List<ResultSliderDto>> GetAllSliderAsync();
        Task CreateSliderAsync(CreateSliderDto dto);
        Task DeleteSliderAsync(int id);
        Task UpdateSliderAsync(UpdateSliderDto dto);
        Task<GetByIdSliderDto> GetSliderAsync(int id);
    }
}
