using DapperProject.Services.AgentServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperProject.Controllers
{
    public class AgentController : Controller
    {
        private readonly IAgentService _agentService;

        public AgentController(IAgentService agentService)
        {
            _agentService = agentService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _agentService.GetAllAgentsAsync();
            return View(values);
        }
    }
}
