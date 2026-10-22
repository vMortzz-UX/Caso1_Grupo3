using System.Linq;
using System.Net;
using System.Web.Mvc;
using CRUDProductosMVC.Models;

namespace CRUDProductosMVC.Controllers
{
    public partial class ProductosController : Controller
    {
        private readonly ProductoContext db = new ProductoContext();

        // GET: Productos
        public ActionResult Index()
        {
            var productos = db.Productos.OrderBy(p => p.Nombre).ToList();
            return View(productos);
        }

        // GET: Productos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var producto = db.Productos.Find(id);
            if (producto == null)
                return HttpNotFound();

            return View(producto);
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            return View(new Producto());
        }

        // POST: Productos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "Codigo,Nombre,Categoria,Precio,Existencia,Activo")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Productos.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = producto.Id });
            }

            return View(producto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
    }
}