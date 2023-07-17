using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductAPIEFCore.Model;

namespace ProductAPIEFCore.Repository
{
    public class ProdRepo : IProdRepo<Product>
    {
        private readonly BirlasoftdbContext db;
        public ProdRepo()
        {

        }

        public ProdRepo(BirlasoftdbContext _db)
        {
            db = _db;
        }

        public  void AddNewProduct(Product p)
        {
          db.Products.Add(p);
             db.SaveChanges();
        }

        public  Product DeleteProduct(int  id)
        {
           
               Product p = db.Products.Where(x=>x.Pid==id).SingleOrDefault();
            if (p != null)
            {
                db.Products.Remove(p);
                 db.SaveChanges();
            }
                return p;
            
           
        }

        public  List<Product> GetAllProducts()
        {
           
                return db.Products.ToList();
        }

        public async Task<Product> GetProductById(int id)
        {
            var p = db.Products.FindAsync(id);
            return await p;
        }

        public  async Task UpdateProduct(int id,Product p)
        {
            
            db.Products.Update(p);
            await db.SaveChangesAsync();
            
        }

        public bool check(int a)
        {
            if (a > 5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int add(int a, int b)
        {
            bool result=check(a);
            if (result == true)
            {
                return a + b;
            }
            return 0;
        }
    }
}
