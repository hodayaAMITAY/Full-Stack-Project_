using BLL.implemantation;
using BLL.Interface;
using DAL;
using DTO;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KlipController : ControllerBase
    {
        private readonly IKlipRepository klipRepository;

        public KlipController(IKlipRepository klipRepository)
        {
            //hasama to mistane
            this.klipRepository = klipRepository;
        }



        // https://localhost:xxx/api/Klip
        [HttpPost("Klip")]
        public async Task<IActionResult> Createklip(KlipDto request)
        {
            KlipDto response = await klipRepository.CreateKlip(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteKlip(int klipid)
        {
            var deleted = await klipRepository.DeleteKlip(klipid);
            if (!deleted)
            {
                return NotFound(); // Entity with the specified ID not found
            }
            return NoContent(); // Deletion successful
        }



        [HttpGet("{userid}")]
        public async Task<IActionResult> GetKlipByUserId(string userid)
        {
            
            var d =await klipRepository.GetAllByUserId(userid);

            return Ok(d);

        }
    }
}
