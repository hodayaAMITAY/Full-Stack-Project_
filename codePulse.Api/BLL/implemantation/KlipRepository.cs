using AutoMapper;
using BLL.implemantation;
using BLL.Interface;
using DAL.Data;
using DAL.Domain;
using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DAL.Models.Domain;

namespace BLL.implemantation
{
    public class KlipRepository : IKlipRepository
    {
        private readonly IMapper mapper;
        private readonly IKlipDal klipDal;

        public KlipRepository(IKlipDal klipDal, IMapper mapper)
        {
            this.klipDal = klipDal;
           this.mapper = mapper;
        }
        public async Task<KlipDto> CreateKlip(KlipDto klip)
        {
            var newKlip = mapper.Map<Klip>(klip);
            var d = await klipDal.CreateKlip(newKlip);
            return mapper.Map<KlipDto>(d);
        }

        public async Task<List<KlipDto>> GetAllByIdCategory(string userid,int categoryid)
        {
            var klip =await klipDal.GetAllByIdCategory(userid, categoryid);
            return mapper.Map<List<KlipDto>>(klip);

        }
        //public async Task<List<KlipDto>> GetAll(int userid)
        //{
        //    //get all klip from db
        //    var klip = await klipDal.GetAll(userid);
        //    //hear return as dto
        //    return mapper.Map<List<KlipDto>>(klip);
        //}
        public async Task<List<KlipDto>> GetAllByUserId(string userid)
        {
            var h = await klipDal.GetAllByUserId(userid);
            var mapResult = mapper.Map<List<KlipDto>>(h);
            return mapResult != null && mapResult.Any() ?  mapResult.ToList() : new List<KlipDto>();
        }
        public async Task<bool> DeleteKlip(int klipid)
        {

            return await klipDal.DeleteKlip(klipid);
        }
    }
}
