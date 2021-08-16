using System;
using System.Net;
using System.Web.Http;
using refactor_this.Models;
using Swashbuckle.Swagger.Annotations;
using refactor_this.Services.Interfaces;

namespace refactor_this.Controllers
{
    [RoutePrefix("products")]
    public class ProductsController : ApiController
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productSerice)
        {
            _productService = productSerice;
        }

        [HttpGet]
        [Route]
        [SwaggerOperation(OperationId = "GetAllProducts")]
        public IHttpActionResult GetAllProducts()
        {
            var result = _productService.GetAllProducts();
            return Ok(result);
        }


        [HttpGet]
        [SwaggerOperation(OperationId = "GetProductsByName")]
        public IHttpActionResult GetProductSearchByName(string productName)
        {
            var result = _productService.GetProductSearchByName(productName);
            if (result == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Ok(result);
        }


        [HttpGet]
        [Route("{productId}")]
        [SwaggerOperation(OperationId = "GetProductsById")]
        public IHttpActionResult GetProductById(Guid productId)
        {
            var result = _productService.GetProductById(productId);
            if (result == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(result);
        }


        [HttpPost]
        [SwaggerOperation(OperationId = "SaveProduct")]
        public IHttpActionResult SaveNewProduct([FromBody] Product product)
        {
            var result = _productService.SaveProduct(product);
            return Ok(result);
        }

        [HttpPost]
        [Route("{productId}")]
        [SwaggerOperation(OperationId = "SaveProduct")]
        public IHttpActionResult UpdateProduct(Guid productId, [FromBody] UpdateProduct product)
        {
            var result = _productService.UpdateProduct(productId, product);
            if (result == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            return Ok(result);
        }

        [Route("{productId}")]
        [HttpDelete]
        public IHttpActionResult DeleteProductById(Guid productId)
        {
            var result = _productService.DeleteProductById(productId);
            if (result == false)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(result);
        }


        //We can perform same operation for below endpoints


        //[Route("{productId}/options")]
        //[HttpGet]
        //public ProductOptions GetOptions(Guid productId)
        //{
        //    return new ProductOptions(productId);
        //}

        //[Route("{productId}/options/{id}")]
        //[HttpGet]
        //public ProductOption GetOption(Guid productId, Guid id)
        //{
        //    var option = new ProductOption(id);
        //    if (option.IsNew)
        //        throw new HttpResponseException(HttpStatusCode.NotFound);

        //    return option;
        //}

        //[Route("{productId}/options")]
        //[HttpPost]
        //public void CreateOption(Guid productId, ProductOption option)
        //{
        //    option.ProductId = productId;
        //    option.Save();
        //}

        //[Route("{productId}/options/{id}")]
        //[HttpPut]
        //public void UpdateOption(Guid id, ProductOption option)
        //{
        //    var orig = new ProductOption(id)
        //    {
        //        Name = option.Name,
        //        Description = option.Description
        //    };

        //    if (!orig.IsNew)
        //        orig.Save();
        //}

        //[Route("{productId}/options/{id}")]
        //[HttpDelete]
        //public void DeleteOption(Guid id)
        //{
        //    var opt = new ProductOption(id);
        //    opt.Delete();
        //}
    }
}
