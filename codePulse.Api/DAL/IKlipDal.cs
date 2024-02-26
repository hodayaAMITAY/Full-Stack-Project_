using DAL.Domain;
using DAL.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IKlipDal
    {
        Task<bool> DeleteKlip(int klipid);
        Task<Klip> CreateKlip(Klip klip);

        Task<List<Klip>> GetAllByUserId(string userid);
        //Task<List<Klip>> GetAll(int userid);
        Task<List<Klip>> GetAllByIdCategory(string userid,int categoryid);
    }
}
