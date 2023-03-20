using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductCategory_MOngoDb_Mar17.Models;
using ProductCategory_MOngoDb_Mar17.Repository;

namespace ProductCategory_MOngoDb_Mar17.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("swagger")] 
    public class ProductCategoryController : ControllerBase
    {
        private readonly ProductCategoryRepository _repository;
        public ProductCategoryController(ProductCategoryRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<List<ProductCategory>> Get() =>
            await _repository.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<ProductCategory>>Get(string id)
        {
            var procat=await _repository.GetAsync(id);
            if(procat is null)
            {
                return NotFound();
            }
            return procat; 
        }

        [HttpGet("categoryName")]
        public async Task<ActionResult<ProductCategory>>GetCategoryName(string categoryName) 
        {
            var catpro = await _repository.GetAsyncOne(categoryName);
            if(catpro is null)
            {
                return NotFound();
            }
            return catpro; 

        }

        [HttpPost]
        public async Task<IActionResult>Post(ProductCategory productCategory) 
        {
            await _repository.CreateAsync(productCategory);
            return CreatedAtAction(nameof(Get), new { id = productCategory.id }, productCategory);  
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult>Update(string id, ProductCategory productCategory)
        {
            var procatid = await _repository.GetAsync(id);
            if(procatid is null)
            {
                return NotFound();
            }
            productCategory.id = procatid.id;
            await _repository.UpdateAsync(id, productCategory);
            return NoContent(); 
        }


        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult>Delete(string id)
        {
            var proid = await _repository.GetAsync(id);
            if(proid is null)
            {
                return NotFound();
            }
            await _repository.DeleteAsync(id);
            return NoContent(); 
        }
    }
}
