using refactor_this.Context;
using refactor_this.Models;
using refactor_this.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace refactor_this.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductContext _dbContext;
        public ProductService(ProductContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns></returns>
        public List<Product> GetAllProducts()
        {
            var productResult = (from product in _dbContext.TblProducts
                                 select new Product()
                                 {
                                     Id = product.Id,
                                     Name = product.Name,
                                     Description = product.Description,
                                     Price = product.Price,
                                     DeliveryPrice = product.DeliveryPrice
                                 });

            return productResult.ToList();
        }

        /// <summary>
        /// Get products by product name
        /// </summary>
        /// <param name="productName"></param>
        /// <returns></returns>
        public List<Product> GetProductSearchByName(string productName)
        {
            var productResult = (from product in _dbContext.TblProducts
                                 where product.Name.Contains(productName)
                                 select new Product()
                                 {
                                     Id = product.Id,
                                     Name = product.Name,
                                     Description = product.Description,
                                     Price = product.Price,
                                     DeliveryPrice = product.DeliveryPrice
                                 });

            return productResult.ToList();
        }


        /// <summary>
        /// Get product by id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>

        public Product GetProductById(Guid productId)
        {
            var productResult = (from product in _dbContext.TblProducts
                                 where product.Id.Equals(productId)
                                 select new Product()
                                 {
                                     Id = product.Id,
                                     Name = product.Name,
                                     Description = product.Description,
                                     Price = product.Price,
                                     DeliveryPrice = product.DeliveryPrice
                                 }).SingleOrDefault();

            if (productResult == null)
                return null;

            return productResult;
        }

        /// <summary>
        /// Add new product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public Product SaveProduct(Product product)
        {
            TblProduct tblProduct = MapProductToTblProduct(product);
            _dbContext.TblProducts.Add(tblProduct);
            _dbContext.SaveChanges();
            return GetProductById(tblProduct.Id);
        }

        /// <summary>
        /// Update product
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        public Product UpdateProduct(Guid productId, UpdateProduct product)
        {
            var productResult = GetProductById(productId);

            if (productResult == null)
                return null;

            productResult.Name = product.Name;
            productResult.Description = product.Description;
            productResult.Price = product.Price;
            productResult.DeliveryPrice = product.DeliveryPrice;

            TblProduct tblProduct = MapProductToTblProduct(productResult);
            _dbContext.TblProducts.Attach(tblProduct);
            _dbContext.SaveChangesAsync();

            return productResult;
        }


        /// <summary>
        /// Delete product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public bool DeleteProductById(Guid productId)
        {
            var productResult = GetProductById(productId);

            if (productResult == null)
                return false;

            TblProduct tblProduct = MapProductToTblProduct(productResult);
            _dbContext.TblProducts.Attach(tblProduct);
            _dbContext.TblProducts.Remove(tblProduct);
            _dbContext.SaveChangesAsync();

            return true;
        }


        #region private method
        private TblProduct MapProductToTblProduct(Product product)
        {
            var tblProduct = new TblProduct
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                DeliveryPrice = product.DeliveryPrice

            };
            return tblProduct;
        } 
        #endregion
    }
}