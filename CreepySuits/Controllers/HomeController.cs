using CreepySuits.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CreepySuits.Repository;

namespace CreepySuits.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ICategoryRepository iCategoryRepository = new CategoryRepository();
        
        public ActionResult Index()
        {
       

            
           
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";



            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        //public ActionResult Details(int? id)
        //{
        //    var product = new Product { Name = "Product " + id };
        //    return View(product);
        //}

        //public ActionResult Browse(string categ)
        //{
        //    var catModel = new Product { Category = categ };
        //    return View(catModel);
        //}

       

    }
}