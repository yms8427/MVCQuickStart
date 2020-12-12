using BilgeAdam.Contracts;
using BilgeAdam.Services;
using NUnit.Framework;
using System.Linq;

namespace BilgeAdam.Integration.Tests
{
    public class ProductTests
    {
        [Test]
        public void WhenProductsRequested_10ProductsReturn()
        {
            var svc = new ProductService();
            var products = svc.GetProducts();
            Assert.AreEqual(10, products.Count());
            Assert.AreEqual("Chai", products.ElementAt(0).Name);
            Assert.AreEqual("Ikura", products.ElementAt(9).Name);
        }

        [Test]
        public void WhenProductsRequestedById_ProductReturns()
        {
            var svc = new ProductService();
            var product = svc.GetProduct(1);
            Assert.IsNotNull(product);
            Assert.AreEqual("Chai", product.Name);
        }

        [Test]
        public void WhenProductWasAdded_ProductIsSaved()
        {
            var svc = new ProductService();
            var data = new ProductInputViewModel()
            {
                Name = "New Product",
                Price = 5,
                Stock = 120
            };
            var isSaved = svc.Save(data);
            Assert.IsTrue(isSaved);
        }
    }
}