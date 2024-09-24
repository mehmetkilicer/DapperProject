using DapperProject.Dtos.RealEstateListingDtos;
using DapperProject.Dtos.StatisticsDtos;

namespace DapperProject.Services.StatisticsServices
{
    public interface IStatisticsService
    {
        Task<int> SaleCount();
        Task<int> RentCount();
        Task<int> GettAllCityCountAsync();
        Task<int> PropertyCount();
        Task<decimal> AvgPrice();

    }
}
