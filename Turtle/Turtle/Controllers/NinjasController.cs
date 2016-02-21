using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TurtleDAL;
using Turtle.Helper;
using System.IO;

namespace Turtle.Controllers
{
    public class NinjasController : Controller
    {
        private TurtleEntities db       = new TurtleEntities();
        private Picture picture         = new Picture();
        private Pagination pagination   = new Pagination();

        // GET: Ninjas
        public ActionResult Index()
        {          
            return View();
        }

        public ActionResult List(int? pagenumber)
        {
            ViewBag.totalpage = pagination.GetPageCount(db.uspNinjaCount().FirstOrDefault() ?? 0);
            ViewBag.currentpage = pagenumber;

            return View(db.uspNinjaList(pagination.GetOffsetNumber(pagenumber),pagination.ItemCountPerPage).ToList());
        }

        // GET: Ninjas/Details/5
        public ActionResult Details(Guid? guid)
        {
            if (!guid.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var ninja = db.uspNinjaSelect(guid.Value).FirstOrDefault();
            if (ninja == null)
            {
                return HttpNotFound();
            }
            return View(ninja);
        }

        // GET: Ninjas/Create
        public ActionResult Create(int? id)
        {
            ViewBag.ClanID = new SelectList(db.uspClanList(), "ClanID", "Name",id??0);
            return View();
        }


        // POST: Ninjas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClanID,Name,Age,IsExperienced,IsAlive")] Ninja ninja, HttpPostedFileBase upload)
        {

            if (upload != null && upload.ContentLength > 0)
            {
                if (picture.IsValidImage(upload.ContentType))
                {
                    var imagename = picture.GetImageName(ninja.Picture, Path.GetExtension(upload.FileName));
                    var imagesavepath = Path.Combine(Server.MapPath("~/images/ninja/" + imagename));
                    upload.SaveAs(imagesavepath);
                    ninja.Picture = imagename;
                }
                else
                {
                    ModelState.AddModelError("Picture", "Please select an image file");
                }
            }


            if (ModelState.IsValid)
            {
                db.Ninja.Add(ninja);
                db.SaveChanges();
                return RedirectToAction("List");
            }

            ViewBag.ClanID = new SelectList(db.uspClanList(), "ClanID", "Name", ninja.ClanID);
            return View(ninja);
        }

        // GET: Ninjas/Edit/5
        public ActionResult Edit(Guid? guid)
        {
            if (!guid.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var ninja = db.uspNinjaSelect(guid.Value).SingleOrDefault();
            if (ninja == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClanID = new SelectList(db.Clan, "ClanID", "Name", ninja.ClanID);
            return View(ninja);
        }

        // POST: Ninjas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClanID,Name,Age,Picture,IsExperienced,IsAlive")] Ninja ninja, HttpPostedFileBase upload)
        {
            if (upload != null && upload.ContentLength > 0)
            {
                if (picture.IsValidImage(upload.ContentType))
                {
                    var imagename = picture.GetImageName(ninja.Picture, Path.GetExtension(upload.FileName));
                    var imagesavepath = Path.Combine(Server.MapPath("~/images/ninja/" + imagename));
                    upload.SaveAs(imagesavepath);
                    ninja.Picture = imagename;
                }
                else
                {
                    ModelState.AddModelError("Picture", "Please select an image file");
                }
            }
            if (ModelState.IsValid)
            {
                db.Entry(ninja).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClanID = new SelectList(db.Clan, "ClanID", "Name", ninja.ClanID);
            return View(ninja);
        }

        // GET: Ninjas/Delete/5
        public ActionResult Delete(Guid? guid)
        {
            if (!guid.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var ninja = db.uspNinjaSelect(guid.Value).SingleOrDefault();
            if (ninja == null)
            {
                return HttpNotFound();
            }
            return View(ninja);
        }

        // POST: Ninjas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid guid)
        {
            //If you want an exception to be thrown if the result set contains many records, 
                //use SingleOrDefault.
            //If you always want 1 record no matter what the result set contains, use FirstOrDefault

            Ninja ninja = db.Ninja.SingleOrDefault(m=>m.NinjaGUID == guid);
            if (ninja == null)
            {
                return HttpNotFound();
            }
            db.Ninja.Remove(ninja);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
                picture = null;
                pagination = null;
            }
            base.Dispose(disposing);
        }
    }
}
