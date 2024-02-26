using DAL.Data;
using DAL.Domain;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using DAL.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DAL
{
    public class RegisterDal : IRegisterDal
    {
        private readonly ApplicationDbContext dbContext;

        public RegisterDal(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public ApplicationDbContext DbContext { get; }

        public List<Register> GetAll()
        {
            return dbContext.Registers.ToList();
        }

        async Task<Register> IRegisterDal.CreateAsync(Register register)
        {
            var exsitsuser = await dbContext.Registers.Where(r => r.Email == register.Email).ToListAsync();
            if(exsitsuser.Any())
            {
                throw new Exception("the email exsits");
                
            }
            await dbContext.Registers.AddAsync(register);
            await dbContext.SaveChangesAsync();
            return register;
        }

    }
 
}
