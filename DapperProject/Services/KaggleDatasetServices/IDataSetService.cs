using DapperProject.Dtos.KaggleDatasetDtos;

namespace DapperProject.Services.KaggleDatasetServices
{
    public interface IDataSetService
    {
        Task<List<ResultDataDto>> GetAllDataAsync();

    }
}
