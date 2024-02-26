using DAL.Domain;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IcategoryDal
    {
        Task<Category> CreateAsync(Category category);

        Task<List<Category>> GetAllByUserId(string userid);

        Task<Category> UpdateCategoryAsync(Category category);
     
    }
}
