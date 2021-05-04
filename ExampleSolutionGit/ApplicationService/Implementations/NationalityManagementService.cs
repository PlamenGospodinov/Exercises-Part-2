using ApplicationService.DTOs;
using Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;

namespace ApplicationService.Implementations
{
    public class NationalityManagementService
    {
        private Student1SystemDBContext ctx = new Student1SystemDBContext();

        public List<NationalityDTO> Get()
        {
            List<NationalityDTO> nationalitiesDto = new List<NationalityDTO>();

            foreach(var item in ctx.Nationalities.ToList())
            {
                nationalitiesDto.Add(new NationalityDTO
                {
                    Id = item.Id,
                    Title = item.Title
                }) ;
            }

            return nationalitiesDto;
        }

        public bool Save(NationalityDTO nationalityDTO)
        {
            Nationality Nationality = new Nationality
            {
                Title = nationalityDTO.Title
            };

            try
            {
                ctx.Nationalities.Add(Nationality);
                ctx.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                Nationality nationality = ctx.Nationalities.Find(id);
                ctx.Nationalities.Remove(nationality);
                ctx.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
