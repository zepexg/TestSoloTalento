using Bussiness.Service;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private readonly VentaService _service;
        public VentasController(VentaService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Post([FromBody] VentaModel value)
        {
            var res = _service.Add(value);
            return Ok(res);
        }

        [HttpGet("GetByClienteId")]
        public IActionResult GetById(Guid value)
        {
            var res = _service.GetById(value);
            return Ok(res);
        }
    }
}
