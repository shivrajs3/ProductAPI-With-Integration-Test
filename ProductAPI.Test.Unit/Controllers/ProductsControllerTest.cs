using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using refactor_this.Controllers;
using refactor_this.Models;
using refactor_this.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Web.Http.Results;
using Assert = NUnit.Framework.Assert;

namespace ProductAPI.Test.Unit.Controllers
{
    [TestClass]
    public class ProductsControllerTest
    {
        private readonly Mock<IProductService> _mockProductService = new Mock<IProductService>();
        private List<Product> _expectedProductResponse;

        [SetUp]
        public void Setup()
        {
            _expectedProductResponse = new List<Product>
            {
                new Product{Id= Guid.NewGuid(),Name="Apple iPhone 12",Description="Newest mobile product from Apple.",Price=2400,DeliveryPrice=13 },
                new Product{Id= Guid.NewGuid(),Name="Sony Phone",Description="Newest mobile product from Sony.",Price=1500,DeliveryPrice=11 },
                new Product{Id= Guid.NewGuid(),Name="Apple iPhone 11",Description="Newest mobile product from Apple.",Price=4000,DeliveryPrice=13 },
                new Product{Id= Guid.NewGuid(),Name="Samsung",Description="Newest mobile product from samsung.",Price=1500,DeliveryPrice=11 }
            };
        }


        [Test]
        public void GetAllProducts_ShouldReturnAllProducts()
        {
            _mockProductService.Setup(x => x.GetAllProducts())
                .Returns(_expectedProductResponse);

            var controller = new ProductsController(_mockProductService.Object);
            var result = controller.GetAllProducts();

            var actualResult = ((OkNegotiatedContentResult<List<Product>>)result).Content;
            Assert.IsNotNull(actualResult);
            Assert.IsTrue(actualResult.Count == 4);
            Assert.AreEqual(_expectedProductResponse, actualResult);
        }


        [TestCase("Apple iPhone 12")]
        public void GetProductByName_ShouldReturnProduct(string productName)
        {

            _expectedProductResponse = new List<Product>
            {
                new Product{Id= Guid.NewGuid(),Name="Apple iPhone 12",Description="Newest mobile product from Apple.",Price=2400,DeliveryPrice=13 },
            };
            _mockProductService.Setup(x => x.GetProductSearchByName(productName))
                .Returns(_expectedProductResponse);

            var controller = new ProductsController(_mockProductService.Object);
            var result = controller.GetProductSearchByName(productName);

            var actualResult = ((OkNegotiatedContentResult<List<Product>>)result).Content;
            Assert.IsNotNull(actualResult);
            Assert.IsTrue(actualResult.Count == 1);
            Assert.AreEqual(_expectedProductResponse, actualResult);
        }

        [Test]
        public void SaveNewProduct_ShouldReturnOkResponse()
        {
            Product newProduct = new Product { Id = Guid.NewGuid(), Name = "Apple iPhone 12", Description = "Newest mobile product from Apple.", Price = 2400, DeliveryPrice = 13 };

            _mockProductService.Setup(x => x.SaveProduct(newProduct))
                .Returns(newProduct);

            var controller = new ProductsController(_mockProductService.Object);
            var result = controller.SaveNewProduct(newProduct);

            var actualResult = ((OkNegotiatedContentResult<Product>)result).Content;
            Assert.IsNotNull(actualResult);
            Assert.AreEqual(newProduct, actualResult);
        }


        //We can add more test TDD scenarios based on controller end points
    }
}

