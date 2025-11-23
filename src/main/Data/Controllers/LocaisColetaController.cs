using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EcoTrash.Models;
using EcoTrash.Data;

namespace EcoTrash.Controllers
{
    public class LocaisColetaController : Controller
    {
        private readonly AppDbContext _context;

        public LocaisColetaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: LocaisColeta
        public async Task<IActionResult> Index()
        {
            return View(await _context.Locais.ToListAsync());
        }

        // GET: LocaisColeta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localColeta = await _context.Locais
                .FirstOrDefaultAsync(m => m.Id == id);
            if (localColeta == null)
            {
                return NotFound();
            }

            return View(localColeta);
        }

        // GET: LocaisColeta/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LocaisColeta/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Estado,Cidade,Rua,Numero,Bairro")] LocalColeta localColeta)
        {
            if (ModelState.IsValid)
            {
                localColeta.DataCadastro = DateTime.Now;
                _context.Add(localColeta);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Local de coleta cadastrado com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            return View(localColeta);
        }

        // GET: LocaisColeta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localColeta = await _context.Locais.FindAsync(id);
            if (localColeta == null)
            {
                return NotFound();
            }
            return View(localColeta);
        }

        // POST: LocaisColeta/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Estado,Cidade,Rua,Numero,Bairro,DataCadastro")] LocalColeta localColeta)
        {
            if (id != localColeta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(localColeta);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Local de coleta atualizado com sucesso!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocalColetaExists(localColeta.Id))
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
            return View(localColeta);
        }

        // GET: LocaisColeta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localColeta = await _context.Locais
                .FirstOrDefaultAsync(m => m.Id == id);
            if (localColeta == null)
            {
                return NotFound();
            }

            return View(localColeta);
        }

        // POST: LocaisColeta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var localColeta = await _context.Locais.FindAsync(id);
            if (localColeta != null)
            {
                _context.Locais.Remove(localColeta);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Local de coleta excluído com sucesso!";
            }
            return RedirectToAction(nameof(Index));
        }

        private bool LocalColetaExists(int id)
        {
            return _context.Locais.Any(e => e.Id == id);
        }

        // API para obter locais em formato JSON (para mapas futuros)
        public async Task<IActionResult> GetLocaisJson()
        {
            var locais = await _context.Locais
                .Select(l => new {
                    l.Id,
                    l.Estado,
                    l.Cidade,
                    l.Rua,
                    l.Numero,
                    l.Bairro,
                    EnderecoCompleto = l.EnderecoCompleto(),
                    l.DataCadastro
                })
                .ToListAsync();

            return Json(locais);
        }
    }
}