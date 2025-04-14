namespace NewApo.Servicios;
using NewApo.Modelos;

public class MetodosProductos : IProductos
{ 
    private readonly List<ClaseProductos> _productos = new()
    {
        new ClaseProductos { Id = 1, Nombre = "Lata de Atun", Precio = 1.99m, Stock = 10, Categoria = "Alimentos"},
        new ClaseProductos { Id = 2, Nombre = "Esponja", Precio = 1m, Stock = 20, Categoria = "Limpieza"},
        new ClaseProductos { Id = 3, Nombre = "Coca Cola", Precio = 2.99m, Stock = 15, Categoria = "Bebidas"},
        new ClaseProductos { Id = 4, Nombre = "Agua 5Lts", Precio = 10m, Stock = 5, Categoria = "Bebidas",}
    };
    public IEnumerable<ClaseProductos> GetAll() => _productos;

    public ClaseProductos GetById(int id) => _productos.FirstOrDefault(p => p.Id == id)!;
    public ClaseProductos Create(ClaseProductos producto)
    {
        producto.Id = _productos.Max(p => p.Id) + 1;
        _productos.Add(producto);
        return producto;
    }
    public void Update(int id, ClaseProductos producto)
    {
        var existingProduct = GetById(id);
        if (existingProduct != null)
        {
            existingProduct.Nombre = producto.Nombre;
            existingProduct.Precio = producto.Precio;
            existingProduct.Stock = producto.Stock;
            existingProduct.Categoria = producto.Categoria;
        }
    }           
    public void Delete(int id)
    {
        var producto = GetById(id);
        if (producto != null)
        {
            _productos.Remove(producto);
        }
    }
}