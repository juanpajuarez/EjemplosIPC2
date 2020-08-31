using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Clase6.Models;
using Clase6.Models.ViewModels;

namespace Clase6.Controllers
{
    public class getProductController : Controller
    {
        // GET: getProduct
        public ActionResult getProductos()
        {
            List<getProductViewModel> listaProductos;
            using (Clase6Entities db = new Clase6Entities())
            {
                listaProductos = (from d in db.Producto
                                  select new getProductViewModel
                                  {
                                      nombre = d.nombre,
                                      precio = (double)d.precio,
                                      categoria = d.Categoria1.nombre
                                  }).ToList();
            }

                return View(listaProductos);
        }
    

        public ActionResult AgregarProducto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarProducto(addProductViewModel modelo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (Clase6Entities db = new Clase6Entities())
                    {
                        var producto = new Producto();
                        producto.nombre = modelo.nombre;
                        producto.precio = modelo.precio;
                        producto.categoria = modelo.categoria;

                        db.Producto.Add(producto);
                        db.SaveChanges();
                    }
                    return Redirect("~/getProduct/getProductos");
                }
                return View(modelo);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}