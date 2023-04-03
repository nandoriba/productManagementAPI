using Microsoft.AspNetCore.Mvc;
using ProductManagement.Domain.Commands;
using ProductManagement.Domain.Commands.Products;
using ProductManagement.Domain.Entites;
using ProductManagement.Domain.Handlers;
using ProductManagement.Domain.Queries;
using ProductManagement.Domain.Repositories;
using ProductManagement.Domain.ValueObjects;

namespace ProductManagement.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductQueries _productQueries;
        private readonly IAssociateProductWithCategoryQueries _associateProductWithCategoryQueries;

        public ProductController(IProductQueries productQueries,
             IAssociateProductWithCategoryQueries associateProductWithCategoryQueries)
        {
            _productQueries = productQueries;
            _associateProductWithCategoryQueries = associateProductWithCategoryQueries;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetAll(
            [FromServices] IProductRepository repository)
        {
            return await repository.GetAll();
        }

        [Route("productById")]
        [HttpGet]
        public async Task<Product> GetProductId(
            [FromServices] IProductRepository repository, Guid id)
        {
            return await repository.GetById(id);
        }

        [Route("productByStatus")]
        [HttpGet]
        public async Task<JsonResult> GetProductByStatus(bool status)
        {        

            var result = await _productQueries.GetAllStatus(
                                status ? State.Active : State.Inactive);

            return new JsonResult(result);
        }

        [Route("productsByDescription")]
        [HttpGet]
        public async Task<JsonResult> GetProductsByDesctiption(string description)
        {
            var result = await _productQueries.GetAllByDescription(description);
            return new JsonResult(result);
        }


        [Route("productsByCategory")]
        [HttpGet]
        public async Task<JsonResult> GetProductsByCategory(Guid categoryId)
        {
            var result = await _associateProductWithCategoryQueries.GetProductIdByCategoryId(categoryId);
            return new JsonResult(result);
        }

        [HttpPost]
        public GenericCommandsResult Create(
            [FromBody] CreateProductCommand command,
            [FromServices] ProductHandler handler)
        {
            return (GenericCommandsResult)handler.Handler(command);
        }
        
        [HttpPut]
        public GenericCommandsResult Update(
            [FromBody] UpdateProductCommand command,
            [FromServices] ProductHandler handler)
        {
            return (GenericCommandsResult)handler.Handler(command);
        }

        [HttpDelete]
        public GenericCommandsResult Delete(
            [FromBody] RemoveProductCommand command,
            [FromServices] ProductHandler handler)
        {
            return (GenericCommandsResult)handler.Handler(command);
        }
    }
}
