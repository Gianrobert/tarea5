using Microsoft.AspNetCore.Mvc;
using MiApiCRUD.Models;
using System.Collections.Generic;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class ProductosController : ControllerBase
{
    private static List<Producto> productos = new List<Producto>();

    // GET: api/productos
    [HttpGet]
    public ActionResult<List<Producto>> Get() => productos;

    // GET: api/productos/{id}
    [HttpGet("{id}")]
    public ActionResult<Producto> Get(int id)
    {
        var producto = productos.FirstOrDefault(p => p.Id == id);
        return producto != null ? Ok(producto) : NotFound();
    }

    // POST: api/productos
    [HttpPost]
    public ActionResult Post(Producto producto)
    {
        producto.Id = productos.Count + 1;
        productos.Add(producto);
        return CreatedAtAction(nameof(Get), new { id = producto.Id }, producto);
    }

    // PUT: api/productos/{id}
    [HttpPut("{id}")]
    public ActionResult Put(int id, Producto producto)
    {
        var existingProducto = productos.FirstOrDefault(p => p.Id == id);
        if (existingProducto == null) return NotFound();

        existingProducto.Nombre = producto.Nombre;
        existingProducto.Precio = producto.Precio;
        existingProducto.Stock = producto.Stock;
        return NoContent();
    }

    // DELETE: api/productos/{id}
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var producto = productos.FirstOrDefault(p => p.Id == id);
        if (producto == null) return NotFound();

        productos.Remove(producto);
        return NoContent();
    }
}

