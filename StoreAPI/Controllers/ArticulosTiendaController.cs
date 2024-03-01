using Bussiness.Service;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosTiendaController : ControllerBase
    {
        private readonly ArticuloTiendaService _service;
        public ArticulosTiendaController(ArticuloTiendaService service)
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
            var res = _service.GetById(value);
            return Ok(res);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ArticuloTiendaModel value)
        {
            _service.Add(value);
            return Ok(value);
        }


        [HttpDelete]
        public IActionResult Delete([FromBody] ArticuloTiendaModel value)
        {
            _service.Delete(value);
            return Ok();
        }
    }
}
