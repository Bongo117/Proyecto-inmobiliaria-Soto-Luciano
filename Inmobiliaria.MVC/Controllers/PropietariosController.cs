using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inmobiliaria.MVC.Models;
using Inmobiliaria.MVC.Repositories;

namespace Inmobiliaria.MVC.Controllers
{
    public class PropietariosController : Controller
    {
        private readonly IPropietarioRepository _propietarioRepository;

        public PropietariosController(IPropietarioRepository propietarioRepository)
        {
            _propietarioRepository = propietarioRepository;
        }

        // GET: Propietarios
        public async Task<IActionResult> Index()
        {
            var propietarios = await _propietarioRepository.GetAllAsync();
            return View(propietarios);
        }

        // GET: Propietarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propietario = await _propietarioRepository.GetByIdAsync(id.Value);
            if (propietario == null)
            {
                return NotFound();
            }

            return View(propietario);
        }

        // GET: Propietarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Propietarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Dni,Apellido,Nombre,Email,Telefono,Domicilio,Estado")] Propietario propietario)
        {
            if (ModelState.IsValid)
            {
                await _propietarioRepository.AddAsync(propietario);
                return RedirectToAction(nameof(Index));
            }
            return View(propietario);
        }

        // GET: Propietarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propietario = await _propietarioRepository.GetByIdAsync(id.Value);
            if (propietario == null)
            {
                return NotFound();
            }
            return View(propietario);
        }

        // POST: Propietarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Dni,Apellido,Nombre,Email,Telefono,Domicilio,Estado")] Propietario propietario)
        {
            if (id != propietario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _propietarioRepository.UpdateAsync(propietario);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await PropietarioExists(propietario.Id))
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
            return View(propietario);
        }

        // GET: Propietarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propietario = await _propietarioRepository.GetByIdAsync(id.Value);
            if (propietario == null)
            {
                return NotFound();
            }

            return View(propietario);
        }

        // POST: Propietarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _propietarioRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> PropietarioExists(int id)
        {
            return await _propietarioRepository.GetByIdAsync(id) != null;
        }
    }
}
