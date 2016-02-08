using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Turtle.ORM;

namespace Turtle.Controllers
{
    public class ClansController : Controller
    {
        private TurtleEntities db = new TurtleEntities();

        // GET: Clans
        public ActionResult Index()
        {
            
            return View(db.uspClanList().ToList());
        }



        // GET: Clans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clan clan = db.Clan.Find(id);
            if (clan == null)
            {
                return HttpNotFound();
            }
            return View(clan);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,IsEvil")] Clan clan, HttpPostedFileBase upload)
        {
            if (upload != null && upload.ContentLength > 0)
            {
                if (IsValidImage(upload.ContentType))
                {
                    var imagename = Guid.NewGuid().ToString()+Path.GetExtension(upload.FileName);
                    var imageSavePath = Path.Combine(Server.MapPath("~/images"), imagename);
                    upload.SaveAs(imageSavePath);
                    clan.SymbolPic = Url.Content("images/"+imagename);
                }
                else
                {
                    ModelState.AddModelError("ImageExtension", "Please select an image file");
                }              
            }       
               

            if (ModelState.IsValid)
            {              
                db.Clan.Add(clan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clan);
        }

        // GET: Clans/Edit/GUID
        public ActionResult Edit(Guid? guid)
        {
            if (!guid.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var clan = db.uspClanSelect(guid.Value).FirstOrDefault();
            if (clan == null)
            {
                return HttpNotFound();
            }
            return View(clan);
        }

        //// GET: Clans/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (!id.HasValue)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Clan clan = db.Clan.Find(id);
        //    if (clan == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(clan);
        //}

        // POST: Clans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Name,IsEvil,ClanGUID")] Clan clan, HttpPostedFileBase upload)
        {
            if (upload != null && upload.ContentLength > 0)
            {
                if (IsValidImage(upload.ContentType))
                {
                    var imagename = Guid.NewGuid().ToString() + Path.GetExtension(upload.FileName);
                    var imageSavePath = Path.Combine(Server.MapPath("~/images"), imagename);
                    upload.SaveAs(imageSavePath);
                    //To load in view
                    clan.SymbolPic = Url.Content("images/"+imagename);
                }
                else
                {
                    ModelState.AddModelError("ImageExtension", "Please select an image file");
                }
            }

            if (ModelState.IsValid)
            {
                db.Entry(clan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clan);
        }

        // GET: Clans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clan clan = db.Clan.Find(id);
            if (clan == null)
            {
                return HttpNotFound();
            }
            return View(clan);
        }

        // POST: Clans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clan clan = db.Clan.Find(id);
            db.Clan.Remove(clan);
            db.SaveChanges();
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


        //To validate Image
        private bool IsValidImage(string contentType)
        {
            var validImageTypes = new string[]
            {
                "image/gif",
                "image/jpeg",
                "image/pjpeg",
                "image/png"
            };

            if (validImageTypes.Contains(contentType))
                return true;

            return false;
        }

    }
}
