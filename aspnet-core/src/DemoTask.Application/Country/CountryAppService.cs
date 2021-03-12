using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using DemoTask.Country.Dto;
using DemoTask.Dto.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTask.Country
{
   public class CountryAppService: DemoTaskAppServiceBase,ICountryAppService
    {
        private readonly IRepository<Country> _countryRepository;

        public CountryAppService(IRepository<Country> countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public ListResultDto<CountryListDto> GetCountries(GetCountryInput input)
        {
            var countries = _countryRepository
                .GetAll()
                .WhereIf(
                    !input.Filter.IsNullOrEmpty(),
                    p => p.Name.Contains(input.Filter)                         
                )
                .OrderBy(p => p.Name)                
                .ToList();

            return new ListResultDto<CountryListDto>(ObjectMapper.Map<List<CountryListDto>>(countries));
        }
        public  async Task CreateAsync(CreateCountryDto input)
        {        
            var country = ObjectMapper.Map<Country>(input);           
            await _countryRepository.InsertAsync(country);
        }
        public async Task DeleteCountry(EntityDto input) {
            await _countryRepository.DeleteAsync(input.Id);
        }
        public async Task<GetCountryForEditOutput> GetCountryForEdit(EntityDto input)
        {
            var country = await _countryRepository.GetAsync(input.Id);
         
            var countryEditDto = ObjectMapper.Map<CountryEditDto>(country);

            return new GetCountryForEditOutput
            {
                Country = countryEditDto,                
            };
        }

        public async Task EditCountry(CountryDto input)
        {
            var country = await _countryRepository.GetAsync(input.Id);
            country.Name = input.Name;           
            await _countryRepository.UpdateAsync(country);
        }
    }
}
