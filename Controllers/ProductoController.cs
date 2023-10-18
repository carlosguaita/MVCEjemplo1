using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ejemplo1.Utils;
using Ejemplo1.Models;
using Ejemplo1.Services;

namespace Ejemplo1.Controllers
{
    public class ProductoController : Controller
    {

        private readonly IAPIService _apiService;

        public ProductoController(IAPIService apiService)
        {
            _apiService = apiService;
        }


            // GET: ProductoController
        public async Task<IActionResult> Index()
        {
            try
            {
                List<Producto> productos = await _apiService.GetProductos();
                return View(productos);

            }
            catch(Exception ex)
            {
                return View(new List<Producto>());

            }
           
        }

        // GET: ProductoController/Details/5
        public IActionResult Details(int IdProducto)
        {
            Producto producto = Utils.Utils.ListaProductos.Find(x => x.IdProducto == IdProducto);
            if (producto != null)
            {
                return View(producto);
            }
            return RedirectToAction("Index");
        }

        // GET: ProductoController/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Producto producto)
        {
            int i = Utils.Utils.ListaProductos.Count() + 1;
            producto.IdProducto = i;
            Utils.Utils.ListaProductos.Add(producto);
            return RedirectToAction("Index");
        }



        // GET: ProductoController/Edit/5
        public IActionResult Edit(int IdProducto)
        {
            Producto producto = Utils.Utils.ListaProductos.Find(x => x.IdProducto == IdProducto);
            if (producto != null)
            {
                return View(producto);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Producto producto)
        {
            Producto producto2 = Utils.Utils.ListaProductos.Find(x => x.IdProducto == producto.IdProducto);
            if (producto2 != null)
            {
                producto2.Nombre=producto.Nombre;
                producto2.Descripcion = producto.Descripcion;
                producto2.cantidad=producto.cantidad;

                return RedirectToAction("Index");
            }
            return View();
        }




        // GET: ProductoController/Delete/5
        public IActionResult Delete(int IdProducto)
        {
            Producto producto2 = Utils.Utils.ListaProductos.Find(x => x.IdProducto == IdProducto);
            if (producto2 != null)
            {
                Utils.Utils.ListaProductos.Remove(producto2);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

     
       
    }
}
