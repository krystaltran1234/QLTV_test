using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLTV_test.Models;

namespace QLTV_test.Controllers
{
    public class LoaiNguoiDungsController : Controller
    {
        private QLTVModel db = new QLTVModel();

        // GET: LoaiNguoiDungs
        public async Task<ActionResult> Index()
        {
            return View(await db.LoaiNguoiDungs.ToListAsync());
        }

        // GET: LoaiNguoiDungs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiNguoiDung loaiNguoiDung = await db.LoaiNguoiDungs.FindAsync(id);
            if (loaiNguoiDung == null)
            {
                return HttpNotFound();
            }
            return View(loaiNguoiDung);
        }

        // GET: LoaiNguoiDungs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoaiNguoiDungs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MaLoaiND,TenLoaiND")] LoaiNguoiDung loaiNguoiDung)
        {
            if (ModelState.IsValid)
            {
                db.LoaiNguoiDungs.Add(loaiNguoiDung);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(loaiNguoiDung);
        }

        // GET: LoaiNguoiDungs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiNguoiDung loaiNguoiDung = await db.LoaiNguoiDungs.FindAsync(id);
            if (loaiNguoiDung == null)
            {
                return HttpNotFound();
            }
            return View(loaiNguoiDung);
        }

        // POST: LoaiNguoiDungs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MaLoaiND,TenLoaiND")] LoaiNguoiDung loaiNguoiDung)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiNguoiDung).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(loaiNguoiDung);
        }

        // GET: LoaiNguoiDungs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiNguoiDung loaiNguoiDung = await db.LoaiNguoiDungs.FindAsync(id);
            if (loaiNguoiDung == null)
            {
                return HttpNotFound();
            }
            return View(loaiNguoiDung);
        }

        // POST: LoaiNguoiDungs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            LoaiNguoiDung loaiNguoiDung = await db.LoaiNguoiDungs.FindAsync(id);
            db.LoaiNguoiDungs.Remove(loaiNguoiDung);
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
