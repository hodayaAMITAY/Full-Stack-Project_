using BLL.implemantation;
using BLL.Interface;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace codePulse.Api.Controllers
{
    //https://localhost:xxx/api/categories
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        // https://localhost:xxx/api/categories
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryDto request)
        {
            // Map DTO domain moduale



            CategoryDto response =  await categoryRepository.CreateAsync(request);

            //Domain model to DTO
            

            return Ok(response);

        }
        [HttpGet("{userid}")]
        public  async Task<IActionResult> GetAllByUserId(string userid)
        {
            // Map DTO domain moduale

            

          var d= await  categoryRepository.GetAllByUserId(userid);

           

            return Ok(d);

        }
        [HttpPut]
        //save id and all obj to update
        public async Task<IActionResult> Put(int id,CategoryDto categoryDto)
        {
            if (id != categoryDto.Id)
            {
                return BadRequest(); 
            }

            var updatedCategory = await categoryRepository.UpdateCategoryAsync(categoryDto);

            if (updatedCategory == null)
            {
                return NotFound(); // Category with the specified ID not found
            }

            return Ok(updatedCategory); // Return the updated category
        }


    }
}
