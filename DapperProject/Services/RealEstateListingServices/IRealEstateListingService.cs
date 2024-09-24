using DapperProject.Dtos.RealEstateListingDtos;

namespace DapperProject.Services.RealEstateListingServices
{
    public interface IRealEstateListingService
    {
        Task<List<ResultRealEstateListingDto>> GetRealEstateList();
        //Task<List<ResultRealEstateListingDto>> GetRealEstateListFilter(decimal? minPrice, decimal? maxPrice);
        //Task<int> SaleCount();
        //Task<int> SoldCount();
        ////Task<int> BuildCount();
        //Task<decimal> AvgPrice();
        //Task<List<ResultRealEstateListingCountDto>> StateCount();
    }
}
