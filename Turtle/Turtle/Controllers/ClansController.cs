using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Turtle.Helper;
using TurtleDAL;


namespace Turtle.Controllers
{
    public class ClansController : Controller
    {
        private TurtleEntities db = new TurtleEntities();

        private Picture picture = new Picture();

        private Pagination pagination = new Pagination();


        // GET: Clans
        public ActionResult Index(int? currentpage)
        {
                             
            ViewBag.totalpages = pagination.GetPageCount(db.uspClanCount().FirstOrDefault() ?? 0);

            var ClanList = db.uspClanList(pagination.GetOffsetNumber(currentpage), pagination.ItemCountPerPage);

            return View(ClanList);
        }


        // GET: Clans/Create
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,IsEvil")] Clan clan, HttpPostedFileBase upload)
        {
            if (upload != null && upload.ContentLength > 0)
            {
                if (picture.IsValidImage(upload.ContentType))
                {

                    var imagename = picture.GetImageName(clan.SymbolPic, Path.GetExtension(upload.FileName));
                    var imageSavePath = Path.Combine(Server.MapPath("~/images"), imagename);
                    upload.SaveAs(imageSavePath);
                    clan.SymbolPic = imagename;
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
            var clan = db.uspClanSelect(guid.Value).SingleOrDefault();
            if (clan == null)
            {
                return HttpNotFound();
            }
            return View(clan);
        }

        // POST: Clans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Name,IsEvil,SymbolPic,ClanGUID")] Clan clan, HttpPostedFileBase upload)
        {
            if (upload != null && upload.ContentLength > 0)
            {
                if (picture.IsValidImage(upload.ContentType))
                {
                   
                    //To save New Image on old image
                    string imagename = picture.GetImageName(clan.SymbolPic, Path.GetExtension(upload.FileName));
                    var imageSavePath = Path.Combine(Server.MapPath("~/images"), imagename);
                    upload.SaveAs(imageSavePath);
                    clan.SymbolPic = imagename;
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


        public ActionResult Details(Guid? guid)
        {
            if (!guid.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var clan = db.uspClanSelect(guid.Value).SingleOrDefault();
            if (clan == null)
            {
                return HttpNotFound();
            }
            return View(clan);
        }

        // GET: Clans/Delete/5
        public ActionResult Delete(Guid? guid)
        {
            if (!guid.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var clan = db.uspClanSelect(guid.Value).SingleOrDefault();
            if (clan == null)
            {
                return HttpNotFound();
            }
            return View(clan);
        }

        // POST: Clans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid guid)
        {
            Clan clan = db.Clan.SingleOrDefault(m=>m.ClanGUID == guid );
            if (clan == null)
            {
                return HttpNotFound();
            }
            db.Clan.Remove(clan);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

       
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
                //Remove other objects also;
                picture = null;
                pagination = null;

            }
            base.Dispose(disposing);
        }


     
       

    }
}
