using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CreepySuits.Models;

namespace CreepySuits.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public ApplicationDbContext db = new ApplicationDbContext();

        public List<Category> FindAll()
        {
            return db.Categories.ToList();
        }


        public Category Find(int? id)
        {
            
            return db.Categories.Find(id);
           
        }

        public List<Product> ProductByCategory(int? id)
        {
            var query = db.Products.Where(x => x.CategoryId.Equals(id));
            return query.ToList();
        }

        public List<Product> Search(string searchString)
        {
            var query = db.Products.Where(x => x.Name.Contains(searchString));
            return query.ToList();
        }

       
    }
}