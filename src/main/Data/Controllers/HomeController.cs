using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EcoTrash.Data;
using EcoTrash.Models;

namespace EcoTrash.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                
                ViewBag.TotalEmpresas = await _context.Empresas.CountAsync(e => e.Ativo);
                ViewBag.TotalPesagens = await _context.Pesagens.CountAsync();
                ViewBag.TotalLocais = await _context.Locais.CountAsync();

               
                ViewBag.PesagensRecentes = await _context.Pesagens
                    .OrderByDescending(p => p.DataCadastro)
                    .Take(5)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                
                ViewBag.TotalEmpresas = 0;
                ViewBag.TotalPesagens = 0;
                ViewBag.TotalLocais = 0;
                ViewBag.PesagensRecentes = new List<Pesagem>();
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}