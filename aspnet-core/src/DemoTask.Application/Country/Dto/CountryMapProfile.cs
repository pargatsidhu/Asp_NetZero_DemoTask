using AutoMapper;
using DemoTask.Dto.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTask.Country.Dto
{
   public class CountryMapProfile : Profile
    {
        public CountryMapProfile() {
            CreateMap<CountryListDto, Country>();
            CreateMap<Country, CountryListDto>();
            CreateMap<CreateCountryDto, Country>();

            CreateMap<CountryDto, Country>();

            //CreateMap<Role, RoleDto>().ForMember(x => x.GrantedPermissions,
            //    opt => opt.MapFrom(x => x.Permissions.Where(p => p.IsGranted)));
            CreateMap<Country, CountryEditDto>();
        }
    }
}
