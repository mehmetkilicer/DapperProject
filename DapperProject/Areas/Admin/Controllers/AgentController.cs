using DapperProject.Dtos.AgentDtos;
using DapperProject.Services.AgentServices;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DapperProject.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class AgentController : Controller
    {
        private readonly IAgentService _agentService;

        public AgentController(IAgentService agentService)
        {
            _agentService = agentService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _agentService.GetAllAgentsAsync());
        }
        public async Task<IActionResult> DeleteAgent(int id)
        {
            await _agentService.DeleteAgentAsync(id);
            return RedirectToAction("Index");
        }
        public IActionResult CreateAgent()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAgent(CreateAgentDto createAgentDto)
        {
            await _agentService.CreateAgentAsync(createAgentDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdateAgent(int id)
        {
            var agent = await _agentService.GetByIdAgentAsync(id);
            var updateAgentDto = new UpdateAgentDto
            {
                AgentId = agent.AgentId, // AgentId'yi burada dolduruyoruz
                AgentFullName = agent.AgentName,
                ImageUrl = agent.ImageURL,
                Title = agent.Description,
            };
            return View(updateAgentDto);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateAgent(UpdateAgentDto updateAgentDto)
        {
            if (!ModelState.IsValid)
            {
                return View(updateAgentDto); // Hata durumunda aynı modeli döndürün
            }

            await _agentService.UpdateAgentAsync(updateAgentDto);
            return RedirectToAction("Index");
        }

    }
}
