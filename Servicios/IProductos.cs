namespace NewApo.Servicios;
using NewApo.Modelos;

public interface IProductos
{
    IEnumerable<ClaseProductos> GetAll();
    ClaseProductos GetById(int id);
    ClaseProductos Create(ClaseProductos producto);
    void Update(int id, ClaseProductos producto);
    void Delete(int id);
}