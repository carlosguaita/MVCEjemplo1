using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ejemplo1.Utils;

namespace Ejemplo1.Controllers
{
    public class ProductoController : Controller
    {
        // GET: ProductoController
        public ActionResult Index()
        {
           
            return View(Utils.Utils.ListaProductos);
        }

        // GET: ProductoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductoController/Create
        public ActionResult Create()
        {
            return View();
        }


        // GET: ProductoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

       

        // GET: ProductoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

     
       
    }
}
