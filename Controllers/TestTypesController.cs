using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppForTesting.Models;
using WebAppForTesting.Models.TestingModels;

namespace WebAppForTesting.Controllers
{
    public class TestTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TestTypes
        public async Task<ActionResult> Index()
        {
            ViewBag.Title = "Test List";
            return View(await db.TestTypes.ToListAsync());
        }

        // GET: TestTypes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestType testType = await db.TestTypes.FindAsync(id);
            if (testType == null)
            {
                return HttpNotFound();
            }
            return View(testType);
        }

        // GET: TestTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,TestName,Description,Level")] TestType testType)
        {
            if (ModelState.IsValid)
            {
                db.TestTypes.Add(testType);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(testType);
        }

        // GET: TestTypes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestType testType = await db.TestTypes.FindAsync(id);
            if (testType == null)
            {
                return HttpNotFound();
            }
            return View(testType);
        }

        // POST: TestTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,TestName,Description,Level")] TestType testType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testType).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(testType);
        }

        // GET: TestTypes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestType testType = await db.TestTypes.FindAsync(id);
            if (testType == null)
            {
                return HttpNotFound();
            }
            return View(testType);
        }

        // POST: TestTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TestType testType = await db.TestTypes.FindAsync(id);
            db.TestTypes.Remove(testType);
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
