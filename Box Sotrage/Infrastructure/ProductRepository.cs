using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ProductRepository
    {
        private ProductDbContext _db;

        public ProductRepository(ProductDbContext db)
        {
            _db = db;
        }

        public List<Product> GetAllProducts()
        {
            return _db.ProductTable.ToList();
        }

        public Product InsertProduct(Product product)
        {
            _db.ProductTable.Add(product);
            _db.SaveChanges();
            return product;
        }

        public Product DeleteProduct(Product product)
        {
            _db.ProductTable.Remove(product);
            _db.SaveChanges();
            return product;
        }

        public Product EditProduct (Product product)
        {
            _db.ProductTable.Update(product);
            _db.SaveChanges();
            return product;
        }

        public void CreateDB()
        {
            _db.Database.EnsureDeleted();
            _db.Database.EnsureCreated();
        }

    }
}
