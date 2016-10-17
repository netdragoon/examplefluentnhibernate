using Models;
using Repositories;
using Repositories.Interfaces;
using System.Collections.Generic;
using System.Web.Mvc;

namespace WebApp.Controllers
{       
    public class UsuariosController : Controller
    {
        public IConnection conn;
        public RepositoryUsuarioImplementation rep;
        public UsuariosController()
        {
            conn = new Connection();
            rep = new RepositoryUsuario(conn);
        }
        // GET: Usuarios
        [Route("usuarios", Name = "usuarios")]
        public ActionResult Index()
        {
            return View(rep.ToList());
        }

        // GET: Usuarios/Details/5
        [Route("usuarios/details/{id}", Name = "usuarios.details")]
        public ActionResult Details(long id)
        {
            return View(rep.Find(id));
        }

        // GET: Usuarios/Create
        [Route("usuarios/create", Name = "usuarios.get.create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        [HttpPost]
        [Route("usuarios/create", Name = "usuarios.post.create")]
        public ActionResult Create(Usuario usuario)
        {
            try
            {
                rep.Add(usuario);               

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuarios/Edit/5
        [Route("usuarios/edit/{id}", Name = "usuarios.get.edit")]
        public ActionResult Edit(long id)
        {
            return View(rep.Find(id));
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        [Route("usuarios/edit/{id}", Name = "usuarios.post.edit")]
        public ActionResult Edit(long id, Usuario usuario)
        {
            try
            {
                rep.Edit(usuario);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuarios/Delete/5
        [Route("usuarios/delete/{id}", Name = "usuarios.get.delete")]
        public ActionResult Delete(long id)
        {
            return View(rep.Find(id));
        }

        // POST: Usuarios/Delete/5
        [HttpPost]
        [Route("usuarios/delete/{id}", Name = "usuarios.post.delete")]
        public ActionResult Delete(long id, Usuario usuario)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet()]        
        public JsonResult isExistEmail(string email, long? id)
        {
            bool result = false;

            IDictionary<string, object> parameters = new Dictionary<string, object>(1);
            parameters.Add("email", email);

            Usuario usuario = rep.First("FROM Usuario u WHERE u.email = :email", parameters);
            
            if (id.HasValue)
            {
                result = usuario == null 
                    ? true : 
                    usuario.id == id.Value;                
            }
            else
            {
                result = usuario == null;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
