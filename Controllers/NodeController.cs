using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.DAL;
using server.Models;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NodeController : ControllerBase
    {

        [HttpGet("{id}")]
        public IActionResult Get([FromServices] TreeDataContext treeDataContext, int id)
        {
            var node = treeDataContext.Nodes.Find(n => n.Id == id);
            if (node is not null)
                return new JsonResult(node);
            else
                return new NotFoundResult();

        }
    }
}
