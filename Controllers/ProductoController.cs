using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ejemplo1.Utils;
using Ejemplo1.Models;
using Ejemplo1.Service;
using System.Runtime.InteropServices;
using Ejemplo1.Service;

namespace Ejemplo1.Controllers
{
    public class ProductoController : Controller
    {

        private readonly IAPIService _apiService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductoController(IAPIService apiService, IWebHostEnvironment webHostEnvironment)
        {
            _apiService = apiService;
            _webHostEnvironment = webHostEnvironment;
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
        public async Task<IActionResult> Details(int IdProducto)
        {
            Producto producto = await _apiService.GetProducto(IdProducto);
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
        public async Task<IActionResult> Create(Producto producto, IFormFile? file)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString()+Path.GetExtension(file.FileName);
                string productPath = Path.Combine(wwwRootPath, @"images\products");
                using (var fileStream = new FileStream(Path.Combine(productPath,fileName),FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                producto.urlImage = @"\images\products\" + fileName;
               
            }
            Producto producto1 = await _apiService.PostProducto(producto);

            return RedirectToAction("Index");
        }



        // GET: ProductoController/Edit/5
        public async Task<IActionResult> Edit(int IdProducto)
        {
            Producto producto = await _apiService.GetProducto(IdProducto);
            if (producto != null)
            {
                return View(producto);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Producto producto, IFormFile? file)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (producto != null)
            {
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\products");
                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    producto.urlImage = @"\images\products\" + fileName;
                }
                Producto producto2 = await _apiService.PutProducto(producto.IdProducto, producto);

                return RedirectToAction("Index");
            }
            return View();
        }




        // GET: ProductoController/Delete/5
        public async Task<IActionResult> Delete(int IdProducto)
        {
            Boolean producto2 = await _apiService.DeleteProducto(IdProducto);
            if (producto2 != false)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

     
       
    }
}
