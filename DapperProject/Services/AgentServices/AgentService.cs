using Dapper;
using DapperProject.Context;
using DapperProject.Dtos.AgentDtos;

namespace DapperProject.Services.AgentServices
{
    public class AgentService : IAgentService
    {
        private readonly DapperContext _context;

        public AgentService(DapperContext context)
        {
            _context = context;
        }
        public async Task CreateAgentAsync(CreateAgentDto createAgentDto)
        {
            string query = "insert into TblAgent (AgentName,Description,ImageUrl) values (@AgentName,@Description,@ImageUrl)";
            var parameters = new DynamicParameters();
            parameters.Add("@AgentName", createAgentDto.AgentName);
            parameters.Add("@Description", createAgentDto.Description);
            parameters.Add("@ImageUrl", createAgentDto.ImageURL);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteAgentAsync(int id)
        {
            string query = "Delete From TblAgent Where AgentId=@AgentId";
            var parameters = new DynamicParameters();
            parameters.Add("@AgentId", id);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<int> GetAgentCount()
        {
            string query = "Select Count(*) From TblAgent";
            var connection = _context.CreateConnection();
            int value = await connection.QueryFirstOrDefaultAsync<int>(query);
            return value;
        }

        public async Task<List<ResultAgentDto>> GetAllAgentsAsync()
        {
            string query = "Select * From TblAgent";
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<ResultAgentDto>(query);
            return values.ToList();
        }

        public async Task<GetByIdAgentDto> GetByIdAgentAsync(int id)
        {
            string query = "Select * From TblAgent Where AgentId=@AgentId";
            var parameters = new DynamicParameters();
            parameters.Add("@AgentId", id);
            var connection = _context.CreateConnection();
            var values = await connection.QueryFirstOrDefaultAsync<GetByIdAgentDto>(query, parameters);
            return values;
        }

        public async Task UpdateAgentAsync(UpdateAgentDto updateAgentDto)
        {
            string query = "Update TblAgent Set AgentName=@AgentName,Description=@Description,ImageUrl=@ImageUrl where AgentId=@AgentId";
            var parameters = new DynamicParameters();
            parameters.Add("@AgentName", updateAgentDto.AgentFullName);
            parameters.Add("@Description", updateAgentDto.Title);
            parameters.Add("@ImageUrl", updateAgentDto.ImageUrl);
            parameters.Add("@AgentId", updateAgentDto.AgentId);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
