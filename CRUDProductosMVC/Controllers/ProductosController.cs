using System.Net;
using System.Web.Mvc;
using CRUDProductosMVC.DAL;
using CRUDProductosMVC.Models;

namespace CRUDProductosMVC.Controllers
{
    public class ProductosController : Controller
    {
        private readonly InventarioContext db = new InventarioContext();

        // EDIT - GET: muestra el producto que se va a modificar.
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Producto producto = db.Productos.Find(id.Value);
            if (producto == null)
                return HttpNotFound();

            return View(producto);
        }

        // EDIT - POST: valida y guarda los cambios.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Codigo,Nombre,Categoria,Precio,Existencia,Activo")] Producto producto)
        {
            if (!ModelState.IsValid)
                return View(producto);

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

        // DELETE - GET: muestra la confirmacion antes de eliminar.
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Producto producto = db.Productos.Find(id.Value);
            if (producto == null)
                return HttpNotFound();

            return View(producto);
        }

        // DELETE - POST: elimina el producto confirmado.
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }
    }
}
