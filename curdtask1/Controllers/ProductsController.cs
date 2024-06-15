using curdtask1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace curdtask1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        List<Products> products = new List<Products> {

         new Products{Id= 1, Name="Apples",Description="this  is Apples"},
             new Products{Id= 2, Name="Lemon",Description="this is Lemon"},


new Products{Id= 3, Name="Mint",Description="this is Mint"},
       };
        [HttpGet]
        public IActionResult GetProducts() {

            return Ok(products);
        }

        [HttpGet("{id}")]

        public IActionResult GetProduct_byid(int id)
        {
            var product = products.FirstOrDefault(x => x.Id == id);

            if (product is null)
            {
                return NotFound();
            }

            return Ok(product);
        }
        [HttpPost]
        public IActionResult nwe_product(Products requst)
        {
            if (requst is null)
            {
                return BadRequest();
            }
            var product = new Products
            {
                Id = requst.Id,
                Name = requst.Name,
                Description = requst.Description,

            };
            products.Add(product);
            return Ok(product);
        }

        [HttpPut("{id}")]
        public IActionResult update(int id,Products requst)
        {
            var produpd = products.FirstOrDefault(prod => prod.Id == id);
            
            if(produpd is null)
            {
                return NotFound();

            }
            produpd.Name = requst.Name;
            produpd.Description = requst.Description;
                
                return Ok(produpd);
        }

        [HttpDelete("{id}")]
        public IActionResult delete(int id)
        {
            var prod= products.FirstOrDefault(prod => prod.Id == id);

            if (prod is null)
            {
                return NotFound();

            }
           products.Remove(prod);
            return Ok();
        }
    }
}
