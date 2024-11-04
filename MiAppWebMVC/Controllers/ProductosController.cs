using Microsoft.AspNetCore.Mvc;
using MiAppWebMVC.Models;
using MiAppWebMVC.Services;
using System.Threading.Tasks;

namespace MiAppWebMVC.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ProductoService _productoService;

        public ProductosController(ProductoService productoService)
        {
            _productoService = productoService;
        }

     
        public async Task<IActionResult> Index()
        {
            var productos = await _productoService.GetProductosAsync();
            return View(productos);
        }

       
        public IActionResult Create() => View();

        
        [HttpPost]
        public async Task<IActionResult> Create(Producto producto)
        {
            if (ModelState.IsValid)
            {
                await _productoService.CreateProductoAsync(producto);
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, Producto producto)
        {
            if (ModelState.IsValid)
            {
                await _productoService.UpdateProductoAsync(producto);
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

       
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _productoService.DeleteProductoAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}