using Dapper;
using DapperProject.Context;
using DapperProject.Dtos.CategoryDtos;

namespace DapperProject.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly DapperContext _context;
        public CategoryService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            string query = "Insert Into TblCategory (CategoryName) values (@categoryName)";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryName", createCategoryDto.CategoryName);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            string query = "Delete From TblCategory Where CategoryId=@categoryId";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryId", id);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            string query = "Select * From TblCategory";
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<ResultCategoryDto>(query);
            return values.ToList();
        }

        public async Task<GetByIdCategoryDto> GetCategoryAsync(int id)
        {
            string query = "Select * From TblCategory Where CategoryId=@categoryId";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryId", id);
            var connection = _context.CreateConnection();
            var values = await connection.QueryFirstOrDefaultAsync<GetByIdCategoryDto>(query, parameters);
            return values;
        }

        public async Task<int> GetCategoryCount()
        {
            string query = "Select Count(*) From TblCategory";
            var connection = _context.CreateConnection();
            int value = await connection.QueryFirstOrDefaultAsync<int>(query);
            return value;
        }

        public async Task<List<GetCategoryWithCountDto>> GetCategoryWithCount()
        {
            string query = "SELECT COUNT(*) AS 'CategoryCount', CategoryName,        TblCategory.CategoryId FROM TblProperty INNER JOIN TblCategory     ON TblProperty.CategoryId = TblCategory.CategoryId GROUP BY TblCategory.CategoryId, CategoryName;";
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<GetCategoryWithCountDto>(query);
            return values.ToList();
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            string query = "Update TblCategory Set CategoryName=@categoryName where CategoryId=@categoryId";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryName", updateCategoryDto.CategoryName);
            parameters.Add("@categoryId", updateCategoryDto.CategoryId);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
