using Bussiness.Service;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ClienteService _service;
        public ClientesController(ClienteService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var res = _service.GetAll();
            return Ok(res);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(Guid value)
        {
            var res = _service.GetCliente(value);
            return Ok(res);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ClientesModel value)
        {
            _service.AddCliente(value);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult Put([FromBody] ClientesModel value)
        {
            _service.EditCliente(value);
            return Ok(value);
        }


        [HttpDelete]
        public IActionResult Delete([FromBody] ClientesModel value)
        {
            _service.DeleteCliente(value);
            return Ok();
        }
    }
}
