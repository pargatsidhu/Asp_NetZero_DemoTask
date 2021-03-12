using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using AutoMapper;
using DemoTask.State.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTask.State
{
    public class StateAppService : DemoTaskAppServiceBase, IStateAppService
    {
        private readonly IRepository<State> _stateRepository;
        public StateAppService(IRepository<State> stateRepository)
        {
            _stateRepository = stateRepository;
        }

        public ListResultDto<StateListDto> GetStates(GetStateInput input)
        {
            var countries = _stateRepository
                .GetAll()
                .WhereIf(
                    !input.Filter.IsNullOrEmpty(),
                    p => p.Name.Contains(input.Filter) 
                )
                .OrderBy(p => p.Name)
                .ToList();

            return new ListResultDto<StateListDto>(ObjectMapper.Map<List<StateListDto>>(countries));
        }
        public async Task CreateAsync(CreateStateDto input)
        {

            var state = ObjectMapper.Map<State>(input);
            await _stateRepository.InsertAsync(state);

        }
        public async Task DeleteState(EntityDto input)
        {
            await _stateRepository.DeleteAsync(input.Id);
        }
        public async Task<GetStateForEditOutput> GetStateForEdit(EntityDto input)
        {
            var country = await _stateRepository.GetAsync(input.Id);

            var countryEditDto = ObjectMapper.Map<StateEditDto>(country);

            return new GetStateForEditOutput
            {
                State = countryEditDto,
            };
        }

        public async Task EditState(StateDto input)
        {
            var state = await _stateRepository.GetAsync(input.Id);
            state.Name = input.Name;
            state.Descreption = input.Descreption;
            state.CountryName = input.CountryName;
            await _stateRepository.UpdateAsync(state);
        }
    }
}
