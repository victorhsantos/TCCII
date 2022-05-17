using AutoMapper;
using TCCII.API.Authentication.API.DTOs.RequestModels.Deputados;
using TCCII.API.Authentication.API.DTOs.ResponseModels.Deputados;
using TCCII.Core.Entities;

namespace TCCII.API.Authentication.API.Profiles
{
    public class DeputadosProfile : Profile
    {
        public DeputadosProfile()
        {
            CreateMap<CreateDeputadosRequest, Deputados>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .AfterMap((src, dest) => dest.IdDeputado = src.id);

            CreateMap<Deputados, DeputadosResponse>()                
                .AfterMap((src, dest) => dest.Id = src.IdDeputado);
        }
    }
}
