using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewApo.Modelos;
using NewApo.Servicios;


namespace NewApo.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")] 
public class ProductosController : ControllerBase
{
    private readonly IProductos _metodosProductos;
    public ProductosController(IProductos metodosProducto)
    {
        _metodosProductos = metodosProducto;
    }
    [HttpGet("GetAll")]
    [Authorize]
    public IActionResult Get()
    {
        var products = _metodosProductos.GetAll();
        return Ok(products);
    }
    [HttpGet("GetById/{id}")]
    [Authorize]
    public IActionResult GetById(int id)
    {
        var product = _metodosProductos.GetById(id);
        if (product == null) 
            return NotFound();
        return Ok(product);
    }
    [HttpPost("Create")]
    [Authorize]
    public IActionResult Create([FromBody] ClaseProductos producto)
    {
        if (producto == null)
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
        var nuevoProducto = _metodosProductos.Create(producto);
        return Ok(CreatedAtAction(nameof(GetById), new {id = nuevoProducto.Id}, nuevoProducto));
    }
    [HttpPut("Editar/{id}")]
    [Authorize]
    public IActionResult Update(int id, [FromBody] ClaseProductos producto)
    {
        var productoActual = _metodosProductos.GetById(id);
        if (productoActual == null)
            return NotFound();
        _metodosProductos.Update(id, producto);
        return Ok(new {
            Mensaje = "Producto actualizado correctamente",
            Producto = productoActual,
            ListaCompleta = _metodosProductos.GetAll()
        });
    }
    [HttpDelete("Delete/{id}")]
    [Authorize]
    public IActionResult Delete(int id)
    {
        var producto = _metodosProductos.GetById(id);
        if (producto == null)
            return NotFound();
        _metodosProductos.Delete(id);
        return Ok(new {
            Mensaje = "Producto elimidano correctamente",
        });
    }
}