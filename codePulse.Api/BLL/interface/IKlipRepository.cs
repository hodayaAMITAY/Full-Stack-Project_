using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IKlipRepository
    {
        Task<KlipDto> CreateKlip(KlipDto klip);
        //Task<List<KlipDto>> GetAll(int userid);

        Task<List<KlipDto>> GetAllByIdCategory(string userid, int categoryid);

        Task<List<KlipDto>> GetAllByUserId(string userid);

        Task<bool> DeleteKlip(int klipid);
        

    }
}
