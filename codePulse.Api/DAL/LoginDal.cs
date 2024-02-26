using DAL;
using DAL.Data;
using DAL.Domain;
using DAL.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LoginDal :ILoginDal
    {
        private readonly ApplicationDbContext dbContext;

        public LoginDal(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //public async Task<Login> CheckUser(Login user)
        //{
        //   // var includeI = dbContext.Registers.Where(r => r.FirstName.StartsWith('i'));
        //    var register = await dbContext.Registers.FirstOrDefaultAsync(r => r.Email == user.UserName && user.Password == r.Password);
        //    if(register != null)
        //    {
        //        return register;

        //    }
        //    else
        //    {
        //         throw new Exception("not find this user");
        //    }
        //}

        public async Task<Register> CheckUser(Login user)
        {
            var register = await dbContext.Registers.FirstOrDefaultAsync(r => r.Email == user.UserName && user.Password == r.Password);
            if (register != null)
            {
                return register;
            }
            else
            {
                throw new Exception("User not found");
            }
        }





        async Task<Boolean> ILoginDal.ResetPassword(ResetPassword reset)
        {
            var user = await dbContext.Registers.FirstOrDefaultAsync(r => r.Email == reset.UserName && reset.OldPassword == r.Password);
            if (user != null)
            {
                user.Password = reset.NewPassword;
                await dbContext.SaveChangesAsync();
                return true;

            }
            else
            {
                return false;
            }
        }


    }
}