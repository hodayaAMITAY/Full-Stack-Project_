using Azure.Core;
using BLL.implemantation;
using BLL.Interface;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase


    {
        //mistane
        private readonly iRegisterRepository registerRepository;
        private readonly ILoginrepository loginRepository;
        public RegisterController(iRegisterRepository registerRepository,ILoginrepository loginRepository)
        {
             //hasama to mistane
            this.registerRepository = registerRepository;
            this.loginRepository = loginRepository;
        }



        // https://localhost:xxx/api/Register
        [HttpPost("Register")]
        public async Task<IActionResult> creatregister(RegisterDto request)
        {
            RegisterDto response = await registerRepository.CreateAsync(request);
            return Ok(response);
        }


        // https://localhost:xxx/api/Login
        [HttpPost("Login")]
        public async Task<IActionResult> anotherName(LoginDto login)
        {
            //bool ifExists = await loginRepository.CheckUser(login);
            //return Ok(ifExists);
            RegisterDto response = await loginRepository.CheckUser(login);
            return Ok(response);
        }
        [HttpPost("resetPassword")]
        public async Task<IActionResult> resetPassword(ResetPasswordDto reset)
        {
            bool ifExists = await loginRepository.ResetPassword(reset);
            return Ok(ifExists);
        }
    }
}