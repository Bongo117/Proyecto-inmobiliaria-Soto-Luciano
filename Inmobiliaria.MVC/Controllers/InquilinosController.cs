using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inmobiliaria.MVC.Models;
using Inmobiliaria.MVC.Repositories;

namespace Inmobiliaria.MVC.Controllers
{
    public class InquilinosController : Controller
    {
        private readonly IInquilinoRepository _inquilinoRepository;

        public InquilinosController(IInquilinoRepository inquilinoRepository)
        {
            _inquilinoRepository = inquilinoRepository;
        }

        // GET: Inquilinos
        public async Task<IActionResult> Index()
        {
            var inquilinos = await _inquilinoRepository.GetAllAsync();
            return View(inquilinos);
        }

        // GET: Inquilinos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inquilino = await _inquilinoRepository.GetByIdAsync(id.Value);
            if (inquilino == null)
            {
                return NotFound();
            }

            return View(inquilino);
        }

        // GET: Inquilinos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Inquilinos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Dni,Apellido,Nombre,Email,Telefono,Domicilio,Estado")] Inquilino inquilino)
        {
            if (ModelState.IsValid)
            {
                await _inquilinoRepository.AddAsync(inquilino);
                return RedirectToAction(nameof(Index));
            }
            return View(inquilino);
        }

        // GET: Inquilinos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inquilino = await _inquilinoRepository.GetByIdAsync(id.Value);
            if (inquilino == null)
            {
                return NotFound();
            }
            return View(inquilino);
        }

        // POST: Inquilinos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Dni,Apellido,Nombre,Email,Telefono,Domicilio,Estado")] Inquilino inquilino)
        {
            if (id != inquilino.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _inquilinoRepository.UpdateAsync(inquilino);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await InquilinoExists(inquilino.Id))
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
            return View(inquilino);
        }

        // GET: Inquilinos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inquilino = await _inquilinoRepository.GetByIdAsync(id.Value);
            if (inquilino == null)
            {
                return NotFound();
            }

            return View(inquilino);
        }

        // POST: Inquilinos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _inquilinoRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> InquilinoExists(int id)
        {
            return await _inquilinoRepository.GetByIdAsync(id) != null;
        }
    }
}
