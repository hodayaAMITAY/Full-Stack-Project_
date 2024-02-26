using DAL.Domain;
using DAL.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRegisterDal
    {
        Task<Register> CreateAsync(Register register);
        List<Register> GetAll();
    }
}