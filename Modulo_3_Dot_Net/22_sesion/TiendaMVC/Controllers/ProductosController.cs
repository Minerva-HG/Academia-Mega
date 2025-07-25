using Microsoft.AspNetCore.Mvc;
using TiendaMVC.Services;
using TiendaMVC.Models;
using System.Collections.Generic;

namespace TiendaMVC.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ApiClient _api;
        public ProductosController(ApiClient api) => _api = api;

        // GET /Productos
        public async Task<IActionResult> Index()
        {
            var products = await _api.GetProductosAsync();
            return View(products);
        }

        // GET /Productos/Details/1 
        public async Task<IActionResult> Details(int id)
        {
            var product = await _api.GetProductoByIdAsync(id);

            if (product == null) return NotFound();
            return View(product);
        }

        // GET /Productos/Create
        public IActionResult Create() => View();

        // POST /Productos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Producto producto)
        {
            if (!ModelState.IsValid) return View(producto);

            var created = await _api.CreateProductoAsync(producto);

            if (created == null)
            {
                ModelState.AddModelError("", "Error, al crear el producto");
                return View(producto);
            }
            return RedirectToAction(nameof(Index));

        }

        //GET /Productos/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _api.GetProductoByIdAsync(id);

            if (product == null) return NotFound();
            return View(product);
        }

        // POST /Productos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Producto producto)
        {
            if (id != producto.Id) return BadRequest();
            if (!ModelState.IsValid) return View(producto);

            var ok = await _api.UpdateProductoAsync(id, producto);
            if (!ok)
            {
                ModelState.AddModelError("", "Error, al actualizar el producto");
                return View(producto);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET /Productos/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _api.GetProductoByIdAsync(id);

            if (product == null) return NotFound();
            return View(product);
        }

        // POST /Productos/DeleteConfirmed/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ok = await _api.DeleteProductoAsync(id);
            if (!ok)
            {
                // Opcional: podrías redirigir a una vista de error o mostrar mensaje
                ModelState.AddModelError("", "Error al eliminar el producto");
                var product = await _api.DeleteProductoAsync(id);
                return View("Delete", product);
            }

            return RedirectToAction(nameof(Index));
        }

    }
}