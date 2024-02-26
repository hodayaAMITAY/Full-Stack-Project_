using AutoMapper;
using BLL;
using BLL;
using BLL.Interface;
using DAL;
using DAL.Models.Domain;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.implemantation
{
    public class LoginRepository :ILoginrepository
    {
        private readonly IMapper mapper;
        private readonly ILoginDal loginDal;

        public LoginRepository(IMapper m, ILoginDal loginObj)
        {
            this.loginDal = loginObj;
            mapper = m;

        }

     


        public async Task<RegisterDto> CheckUser(LoginDto user)
        {
            // creat real object of register 
            Login usernew = mapper.Map<Login>(user);
            // creat at db the var d need return to clien 
            var d = await loginDal.CheckUser(usernew);
            //agaim to hamara to clien
            return mapper.Map<RegisterDto>(d);
        }


        public async Task<bool> ResetPassword(ResetPasswordDto reset)
        {
            // creat real object of register 
            ResetPassword usernew = mapper.Map<ResetPassword>(reset);
            // creat at db the var d need return to clien 
            var d = await loginDal.ResetPassword(usernew);
            //agaim to hamara to clien
            return d;
        }


        

    }
}
