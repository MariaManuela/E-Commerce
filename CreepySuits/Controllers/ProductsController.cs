using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CreepySuits.Models;
using CreepySuits.Repository;
//using System.Data.Entity.Infrastructure;

namespace CreepySuits.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ICategoryRepository iCategoryRepository = new CategoryRepository();
        // GET: Products
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        public ActionResult Category(int id)
        {
            var category = iCategoryRepository.Find(id);
            ViewBag.category = category;
            ViewBag.products = category.CategoryName.ToList();
            //List<Product> ProductList;
            //using (db)
            //{
            //    Category category = db.Categories.Where(x => x.CategoryName == name).FirstOrDefault();
            //    string catId = category.CategoryId;
            //    ProductList = db.Products.ToArray().Where(x => x.CategoryName == catId).Select(x => new Product()).ToList();
            //    var prodcat = db.Products.Where(x => x.CategoryName == catId).FirstOrDefault();
            //    ViewBag.CategoryName = prodcat.CategoryName;

            //}
            return View();

        }

        
        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            PopulateAgeCategoryDropDownList();
            PopulateCategoryDropDownList();
            return View();
        }



        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product, HttpPostedFileBase file)
        {

            //try
            //{
            if (ModelState.IsValid)
            {


                if (file != null && file.ContentLength > 0)
                {
                    //string filename = Path.GetFileName(file.FileName);
                    var filename = product.Name.Replace(" ", ".") + "_" + Path.GetFileName(file.FileName);
                    string filepath = Path.Combine(Server.MapPath("~/ProjectDocuments/Images"), filename);
                    file.SaveAs(filepath);
                    product.PicUrl = filename;
                }

                db.Products.Add(product);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        
            //catch (RetryLimitExceededException /* dex */)
            //{
            //    //Log the error (uncomment dex variable name and add a line here to write a log.)
            //    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            //}
            PopulateCategoryDropDownList(product.CategoryName);
           // PopulateAgeCategoryDropDownList(product.AgeCategoryId);
            //  ViewBag.GenderAgeCategoryList = new SelectList(db.GenderAgeCategories, "GenderAgeCategoryId", "GenderAgeCategoryName", product.AgeCategory);
            return View(product);
        }




        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,Name,Description,Specification,Price,Stock,Provider,DeliveryType,Category,AgeCategory")] Product product, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {

                if (file != null && file.ContentLength > 0)
                {

                    
                    //string filename = Path.GetFileName(file.FileName);
                    var filename = product.Name.Replace(" ", ".") + "_" + Path.GetFileName(file.FileName);
                    string filepath = Path.Combine(Server.MapPath("~/ProjectDocuments/Images"), filename);
                    file.SaveAs(filepath);
                    product.PicUrl = filename;
                }
                
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        private void PopulateCategoryDropDownList(object selectedCategory = null)
        {
          
            var categoriesQuery = from d in db.Categories
                                   orderby d.CategoryName
                                   select d;
            ViewBag.CategoryName = new SelectList(categoriesQuery, "CategoryName", "CategoryName", selectedCategory);
            
        }

        private void PopulateAgeCategoryDropDownList(object selectedAgeCategory = null)
        {
            var agecategQuery = from d in db.GenderAgeCategories
                                   orderby d.GenderAgeCategoryName
                                   select d;
            ViewBag.AgeCategoryName = new SelectList(agecategQuery, "GenderAgeCategoryName", "GenderAgeCategoryName", selectedAgeCategory );
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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

        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/Images"), pic);
                file.SaveAs(path);

                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }


            }
            return RedirectToAction("Create", "Products");
        }


    }
}
