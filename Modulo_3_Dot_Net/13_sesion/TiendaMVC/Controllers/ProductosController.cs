using Microsoft.AspNetCore.Mvc;
using TiendaMVC.Models;
using System.Collections.Generic;
using TiendaMVC.Services;

namespace TiendaMVC.Controllers
{
    public class ProductosController : Controller
    {
        // private static readonly List<Producto> _productos = new()
        // {
        //     new Producto {Id = 1 , Nombre = "Chayomi 15 Ultra", Precio=33000.00m },
        //     new Producto {Id = 2 , Nombre = "Honor Magic 7 Pro", Precio=29000.00m }
        // };

        private readonly ApiClient _api;
        public ProductosController(ApiClient api) => _api = api;

        //GetProductos
        public async Task<IActionResult> Index()
        {
            var products = await _api.GetProductosAsync();
            return View(products);
        }


        public async Task<IActionResult> Details(int id)
        {
            var product = await _api.GetProductoByIdAsync(id);
            if (product == null) return NotFound();
            return View(product);
        }

        // //Get Productos/Create
        public IActionResult Create() => View();

        //POST Productos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Producto producto)
        {
            if (!ModelState.IsValid) return View(producto);

            var created = await _api.CreateProductoAsync(producto);
            if (created == null)
            {
                ModelState.AddModelError("", "Error al crear el producto");
                return View(producto);
            }
            return RedirectToAction(nameof(Index));
        }

        //Get /Producos/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _api.GetProductoByIdAsync(id);

            if (product == null) return NotFound();
            return View(product);


        }

        //POST /Productos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Producto producto)
        {
            if (id != producto.Id) return BadRequest();
            if (!ModelState.IsValid) return View(producto);
            var ok = await _api.UpdateProductoAsync(id , producto);
            if (!ok)
            {
                ModelState.AddModelError("", "Error al actualizar el producto");
                return View(producto);
            }
            return RedirectToAction(nameof(Index));

        }

        //GET: Productos/Delete/2        
        public async Task<IActionResult> Delete(int id)
        {
              var product = await _api.GetProductoByIdAsync(id);
              if (product == null) return NotFound();
              return View(product);
        }

        //POST /Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ok = await _api.DeleteProductoAsync(id);
            if (!ok)
            {
                ModelState.AddModelError("", "Error al eliminar el producto");
                var product = await _api.GetProductoByIdAsync(id);
                return View(product);
            }                        
            return RedirectToAction(nameof(Index));
        }        


    }


}