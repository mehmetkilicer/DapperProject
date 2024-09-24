using Dapper;
using DapperProject.Context;
using DapperProject.Dtos.LocationDtos;

namespace DapperProject.Services.LocationServices
{
    public class LocationService : ILocationService
    {
        private readonly DapperContext _context;

        public LocationService(DapperContext context)
        {
            _context = context;
        }
        public async Task CreateLocationAsync(CreateLocationDto createLocationDto)
        {
            string query = "Insert Into TblLocation (Location) values (@Location)";
            var parameters = new DynamicParameters();
            parameters.Add("@Location", createLocationDto.Location);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteLocationAsync(int id)
        {
            string query = "Delete From TblLocation Where LocationId=@LocationId";
            var parameters = new DynamicParameters();
            parameters.Add("@LocationId", id);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<List<ResultLocationDto>> GetAllLocationAsync()
        {
            string query = "Select * From TblLocation";
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<ResultLocationDto>(query);
            return values.ToList();
        }

        public async Task<GetByIdLocationDto> GetByIdLocationAsync(int id)
        {
            string query = "Select * From TblLocation Where LocationId=@LocationId";
            var parameters = new DynamicParameters();
            parameters.Add("@LocationId", id);
            var connection = _context.CreateConnection();
            var values = await connection.QueryFirstOrDefaultAsync<GetByIdLocationDto>(query, parameters);
            return values;
        }

        public async Task<int> GetLocationCount()
        {
            string query = "Select Count(*) From TblLocation";
            var connection = _context.CreateConnection();
            int value = await connection.QueryFirstOrDefaultAsync<int>(query);
            return value;
        }

        public async Task UpdateLocationAsync(UpdateLocationDto updateLocationDto)
        {
            string query = "Update TblLocation Set Location=@Location where LocationId=@LocationId";
            var parameters = new DynamicParameters();
            parameters.Add("@Location", updateLocationDto.Location);
            parameters.Add("@LocationId", updateLocationDto.LocationId);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
