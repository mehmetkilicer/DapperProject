using Dapper;
using DapperProject.Context;
using DapperProject.Dtos.RealEstateListingDtos;

namespace DapperProject.Services.RealEstateListingServices
{
    public class RealEstateListingService : IRealEstateListingService
    {
        private readonly DapperContext _dapperContext;

        public RealEstateListingService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<decimal> AvgPrice()
        {
            string query = "select avg(convert(decimal(10,2),price)) as 'AvgPrice' from real_estate_listing";
            var connection = _dapperContext.CreateConnection();
            var values = await connection.QueryAsync<int>(query);
            return values.FirstOrDefault();
        }

        //public async Task<int> BuildCount()
        //{
        //    string query = "select count(*) from real_estate_listing where status = 'ready_to_build'";
        //    var connection = _dapperContext.CreateConnection();
        //    var values = await connection.QueryAsync<int>(query);
        //    return values.FirstOrDefault();
        //}

        public async Task<List<ResultRealEstateListingDto>> GetRealEstateList()

        {
            string query = "select * from realtor-data23.zip";
            var connection = _dapperContext.CreateConnection();
            var values = await connection.QueryAsync<ResultRealEstateListingDto>(query);
            return values.ToList();
        }

        //public async Task<List<ResultRealEstateListingDto>> GetRealEstateListFilter(decimal? minPrice, decimal? maxPrice)
        //{
        //    string query = "select * from real_estate_listing where convert(decimal(10,2),price) between @minprice and @maxprice";
        //    var parameters = new DynamicParameters();
        //    parameters.Add("@minprice", minPrice);
        //    parameters.Add("@maxprice", maxPrice);
        //    var connection = _dapperContext.CreateConnection();
        //    var values = await connection.QueryAsync<ResultRealEstateListingDto>(query, parameters);
        //    return values.ToList();
        //}

        //public async Task<int> SaleCount()
        //{
        //    string query = "select count(*) from real_estate_listing where status = 'for_sale'";
        //    var connection = _dapperContext.CreateConnection();
        //    var values = await connection.QueryAsync<int>(query);
        //    return values.FirstOrDefault();
        //}

        //public async Task<int> SoldCount()
        //{
        //    string query = "select count(*) from real_estate_listing where status = 'sold'";
        //    var connection = _dapperContext.CreateConnection();
        //    var values = await connection.QueryAsync<int>(query);
        //    return values.FirstOrDefault();
        //}

        //public async Task<List<ResultRealEstateListingCountDto>> StateCount()
        //{
        //    string query = "select count(*) as 'count',state from real_estate_listing group by state";
        //    var connection = _dapperContext.CreateConnection();
        //    var values = await connection.QueryAsync<ResultRealEstateListingCountDto>(query);
        //    return values.ToList();
        //}
    }
}
