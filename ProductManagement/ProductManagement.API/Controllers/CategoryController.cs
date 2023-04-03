using Microsoft.AspNetCore.Mvc;
using ProductManagement.Domain.Commands;
using ProductManagement.Domain.Commands.Categories;
using ProductManagement.Domain.Entites;
using ProductManagement.Domain.Handlers;
using ProductManagement.Domain.Queries;
using ProductManagement.Domain.Repositories;
using ProductManagement.Domain.ValueObjects;

namespace CategoryManagement.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryQueries _CategoryQueries;       

        public CategoryController(ICategoryQueries CategoryQueries)
        {
            _CategoryQueries = CategoryQueries;            
        }

        [HttpGet]
        public async Task<IEnumerable<Category>> GetAll(
            [FromServices] ICategoryRepository repository)
        {
            return await repository.GetAll();
        }

        [Route("CategoryById")]
        [HttpGet]
        public async Task<Category> GetCategoryId(
            [FromServices] ICategoryRepository repository, Guid id)
        {
            return await repository.GetById(id);
        }

        [Route("CategoryByStatus")]
        [HttpGet]
        public async Task<JsonResult> GetCategoryByStatus(bool status)
        {

            var result = await _CategoryQueries.GetAllStatus(
                                status ? State.Active : State.Inactive);

            return new JsonResult(result);
        }

        [Route("CategorysByName")]
        [HttpGet]
        public async Task<JsonResult> GetCategorysByDesctiption(string name)
        {
            var result = await _CategoryQueries.GetAllByName(name);
            return new JsonResult(result);
        }

        [HttpPost]
        public GenericCommandsResult Create(
            [FromBody] CreateCategoryCommand command,
            [FromServices] CategoryHandler handler)
        {
            return (GenericCommandsResult)handler.Handler(command);
        }

        [HttpPut]
        public GenericCommandsResult Update(
            [FromBody] UpdateCategoryCommand command,
            [FromServices] CategoryHandler handler)
        {
            return (GenericCommandsResult)handler.Handler(command);
        }

        [HttpDelete]
        public GenericCommandsResult Delete(
            [FromBody] RemoveCategoryCommand command,
            [FromServices] CategoryHandler handler)
        {
            return (GenericCommandsResult)handler.Handler(command);
        }
    }
}

