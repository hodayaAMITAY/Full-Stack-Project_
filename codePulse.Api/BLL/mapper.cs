using AutoMapper;
using DAL;
using DAL.Domain;
using DAL.Models.Domain;
using DTO;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class mapper : Profile
    {

        public mapper()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<Register, RegisterDto>();
            CreateMap<RegisterDto, Register>();
            CreateMap<Login, LoginDto>();
            CreateMap<LoginDto, Login>();
            CreateMap<Klip, KlipDto>();
            CreateMap<KlipDto, Klip>();
            CreateMap<ResetPassword, ResetPasswordDto>();
            CreateMap<ResetPasswordDto, ResetPassword>();


        }
    }
}
