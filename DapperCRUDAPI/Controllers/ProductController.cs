using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperCRUDAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperCRUDAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductRepository productRepository;

        public ProductController()
        {
            productRepository = new ProductRepository();
        }

        // # api/product => get
        [HttpGet] 
        public IEnumerable<Product> Get()
        {
            return productRepository.GetAll();

        }

        // # api/product/:id
        [HttpGet("{id}")]

        public Product Get(int id)
        {
            return productRepository.GetById(id);
        }

        // # api/product/id

        //[HttpGet("{id}")]
        //public IActionResult GetBebas(string id)
        //{
        //    return Ok();
        //}

        // INSERT 
        [HttpPost]
        public void Post([FromBody] Product prod)
        {
            if (ModelState.IsValid) productRepository.Add(prod);
        }

        //UPDATE

        [HttpPut]
        public void Put(int id, [FromBody] Product prod)
        {
            prod.ProductId = id;
            if (ModelState.IsValid) productRepository.Update(prod);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            productRepository.Delete(id);
        }

    }
}
