using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Banco.Models;
using System.IO;

namespace Banco.Controllers
{
    public class PostsController : Controller
    {
        private int aidi;
        private ApplicationDbContext db = new ApplicationDbContext();
        Post post = new Post();

        // GET: Posts
        public async Task<ActionResult> Index()
        {
            return View(await db.Posts.ToListAsync());
        }

        public async Task<ActionResult> Bienes()
        {
            return View();
        }

        // GET: Posts/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = await db.Posts.FindAsync(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Posts/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "tittle,description,contenido,image,likes,provincia,lote,precio")]
        Post post,HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                var filePathOriginal = Server.MapPath("/Content/uploads/images");
                string savedFileName = Path.Combine(filePathOriginal, Image.FileName);
                post.image = @"/Content/uploads/images/" + Image.FileName;
                db.Posts.Add(post);
                await db.SaveChangesAsync();
                Image.SaveAs(savedFileName);
                
                return RedirectToAction("Index");
            }

            return View(post);
        }

        // GET: Posts/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = await db.Posts.FindAsync(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_post,tittle,description,contenido,image,likes,provincia,lote,precio")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: Posts/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = await db.Posts.FindAsync(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        public async Task<ActionResult> likes(int id)
        {
            foreach (var item in db.Posts)
            {
                if (item.id_post == id)
                {
                }
            }
                    return View();
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Post post = await db.Posts.FindAsync(id);
            db.Posts.Remove(post);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


    
        public ActionResult PostsBienes([Bind(Include = "comment")] Coment  coment ,int id)
        {
         
            this.aidi = id;   
            foreach (var item in db.Posts)
            {
                if(item.id_post == aidi)
                {
                    ViewData["id_post"] = item.id_post;
                    ViewData["imagen"] = item.image;
                    ViewData["tittle"] = item.tittle;
                    ViewData["description"] = item.description;
                    ViewData["contenido"] = item.contenido;
                    ViewData["id_post"] = item.id_post;
                    ViewData["lote"] = item.lote;
                    ViewData["precio"] = item.precio;
                    ViewData["provincia"] = item.provincia;
                    ViewData["likes"] = item.likes;
                    
                }
            }
            return View("Bienes");
        }



        public async Task<ActionResult> Enviar([Bind(Include = "id_comment,usuario,comment,id_post")] Coment comment)
        {
            string url = HttpContext.Request.Url.AbsolutePath;
            string url2 = HttpContext.Request.Url.PathAndQuery;

            if (ModelState.IsValid)
            {
                //permite conocer el usuario q esta conectado
                comment.usuario = HttpContext.User.Identity.Name;
                db.Coments.Add(comment);
                await db.SaveChangesAsync();
            }
            return RedirectToAction("Index");
           
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Bienes([Bind(Include = "tittle,description,contenido,image,likes,provincia")]
        //Post post, HttpPostedFileBase Image)
        //{

        //    return View();
        //}
        //public ActionResult PostsBienes()
        //{
        //    string url = HttpContext.Request.Url.AbsolutePath;
        //    string userName = HttpContext.User.Identity.Name;
        //    if (userName == "")
        //    {
        //        ViewData["error"] = "Para poder comentar debes iniciar sesion primero";
        //    }
        //    return View(url);

        //}
    }

}
