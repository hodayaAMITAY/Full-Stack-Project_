using DAL.Data;
using DAL.Domain;
using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class CategoryDal : IcategoryDal
    {

        private readonly ApplicationDbContext dbContext;
        public CategoryDal(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public ApplicationDbContext DbContext { get; }
        public async Task<Category> CreateAsync(Category category)
        {
            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();
            return category;
        }

        public async Task<List<Category>> GetAllByUserId(string userid)
        {

            return await dbContext.Categories.Where(r=> r.RegisterId.ToString()==userid).ToListAsync();
            //await dbContext.SaveChangesAsync();
            //return category;
        }

        public async Task<Category> UpdateCategoryAsync(Category category)
        {
            var Exsitscategory = dbContext.Categories.FirstOrDefault(r => category.Id == r.Id);
            if (Exsitscategory!=null)

            {
                Exsitscategory.Name = category.Name;
                //Exsitscategory.UrlHandle = category.UrlHandle;
                await dbContext.SaveChangesAsync();
                //return rhe obj last changes!!
                return Exsitscategory;
            }
            else
            {
                throw new Exception("not find category with this id");
            }
        }


    }
}
