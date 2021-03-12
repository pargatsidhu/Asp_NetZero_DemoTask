using Abp.Application.Services;
using Abp.Application.Services.Dto;
using DemoTask.State.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTask.State
{
   public interface IStateAppService: IApplicationService
    {
        ListResultDto<StateListDto> GetStates(GetStateInput input);
        Task CreateAsync(CreateStateDto input);
        Task DeleteState(EntityDto input);
        Task<GetStateForEditOutput> GetStateForEdit(EntityDto input);
        Task EditState(StateDto input);
    }
}
