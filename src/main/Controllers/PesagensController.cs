using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EcoTrash.Models;
using EcoTrash.Data;

namespace EcoTrash.Controllers
{
    public class PesagensController : Controller
    {
        private readonly AppDbContext _context;

        public PesagensController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Pesagens
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pesagens.ToListAsync());
        }

        // GET: Pesagens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pesagem = await _context.Pesagens
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pesagem == null)
            {
                return NotFound();
            }

            return View(pesagem);
        }

        // GET: Pesagens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pesagens/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TipoMaterial,Peso,Localizacao")] Pesagem pesagem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pesagem);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Pesagem registrada com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            return View(pesagem);
        }

        // GET: Pesagens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pesagem = await _context.Pesagens.FindAsync(id);
            if (pesagem == null)
            {
                return NotFound();
            }
            return View(pesagem);
        }

        // POST: Pesagens/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TipoMaterial,Peso,Localizacao")] Pesagem pesagem)
        {
            if (id != pesagem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pesagem);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Pesagem atualizada com sucesso!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PesagemExists(pesagem.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pesagem);
        }

      

        // GET: Pesagens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pesagem = await _context.Pesagens
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pesagem == null)
            {
                return NotFound();
            }

            return View(pesagem);
        }

        // POST: Pesagens/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var pesagem = await _context.Pesagens.FindAsync(id);
                if (pesagem != null)
                {
                    _context.Pesagens.Remove(pesagem);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Pesagem excluída com sucesso!";
                }
                else
                {
                    TempData["ErrorMessage"] = "Pesagem não encontrada.";
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Erro ao excluir pesagem: {ex.Message}";
            }

            return RedirectToAction(nameof(Index));
        }

        private bool PesagemExists(int id)
        {
            return _context.Pesagens.Any(e => e.Id == id);
        }
    }
}