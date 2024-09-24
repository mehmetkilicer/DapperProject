using DapperProject.Dtos.LocationDtos;

namespace DapperProject.Services.LocationServices
{
    public interface ILocationService
    {
        Task<List<ResultLocationDto>> GetAllLocationAsync();
        Task<int> GetLocationCount();

        Task CreateLocationAsync(CreateLocationDto createLocationDto);
        Task UpdateLocationAsync(UpdateLocationDto updateLocationDto);
        Task DeleteLocationAsync(int id);
        Task<GetByIdLocationDto> GetByIdLocationAsync(int id);
    }
}
