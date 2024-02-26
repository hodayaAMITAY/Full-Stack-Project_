using DAL.Models.Domain;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
    {
      public interface ILoginrepository
{
        //Task<bool> CheckUser(LoginDto user);
        Task<RegisterDto> CheckUser(LoginDto user);
        Task<bool> ResetPassword(ResetPasswordDto reset);
    }

}