using DAL.Domain;
using DTO;

namespace BLL.Interface
{
    public interface ICategoryRepository
    {
        Task<CategoryDto> CreateAsync(CategoryDto category);
        Task<List<CategoryDto>> GetAllByUserId(string userid);

        Task<CategoryDto> GET();


        //Task<RegisterDto> POST();
        Task<CategoryDto> UpdateCategoryAsync(CategoryDto category);

        
    }


}
