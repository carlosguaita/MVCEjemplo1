using Ejemplo1.Models;

namespace Ejemplo1.Utils
{
    public class Utils
    {

        static public List<Producto> ListaProductos = new List<Producto>()
        {
            new Producto{
                IdProducto=1,
                Nombre="Producto 1", 
                Descripcion="Descripcion 1",
                cantidad=1 
            },

            new Producto{
                IdProducto=2,
                Nombre = "Producto 2", 
                Descripcion="Descripcion 2",
                cantidad=2 
            }

        };

    }
}
