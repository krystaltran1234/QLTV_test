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
    public class NguoiDungsController : Controller
    {
        private QLTVModel db = new QLTVModel();

        // GET: NguoiDungs
        public async Task<ActionResult> Index()
        {
            var nguoiDungs = db.NguoiDungs.Include(n => n.LoaiNguoiDung1);
            return View(await nguoiDungs.ToListAsync());
        }

        // GET: NguoiDungs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguoiDung nguoiDung = await db.NguoiDungs.FindAsync(id);
            if (nguoiDung == null)
            {
                return HttpNotFound();
            }
            ViewBag.LoaiNguoiDung = db.LoaiNguoiDungs.Single(n => n.MaLoaiND == nguoiDung.LoaiNguoiDung).TenLoaiND;
            return View(nguoiDung);
        }

        // GET: NguoiDungs/Create
        public ActionResult Create()
        {
            ViewBag.LoaiNguoiDung = new SelectList(db.LoaiNguoiDungs, "MaLoaiND", "TenLoaiND");
            return View();
        }

        // POST: NguoiDungs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MaNguoiDung,TenNguoiDung,LoaiNguoiDung,TenDangNhap,MatKhau,DaXoa")] NguoiDung nguoiDung)
        {
            if (ModelState.IsValid)
            {
                db.NguoiDungs.Add(nguoiDung);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.LoaiNguoiDung = new SelectList(db.LoaiNguoiDungs, "MaLoaiND", "TenLoaiND", nguoiDung.LoaiNguoiDung);
            return View(nguoiDung);
        }

        // GET: NguoiDungs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguoiDung nguoiDung = await db.NguoiDungs.FindAsync(id);
            if (nguoiDung == null)
            {
                return HttpNotFound();
            }
            ViewBag.LoaiNguoiDung = new SelectList(db.LoaiNguoiDungs, "MaLoaiND", "TenLoaiND", nguoiDung.LoaiNguoiDung);
            return View(nguoiDung);
        }

        // POST: NguoiDungs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MaNguoiDung,TenNguoiDung,LoaiNguoiDung,TenDangNhap,MatKhau,DaXoa")] NguoiDung nguoiDung)
        {

            if (ModelState.IsValid)
            {
                db.Entry(nguoiDung).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.LoaiNguoiDung = new SelectList(db.LoaiNguoiDungs, "MaLoaiND", "TenLoaiND", nguoiDung.LoaiNguoiDung);
            return View(nguoiDung);
        }

        // GET: NguoiDungs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguoiDung nguoiDung = await db.NguoiDungs.FindAsync(id);
            if (nguoiDung == null)
            {
                return HttpNotFound();
            }
            return View(nguoiDung);
        }

        // POST: NguoiDungs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            NguoiDung nguoiDung = await db.NguoiDungs.FindAsync(id);
            db.NguoiDungs.Remove(nguoiDung);
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

        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap (FormCollection f)
        {
            string textTenDangNhap = f["txtTenDangNhap"].ToString();
            string textMatKhau = f["txtMatKhau"].ToString();
            NguoiDung nguoiDung = db.NguoiDungs.SingleOrDefault(n => n.TenDangNhap == textTenDangNhap && n.MatKhau == textMatKhau);
            if (nguoiDung != null)
            {
                ViewBag.ThongBao = "Đăng nhập thành công";
                Session["TenDangNhap"] = nguoiDung;
                return View();
            }
            ViewBag.ThongBao = "Sai Tên đăng nhập hoặc Mật khẩu";
            return View();
        }
    }
}
