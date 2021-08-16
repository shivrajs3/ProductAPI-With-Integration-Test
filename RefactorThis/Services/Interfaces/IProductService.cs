using refactor_this.Models;
using System;
using System.Collections.Generic;

namespace refactor_this.Services.Interfaces
{
    public interface IProductService
    {
        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns></returns>
        List<Product> GetAllProducts();


        /// <summary>
        /// get products by product name
        /// </summary>
        /// <param name="productName"></param>
        /// <returns></returns>
        List<Product> GetProductSearchByName(string productName);


        /// <summary>
        /// get prouct by id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Product GetProductById(Guid productId);


        /// <summary>
        /// Save the product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        Product SaveProduct(Product product);


        /// <summary>
        /// Update product
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="product"></param>
        Product UpdateProduct(Guid productId, UpdateProduct product);

        /// <summary>
        /// Delete product by id
        /// </summary>
        /// <param name="productId"></param>
        bool DeleteProductById(Guid productId);

    }
}
