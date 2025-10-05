using BeuniAPI.Models;
using BeuniAPI.Repositorys;
using Microsoft.AspNetCore.Mvc;

namespace BeuniAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductRepository productRepository;

        public ProductController(ProductRepository productRepository) // <- DI faz isso
        {
            this.productRepository = productRepository;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            return Ok(productRepository.FindAll());
        }

        // GET /Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(long id)
        {
            var product = await productRepository.FindByID(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

    }

}
