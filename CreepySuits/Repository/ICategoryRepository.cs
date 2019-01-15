using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreepySuits.Models;

namespace CreepySuits.Repository
{
    public interface ICategoryRepository
    {
        List<Category> FindAll();
        Category Find(int? id);
        List<GenderAgeCategory> AFindAll();
        GenderAgeCategory AFind(int? id);
        List<Product> Search(string searchString);
        List<Product> Category(string category);
        List<Product> ACategory(string acategory);
        List<Product> PriceM(decimal priceMax);
        List<Product> PriceMi(decimal priceMin);
        List<Product> PriceExp(decimal priceExp);
        List<Product> Filter(decimal price, string agecategory);



    }
}
