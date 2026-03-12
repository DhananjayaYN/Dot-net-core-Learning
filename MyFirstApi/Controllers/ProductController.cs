using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;

namespace MyFirstApi.Controllers

{

    [ApiController]

    [Route("api/[controller]")]

    public class ProductController : ControllerBase

    {

        [HttpGet] // GET: api/product
        public ActionResult<List<string>> Get()
        {
            return new List<string> { "Apple", "Banana", "Orange" };
        }

        
        [HttpGet("featured")] // GET: api/product/featured
        public string GetFeaturedProduct() => "Mango";



        [HttpPost] // POST: api/product
        public ActionResult<string> Post([FromBody] string newProduct)
        {
            return $"Added: {newProduct}";
        }


        [HttpPut("{id}")] // PUT: api/product/{id}
        public ActionResult<string> Put(int id, [FromBody] string updatedProduct)
        {
            return $"Updated product {id} to: {updatedProduct}";
        }


        [HttpDelete("{id}")] // DELETE: api/product/{id}
        public ActionResult<string> Delete(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest(new
                    {
                        Success = false,
                        Message = $"Invalid product ID : {id}. ID must be greater than zero.",
                        StatusCode = 400
                    });
                }
                else
                {
                    return Ok(new
                    {
                        Success = true,
                        Message = $"Product id : {id} deleted successfully.",
                        StatusCode = 200
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Success = false,
                    Message = $"An error occurred while deleting product id : {id}. Error: {ex.Message}",
                    StatusCode = 500
                });
            }
            
        }

    }

}