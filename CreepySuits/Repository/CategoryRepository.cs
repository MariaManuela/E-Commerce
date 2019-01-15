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

        public List<GenderAgeCategory> AFindAll()
        {
            return db.GenderAgeCategories.ToList();
        }


        public GenderAgeCategory AFind(int? id)
        {

            return db.GenderAgeCategories.Find(id);

        }

        public List<Product> PriceM(decimal priceMax)
        {
            var priceFilterMax = db.Products.Where(x => x.Price < priceMax);
            

            return priceFilterMax.ToList();
        }

        public List<Product> PriceMi(decimal priceMin)
        {
            var priceFilterMin = db.Products.Where(x => x.Price < priceMin);
            return priceFilterMin.ToList();
        }

        public List<Product> PriceExp(decimal priceExp)
        {
            var priceFilterExp = db.Products.Where(x => x.Price > priceExp);
            return priceFilterExp.ToList();
        }

        public List<Product> ACategory(string acategory)
        {

            var aquery = db.Products.Where(x => x.AgeCategoryName.Equals(acategory));




            return aquery.ToList();
        }

        public List<Product> Category(string category)
        {
            
            var query = db.Products.Where(x => x.CategoryName.Equals(category));
   


            
            return query.ToList();
        }

        public List<Product> Filter(decimal price, string agecategory)
        {
            var query = db.Products.Where(x => x.AgeCategoryName.Equals(agecategory) && x.Price == price);

            return query.ToList();
        }

        public List<Product> Search(string searchString)
        {
            var query = db.Products.Where(x => x.Name.Contains(searchString));
            return query.ToList();
        }

       
    }
}