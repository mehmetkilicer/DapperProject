using Dapper;
using DapperProject.Context;
using DapperProject.Dtos.TestimonialDtos;

namespace DapperProject.Services.TestimonialServices
{
    public class TestimonialService : ITestimonialService
    {
        private readonly DapperContext _context;

        public TestimonialService(DapperContext context)
        {
            _context = context;
        }
        public async Task CreateTestimonialAsync(CreateTestimonialDto dto)
        {
            string query = "Insert Into TblTestimonial (FullName,Title,Description,ImageUrl) values (@fullName,@title,@description,@imageUrl)";

            var parameters = new DynamicParameters();
            parameters.Add("@fullName", dto.FullName);
            parameters.Add("@title", dto.Title);
            parameters.Add("@description", dto.Description);
            parameters.Add("@imageUrl", dto.ImageUrl);

            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteTestimonialAsync(int id)
        {
            string query = "Delete From TblTestimonial Where TestimonialId=@testimonialId";
            var parameters = new DynamicParameters();
            parameters.Add("@testimonialId", id);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<List<ResultTestimonialDto>> GetAllTestimonialAsync()
        {
            string query = "Select * From TblTestimonial";
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<ResultTestimonialDto>(query);
            return values.ToList();
        }

        public async Task<GetByIdTestimonialDto> GetTestimonialAsync(int id)
        {
            string query = "Select * From TblTestimonial Where TestimonialId=@testimonialId";
            var parameters = new DynamicParameters();
            parameters.Add("@testimonialId", id);
            var connection = _context.CreateConnection();
            var values = await connection.QueryFirstOrDefaultAsync<GetByIdTestimonialDto>(query, parameters);
            return values;
        }

        public async Task UpdateTestimonialAsync(UpdateTestimonialDto dto)
        {
            string query = "Update TblTestimonial Set FullName=@fullName, Title=@title, Description=@description, ImageUrl=@imageUrl Where TestimonialId=@testimonialId";
            var parameters = new DynamicParameters();
            parameters.Add("@fullName", dto.FullName);
            parameters.Add("@title", dto.Title);
            parameters.Add("@description", dto.Description);
            parameters.Add("@testimonialId", dto.TestimonialId);
            parameters.Add("@imageUrl", dto.ImageUrl);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
