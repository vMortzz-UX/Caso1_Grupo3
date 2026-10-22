
using System.Web.Mvc;
using CRUDProductosMVC.Models;

namespace CRUDProductosMVC.Controllers
{
    public class ProductosController : Controller
    {
        // EDIT - GET
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(400);

            Producto producto = db.Productos.Find(id);

            if (producto == null)
                return HttpNotFound();

            return View(producto);
        }

        // EDIT - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Producto producto)
        {
            if (ModelState.IsValid)
            {
                Producto existente = db.Productos.Find(producto.Id);

                if (existente == null)
                    return HttpNotFound();

                existente.Codigo = producto.Codigo;
                existente.Nombre = producto.Nombre;
                existente.Categoria = producto.Categoria;
                existente.Precio = producto.Precio;
                existente.Existencia = producto.Existencia;
                existente.Activo = producto.Activo;

                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(producto);
        }

        // DELETE - GET
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(400);

            Producto producto = db.Productos.Find(id);

            if (producto == null)
                return HttpNotFound();

            return View(producto);
        }

        // DELETE - POST
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Producto producto = db.Productos.Find(id);

            if (producto == null)
                return HttpNotFound();

            db.Productos.Remove(producto);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
