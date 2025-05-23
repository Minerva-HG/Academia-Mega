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

        private readonly IProductoApiService _api;
        public ProductosController(IProductoApiService api) => _api = api;

        //GetProductos
        public async Task<IActionResult> Index()
        {
            var products = await _api.GetAllAsync();
            return View(products);
        }

        // //Get Productos/Create
        // public IActionResult Create() -> View();

        // //POST Productos/Create
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Create(Producto producto)
        // { 

        // }



       

        // public Task<IActionResult> Details(int id)
        // {            
        //     return View(new Producto());

        // }
    }


}