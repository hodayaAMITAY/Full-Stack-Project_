using AutoMapper;
using BLL.Interface;
using DAL.Data;
using DAL.Domain;
using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using DAL;
using DAL.Models.Domain;

namespace BLL.implemantation
{
    public class RegisterRepository : iRegisterRepository 
    {
        
         //mistane of maclaka
          private readonly IMapper mapper;

          private readonly IRegisterDal registerDal;
        //get two obj that can use 
            public RegisterRepository(IRegisterDal registerobj, IMapper m)
            {
                this.registerDal = registerobj;
                mapper = m;
            }



            // also get and return 
            public async Task<RegisterDto> CreateAsync(RegisterDto register)
            {
             // creat real object of register 
                Register newRegister = mapper.Map<Register>(register);
               // creat at db the var d need return to clien 
                var d = await registerDal.CreateAsync(newRegister);
             //agaim to hamara to clien
                return mapper.Map<RegisterDto>(d);
            }



            public Task<RegisterDto> GET()
            {
                throw new NotImplementedException();
            }

            public List<RegisterDto> GetAll()
            {

             //also want return as dto
                var h = registerDal.GetAll();
                return mapper.Map<List<RegisterDto>>(h);
                //return h.Select(x => new CategoryDto()
                //{
                //    Id = x.Id,
                //    Name = x.Name,
                //    UrlHandle = x.UrlHandle
                //}).ToList();
            }
        
    }
}
