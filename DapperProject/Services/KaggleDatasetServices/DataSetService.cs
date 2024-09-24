using Dapper;
using DapperProject.Context;
using DapperProject.Dtos.KaggleDatasetDtos;

namespace DapperProject.Services.KaggleDatasetServices
{
    public class DataSetService : IDataSetService
    {
        private readonly DapperContext _dapperContext;

        public DataSetService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<List<ResultDataDto>> GetAllDataAsync()
        {
            string query = "SELECT * FROM [realtor-data23.zip]";
            var connection = _dapperContext.CreateConnection();
            var values = await connection.QueryAsync<ResultDataDto>(query);
            return values.ToList();
        }


    }
}
