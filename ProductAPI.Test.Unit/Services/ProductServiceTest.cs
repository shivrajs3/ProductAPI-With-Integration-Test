using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using refactor_me.ConfigurationProvider;
using refactor_this.Context;
using refactor_this.Models;
using refactor_this.Services;
using System;
using Assert = NUnit.Framework.Assert;

namespace ProductAPI.Test.Unit.Services
{
    [TestClass]
    public class ProductServiceTest
    {
        private ProductService _productService;
        private ProductContext _dbContext;
        private readonly Mock<IAppConfigProvider> _appConfig = new Mock<IAppConfigProvider>();

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            //mock connection string
            _appConfig.Setup(x => x.GetConnectionString())
                   .Returns("ProductContext");
            _dbContext = new ProductContext(_appConfig.Object);

            //add data in dbcontext
            SetUpDbcontext();

            _productService = new ProductService(_dbContext);
        }

        [Test]
        public void GetAllProduct_ShouldReturnAllProducts()
        {
            var productResult = _productService.GetAllProducts();
            Assert.IsTrue(productResult.Count > 0);
            Assert.IsNotNull(productResult);
        }


        [TestCase("Samsung Tv")]
        public void GetProductByName_ShouldReturnProduct(string productName)
        {
            var productResult = _productService.GetProductSearchByName(productName);

            Assert.IsNotNull(productResult);
            Assert.IsTrue(productResult.Count == 1);
        }


        [Test]
        public void GetProductById_ShouldReturnProduct()
        {
            Guid productId = new Guid("de1286c0-4b15-4a7b-9d8a-dd21b3cafec3");
            var productResult = _productService.GetProductById(productId);

            Assert.IsNotNull(productResult);
            Assert.AreEqual(productId, productResult.Id);
            Assert.AreEqual("Apple iPhone 11", productResult.Name);
        }


        [Test]
        public void SaveProduct_ShouldReturnProduct()
        {
            Product newProduct = new Product { Id = Guid.NewGuid(), Name = "Apple iPhone 12", Description = "Newest mobile product from Apple.", Price = 2400, DeliveryPrice = 13 };
            var productResult = _productService.SaveProduct(newProduct);

            Assert.IsNotNull(productResult);
            Assert.AreEqual(newProduct.Name, productResult.Name);
            Assert.AreEqual(newProduct.Description, productResult.Description);
            Assert.AreEqual(newProduct.Price, productResult.Price);
            Assert.AreEqual(newProduct.DeliveryPrice, productResult.DeliveryPrice);
        }


        //We can add more test TDD scenarios for all services 

        [OneTimeTearDown]
        public void CleanUp()
        {
            _dbContext.Database.Delete();
            _dbContext.Dispose();
        }


        #region private

        private void SetUpDbcontext()
        {

            _dbContext.TblProducts.Add(new TblProduct()
            {
                Id = new Guid("daf4294b-acb5-4248-8c93-6564188cf36c"),
                Name = "Samsung Tv",
                Description = "Newest tv product from Samsung.",
                Price = 2100,
                DeliveryPrice = 12
            });

            _dbContext.TblProducts.Add(new TblProduct()
            {
                Id = new Guid("de1286c0-4b15-4a7b-9d8a-dd21b3cafec3"),
                Name = "Apple iPhone 11",
                Description = "Newest mobile product from Apple.",
                Price = 3000,
                DeliveryPrice = 23
            });

            _dbContext.SaveChanges();
        } 
        #endregion
    }
}
