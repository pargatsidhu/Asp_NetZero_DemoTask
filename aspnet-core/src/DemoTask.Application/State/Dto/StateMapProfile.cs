using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTask.State.Dto
{
    public class StateMapProfile : Profile
    {
        public StateMapProfile()
        {
            CreateMap<StateListDto, State>();
            CreateMap<State, StateListDto>();
            CreateMap<CreateStateDto, State>();

            CreateMap<StateDto, State>();

            //CreateMap<Role, RoleDto>().ForMember(x => x.GrantedPermissions,
            //    opt => opt.MapFrom(x => x.Permissions.Where(p => p.IsGranted)));
            CreateMap<State, StateEditDto>();
        }
    }
}
