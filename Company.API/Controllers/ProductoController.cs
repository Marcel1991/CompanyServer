using Company.BL.Repositories;
using Company.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Company.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {


        private readonly IProductoRepository _productoService;

        public ProductoController(IProductoRepository productoService)
        {
            _productoService = productoService;
        }

        // GET: api/<ProductosController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _productoService.GetProductos();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ProductosController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var productoFound = await _productoService.GetProductoById(id);
                if (productoFound == null) return NotFound();

                return Ok(productoFound);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ProductosController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Producto dataProducto)
        {
            try
            {
                var resultProducto = await _productoService.PostProducto(dataProducto);
                return Ok(resultProducto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProductosController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Producto dataProducto)
        {
            try
            {
                if (id != dataProducto.Id) return NotFound();
                await _productoService.UpdateProducto(id, dataProducto);
                return Ok(new { message = "Data updated successfuly." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // DELETE api/<ProductosController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _productoService.DeleteProductoById(id);
                if (result == "NOT_FOUND") return NotFound();
                return Ok(new { message = "Data deleted successfuly." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
