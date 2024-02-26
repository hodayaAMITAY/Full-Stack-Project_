using DAL.Data;
using DAL.Domain;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class KlipDal : IKlipDal
    {
        private readonly ApplicationDbContext dbContext;
        public KlipDal(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Klip> CreatKlip(Klip klip)
        {
            await dbContext.Klips.AddAsync(klip);
            await dbContext.SaveChangesAsync();
            return klip;
        }
       public async Task<List<Klip>> GetAllByUserId(string userid)
        {
            var d = await dbContext.Klips.Where(r => r.RegisterId.ToString() == userid).ToListAsync();

            return d;

        }
        public async Task<List<Klip>>  GetAllByIdCategory(string userid, int categoryid)
        {
            var d = await dbContext.Klips.Where(r => r.RegisterId.ToString() == userid && r.CategoryId==categoryid).ToListAsync();

            return d;

        }


        public async Task<bool> DeleteKlip(int klipid)
        {

            var d = dbContext.Klips.FirstOrDefault(r => r.Id == klipid);
            dbContext.Klips.Remove(d);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Klip> CreateKlip(Klip klip)
        {
            await dbContext.Klips.AddAsync(klip);
            await dbContext.SaveChangesAsync();
            return klip;
        }

    
    }
}