using Bussiness.Service;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiendasController : ControllerBase
    {
        private readonly TiendaService _service;
        public TiendasController(TiendaService service)
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
        public IActionResult Post([FromBody] TiendaModel value)
        {
            _service.Add(value);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult Put([FromBody] TiendaModel value)
        {
            _service.Edit(value);
            return Ok(value);
        }


        [HttpDelete]
        public IActionResult Delete([FromBody] TiendaModel value)
        {
            _service.Delete(value);
            return Ok();
        }
    }
}
