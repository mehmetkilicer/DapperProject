using Dapper;
using DapperProject.Context;
using DapperProject.Dtos.RealEstateListingDtos;
using DapperProject.Dtos.StatisticsDtos;

namespace DapperProject.Services.StatisticsServices
{
    public class StatisticsService : IStatisticsService
    {
        private readonly DapperContext _context;

        public StatisticsService(DapperContext context)
        {
            _context = context;
        }

        public async Task<decimal> AvgPrice()
        {
            string query = "select avg(convert(decimal(10,2),price)) as 'AvgPrice' from TblProperty";
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<int>(query);
            return values.FirstOrDefault();
        }

        public async Task<int> GettAllCityCountAsync()
        {
            string query = "select Count(distinct Location) from TblLocation";
            var connection = _context.CreateConnection();
            int value = await connection.QueryFirstOrDefaultAsync<int>(query);
            return value;
        }

        public async Task<int> SaleCount()
        {
        
                string query = "SELECT COUNT(*) FROM TblProperty WHERE ForSale = 1;"; 
                using var connection = _context.CreateConnection();
                int count = await connection.QueryFirstOrDefaultAsync<int>(query);
                return count;
            

        }

        public async Task<int> PropertyCount()
        {
            string query = "SELECT COUNT(*) FROM TblProperty;";
            var connection = _context.CreateConnection();
            int value = await connection.QueryFirstOrDefaultAsync<int>(query);
            return value;
        }

        public async Task<int> RentCount()
        {
            string query = "SELECT COUNT(*) FROM TblProperty WHERE ForRent = 1;";
            using var connection = _context.CreateConnection();
            int count = await connection.QueryFirstOrDefaultAsync<int>(query);
            return count;
        }

    

    }
}
