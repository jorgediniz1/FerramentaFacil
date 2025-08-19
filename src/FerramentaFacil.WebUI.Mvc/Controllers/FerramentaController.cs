using FerramentaFacil.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FerramentaFacil.WebUI.Mvc.Controllers
{
    public class FerramentaController : Controller
    {

        private readonly IFerramentaService _ferramentaService;

        public FerramentaController(IFerramentaService ferramentaService)
        {
            _ferramentaService = ferramentaService;
        }
        public async Task<IActionResult> Index()
        {
            var ferramentas = await _ferramentaService.ObterTodasAsync();   
            return View(ferramentas);
        }
    }
}
