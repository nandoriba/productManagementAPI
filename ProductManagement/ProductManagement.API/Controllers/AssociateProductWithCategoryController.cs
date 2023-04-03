using Microsoft.AspNetCore.Mvc;
using ProductManagement.Domain.Commands;
using ProductManagement.Domain.Commands.AssociateProductsWithCategories;
using ProductManagement.Domain.Handlers;

namespace ProductManagement.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AssociateProductWithCategoryController : Controller
    {
        [Route("")]
        [HttpPost]
        public GenericCommandsResult Create(
            [FromBody] CreateAssociateProductWithCategoryCommand command,
            [FromServices] AssociateProductWithCategoryHandler handler)
        {
            return (GenericCommandsResult)handler.Handler(command);
        }

        [Route("")]
        [HttpDelete]
        public GenericCommandsResult Delete(
            [FromBody] RemoveAssociateProductWithCategoryCommand command,
            [FromServices] AssociateProductWithCategoryHandler handler)
        {
            return (GenericCommandsResult)handler.Handler(command);
        }
    }
}
