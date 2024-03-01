using Bussiness.Service;
using Entity.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        private readonly ArticuloService _service;
        public ArticulosController(ArticuloService service)
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
        public IActionResult Post([FromBody] ArticuloModel value)
        {
            _service.Add(value);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult Put([FromBody] ArticuloModel value)
        {
            _service.Edit(value);
            return Ok(value);
        }


        [HttpDelete]
        public IActionResult Delete([FromBody] ArticuloModel value)
        {
            _service.Delete(value);
            return Ok();
        }
    }
}
