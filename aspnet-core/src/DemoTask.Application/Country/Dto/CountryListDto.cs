using Abp.Application.Services.Dto;

namespace DemoTask.Dto.Country
{
    public class GetCountryInput
    {
        public string Filter { get; set; }
    }
    public class CountryListDto : EntityDto
    {
        public string Name { get; set; }
    }
}