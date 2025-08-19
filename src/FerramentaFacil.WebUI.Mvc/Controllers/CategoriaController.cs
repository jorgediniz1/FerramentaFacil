using FerramentaFacil.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FerramentaFacil.WebUI.Mvc.Controllers
{
    public class CategoriaController : Controller
    {

        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categorias = await _categoriaService.ObterTodasAsync();
            return View(categorias);
        }
    }
}
