using AutoMapper;
using TCCII.Deputados.API.DTOs.RequestModels.Deputados;
using TCCII.Deputados.API.DTOs.ResponseModels.Deputados;
using TCCII.Deputados.Core.Entities;

namespace TCCII.Deputados.API.Profiles
{
    public class DeputadosProfile : Profile
    {
        public DeputadosProfile()
        {
            CreateMap<CreateDeputadosRequest, Deputado>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .AfterMap((src, dest) => dest.IdDeputado = src.id);

            CreateMap<Deputado, DeputadosResponse>()
                .AfterMap((src, dest) => dest.Id = src.IdDeputado)
                .ReverseMap();
        }
    }
}
