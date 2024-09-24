using DapperProject.Dtos.AgentDtos;

namespace DapperProject.Services.AgentServices
{
    public interface IAgentService
    {
        Task<List<ResultAgentDto>> GetAllAgentsAsync();
        Task<int> GetAgentCount();
        Task CreateAgentAsync(CreateAgentDto createAgentDto);
        Task UpdateAgentAsync(UpdateAgentDto updateAgentDto);
        Task DeleteAgentAsync(int id);
        Task<GetByIdAgentDto> GetByIdAgentAsync(int id);
    }
}
