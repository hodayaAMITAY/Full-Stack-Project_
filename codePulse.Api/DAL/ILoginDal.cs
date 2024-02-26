using DAL.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface ILoginDal
    {
        //User Authenticate(string username, string password);

        //Task<bool> CheckUser(Login login);
        Task<Register> CheckUser(Login user);
        Task<bool> ResetPassword(ResetPassword reset);
    }
}