using Dapper;
using DapperProject.Context;
using DapperProject.Dtos.SliderDtos;

namespace DapperProject.Services.SliderServices
{
    public class SliderService : ISliderService
    {
        private readonly DapperContext _context;

        public SliderService(DapperContext context)
        {
            _context = context;
        }
        public async Task CreateSliderAsync(CreateSliderDto dto)
        {
            string query = "Insert Into TblSlider (ImageUrl,Title,Location,Description,Price,Status) values (@imageUrl,@title,@location,@description,@price,@status)";

            var parameters = new DynamicParameters();
            parameters.Add("@imageUrl", dto.ImageUrl);
            parameters.Add("@title", dto.Title);
            parameters.Add("@location", dto.Location);
            parameters.Add("@description", dto.Description);
            parameters.Add("@price", dto.Price);
            parameters.Add("@status", dto.Status);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

        }

        public async Task DeleteSliderAsync(int id)
        {
            string query = "Delete From TblSlider Where SliderId=@sliderId";
            var parameters = new DynamicParameters();
            parameters.Add("@sliderId", id);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<List<ResultSliderDto>> GetAllSliderAsync()
        {
            string query = "Select * From TblSlider";
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<ResultSliderDto>(query);
            return values.ToList();
        }

        public async Task<GetByIdSliderDto> GetSliderAsync(int id)
        {
            string query = "Select * From TblSlider Where SliderId=@sliderId";
            var parameters = new DynamicParameters();
            parameters.Add("@sliderId", id);
            var connection = _context.CreateConnection();
            var values = await connection.QueryFirstOrDefaultAsync<GetByIdSliderDto>(query, parameters);
            return values;
        }

        public async Task UpdateSliderAsync(UpdateSliderDto dto)
        {
            string query = "Update TblSlider Set ImageUrl=@imageUrl, Title=@title, Location=@location, Description=@description, Price=@price, Status=@status Where SliderId=@sliderId";

            var parameters = new DynamicParameters();
            parameters.Add("@sliderId", dto.SliderId);
            parameters.Add("@imageUrl", dto.ImageUrl);
            parameters.Add("@title", dto.Title);
            parameters.Add("@location", dto.Location);
            parameters.Add("@description", dto.Description);
            parameters.Add("@price", dto.Price);
            parameters.Add("@status", dto.Status);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
