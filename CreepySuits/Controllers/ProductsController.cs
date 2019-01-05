using System;
using System.Collections.Generic;
using System.Collections;
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
using CreepySuits.ViewModels;
//using System.Data.Entity.Infrastructure;

namespace CreepySuits.Controllers
{
    public class ProductsController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        private ICategoryRepository iCategoryRepository = new CategoryRepository();
        private const int PageSize = 6;
        // GET: Products

        public ActionResult Index()
        {

            return View(db.Products.ToList());
        }

        public ActionResult UserIndex(string category, int? id, int page = 1)
        {

            List<Product> ProductList = db.Products.ToList();

            var nrObj = ProductList.Skip((page - 1) * PageSize).Take(PageSize).ToList();
            ViewBag.totalPages = Math.Ceiling((double)ProductList.Count() / PageSize);
            for (int i = 1; i < ViewBag.totalPages; i++)
            {
                ViewBag.product = nrObj;
            }

            //List<Category> CategoryList = db.Categories.ToList();
            //ViewBag.ctg = CategoryList;
              var ctgList = iCategoryRepository.FindAll();

                var model = new CategoryViewModel()
                {
                    Categories = new List<Category>()
                };

                ViewBag.ctg = ctgList;





            return View();
        }

        [ChildActionOnly]
        public ActionResult CategoryMenu()
        {
            var categories = db.Categories.ToList();
            return PartialView(categories);
        }

        public ActionResult Browse(string category)
        {
         
            //var categoryModel = new Category { CategoryName = category};
            var categoryModel = db.Categories.Include(s=>s.Products).SingleOrDefault(c => c.CategoryName == category);

            var prodList = iCategoryRepository.Category(category);
            ViewBag.f = prodList;
            return View(categoryModel);
        }


        public ActionResult Search()
        {
            return PartialView("SearchForm");
        }

        [HttpPost]
        public ActionResult SearchResult(string searchString)
        {
            if(searchString != null)
            {
                try
                {
                    var searchList = iCategoryRepository.Search(searchString);

                    var model = new ProductViewModel()
                    {
                        Products = new List<Product>()
                    };

                    ViewBag.products = searchList;

                    return PartialView(model);
                }
                catch(Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                }
            }


            return PartialView("Error");
        }

        [HttpPost]
        public ActionResult Pagination(int page = 1)
        {


            


            return View();
        }

        public ActionResult ProductDetails(int? id)
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
