using Abp.Application.Services;
using Abp.Application.Services.Dto;
using DemoTask.Country.Dto;
using DemoTask.Dto.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTask.Country
{
   public interface ICountryAppService : IApplicationService
    {
        ListResultDto<CountryListDto> GetCountries(GetCountryInput input);
        Task CreateAsync(CreateCountryDto input);
        Task DeleteCountry(EntityDto input);
        Task<GetCountryForEditOutput> GetCountryForEdit(EntityDto input);
        Task EditCountry(CountryDto input);
    }
}
