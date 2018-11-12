//using CreepySuits.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Threading.Tasks;
//using System.Web;
//using System.Web.Mvc;


//namespace CreepySuits.Controllers
//{
//    public class ListController : Controller
//    {
//        private ApplicationDbContext db = new ApplicationDbContext();
//        // GET: FrontList
//        public ActionResult Index(int? id)
//        {

//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }

//            var currentProdId = id;
//            var categId = db.Categories
//                  .Where(x => x.CategoryId == currentProdId)
//                  .Select(x => x.CategoryId)
//                  .Single();

//            Category category = db.Categories.Find(id);
//            // string query = @"SELECT * FROM Product WHERE Category = (SELECT CategoryId FROM Categories WHERE CategoryId=@id)";
//            // category = await db.Categories.SqlQuery(query, id).SingleOrDefaultAsync();
//            if (category == null)
//            {
//                return HttpNotFound();
//            }



//            return View(category);


//        }
//    }
//}
