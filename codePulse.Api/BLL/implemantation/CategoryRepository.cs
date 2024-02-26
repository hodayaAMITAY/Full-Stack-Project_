using AutoMapper;
using BLL.Interface;
using DAL;
using DAL.Data;
using DAL.Domain;
using DAL.Models.Domain;
using DTO;
using Microsoft.EntityFrameworkCore;

namespace BLL.implemantation
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly IMapper mapper;    

        private readonly IcategoryDal categoryDal;
        public CategoryRepository(IcategoryDal dbContext, IMapper m)
        {
            this.categoryDal = dbContext;
            mapper = m;     
        }


        public ApplicationDbContext DbContext { get; }

        public async Task<CategoryDto> CreateAsync(CategoryDto category)
        {
          Category newCategory=   mapper.Map<Category>(category);
       
          var d=  await categoryDal.CreateAsync(newCategory);

          return  mapper.Map<CategoryDto>(d);
        }



        public Task<CategoryDto> GET()
        {
            throw new NotImplementedException();
        }

        public async Task<List<CategoryDto>> GetAllByUserId(string userid)
        {
            var h =await categoryDal.GetAllByUserId(userid);
            return mapper.Map<List<CategoryDto>>(h);   
        }


        public async Task<CategoryDto> UpdateCategoryAsync(CategoryDto category)
        {
            //hear real obj
            var d = mapper.Map<Category>(category);
            //hear save to update 
            var updatecategory= await categoryDal.UpdateCategoryAsync(d);
            //hear memira to dto
            return mapper.Map<CategoryDto>(updatecategory);
        }

    }
}
