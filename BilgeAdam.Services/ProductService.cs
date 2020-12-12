using BilgeAdam.Contracts;
using BilgeAdam.Data;
using BilgeAdam.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BilgeAdam.Services
{
    public class ProductService
    {
        public ProductViewModel GetProduct(int productId)
        {
            using (var context = new NorthwindDbContextFactory().GetContext())
            {
                var product = context.Products.Where(f => f.ProductID == productId)
                                              .Include(i => i.Category)
                                              .Include(i => i.Supplier)
                                              .Select(p => new ProductViewModel
                                              {
                                                  Id = p.ProductID,
                                                  Name = p.ProductName,
                                                  Price = p.UnitPrice,
                                                  Stock = p.UnitsInStock,
                                                  Category = p.Category.CategoryName,
                                                  Company = p.Supplier.CompanyName
                                              })
                                              .FirstOrDefault();
                return product;
            }
        }

        public IEnumerable<ProductViewModel> GetProducts()
        {
            using (var context = new NorthwindDbContextFactory().GetContext())
            {
                var products = context.Products.Include(i => i.Category)
                                               .Include(i => i.Supplier)
                                               .Select(p => new ProductViewModel
                                               {
                                                   Id = p.ProductID,
                                                   Name = p.ProductName,
                                                   Price = p.UnitPrice,
                                                   Stock = p.UnitsInStock,
                                                   Category = p.Category.CategoryName,
                                                   Company = p.Supplier.CompanyName
                                               })
                                               .Take(10)
                                               .ToList();
                return products;
            }
        }

        public bool Save(ProductInputViewModel data)
        {
            using (var context = new NorthwindDbContextFactory().GetContext())
            {
                var @new = new Product
                {
                    ProductName = data.Name,
                    UnitPrice = data.Price,
                    UnitsInStock = data.Stock
                };

                context.Products.Add(@new);
                return context.SaveChanges() > 0;
            }
        }
    }
}