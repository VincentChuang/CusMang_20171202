using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CusMang.Models;

namespace CusMang.Controllers
{
    public class CustomerController : Controller
    {
        private CusDBEntities db = new CusDBEntities();

        public ActionResult Index() {
            List<客戶資料> list = db.客戶資料.Where(x => x.是否已刪除 == false).ToList();
            return View(list);
        }
        [HttpPost]
        public ActionResult Index(string CusName) {
            List<客戶資料> list = db.客戶資料
                .Where(x => x.客戶名稱.Contains(CusName))
                .Where(x => x.是否已刪除 == false).ToList();
            //寫入 ViewBag 資料
            ViewBag.CusName = CusName;
            return View(list);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = db.客戶資料.Find(id);
            if (客戶資料 == null) {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶名稱,統一編號,電話,傳真,地址,Email,客戶分類,是否已刪除")] 客戶資料 客戶資料)
        {
            if (ModelState.IsValid) {
                db.客戶資料.Add(客戶資料);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(客戶資料);
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = db.客戶資料.Find(id);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // POST: Customer/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,客戶名稱,統一編號,電話,傳真,地址,Email,客戶分類,是否已刪除")] 客戶資料 客戶資料)
        {
            if (ModelState.IsValid)
            {
                db.Entry(客戶資料).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(客戶資料);
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = db.客戶資料.Find(id);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            客戶資料 客戶資料 = db.客戶資料.Find(id);
            客戶資料.是否已刪除 = true;
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


        #region 遠端Email驗證-RemoteEmailCheck
        //public JsonResult CheckUserName(string userName) {
        //    bool isValidate = false;
        //    if (Url.IsLocalUrl(Request.Url.AbsoluteUri)) {
        //        //利用 IsLocalUrl檢查是否為網站呼叫的
        //        //借此忽略一些不必要的流量
        //        if (userName != "demoshop") {
        //            //因連資料庫麻煩
        //            //所以假裝示範不可以註冊某一名字
        //            isValidate = true;
        //        }
        //    }
        //    // Remote 驗證是使用 Get 因此要開放
        //    return Json(isValidate, JsonRequestBehavior.AllowGet);
        //}
        public JsonResult RemoteEmailCheck(string email) {
            bool isValidate = false;
            isValidate = db.客戶資料.Where(x => x.Email == email).Any();
            isValidate = !isValidate;
            // Remote 驗證是使用 Get 因此要開放
            return Json(isValidate, JsonRequestBehavior.AllowGet);
        }
        #endregion


    }
}
