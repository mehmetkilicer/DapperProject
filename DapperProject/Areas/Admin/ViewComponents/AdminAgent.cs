using DapperProject.Services.AgentServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperProject.Areas.Admin.ViewComponents
{
    public class AdminAgent : ViewComponent
    {
        private readonly IAgentService _agentService;

        public AdminAgent(IAgentService agentService)
        {
            _agentService = agentService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _agentService.GetAllAgentsAsync();
            return View(values);
        }
    }
}
