using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TurtleDAL;

namespace Turtle.Controllers
{
    public class NinjasController : Controller
    {
        private TurtleEntities db = new TurtleEntities();

        // GET: Ninjas
        public async Task<ActionResult> Index()
        {
            var ninja = db.Ninja.Include(n => n.Clan);
            return View(await ninja.ToListAsync());
        }

        // GET: Ninjas/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ninja ninja = await db.Ninja.FindAsync(id);
            if (ninja == null)
            {
                return HttpNotFound();
            }
            return View(ninja);
        }

        // GET: Ninjas/Create
        public ActionResult Create()
        {
            ViewBag.ClanID = new SelectList(db.uspClanList(), "ClanID", "Name");
            return View();
        }

        // POST: Ninjas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "NinjaID,ClanID,Name,Age,Picture,CreatedOn,CreatedBy,IsExperienced,IsAlive,NinjaGUID")] Ninja ninja)
        {
            if (ModelState.IsValid)
            {
                db.Ninja.Add(ninja);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ClanID = new SelectList(db.Clan, "ClanID", "Name", ninja.ClanID);
            return View(ninja);
        }

        // GET: Ninjas/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ninja ninja = await db.Ninja.FindAsync(id);
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
        public async Task<ActionResult> Edit([Bind(Include = "NinjaID,ClanID,Name,Age,Picture,CreatedOn,CreatedBy,IsExperienced,IsAlive,NinjaGUID")] Ninja ninja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ninja).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ClanID = new SelectList(db.Clan, "ClanID", "Name", ninja.ClanID);
            return View(ninja);
        }

        // GET: Ninjas/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ninja ninja = await db.Ninja.FindAsync(id);
            if (ninja == null)
            {
                return HttpNotFound();
            }
            return View(ninja);
        }

        // POST: Ninjas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            Ninja ninja = await db.Ninja.FindAsync(id);
            db.Ninja.Remove(ninja);
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
    }
}
