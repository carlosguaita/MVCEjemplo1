using Ejemplo1.Models;

namespace Ejemplo1.Services
{
    public interface IAPIService
    {
        Task<List<Producto>> GetProductos();
        Task<Producto> GetProducto(int IdProducto);
        Task<Producto> PostProducto(Producto producto);

        Task<Producto> PutProducto(int IdProducto, Producto producto);
        Task<string> DeleteProducto(int IdProdcuto);

    }
}
