using AutoMapper;
using TCCII.Deputados.API.DTOs.RequestModels.Despesas;
using TCCII.Deputados.API.DTOs.ResponseModels.Despesas;
using TCCII.Deputados.Core.Entities;

namespace TCCII.Deputados.API.Profiles
{
    public class DespesasProfile : Profile
    {
        public DespesasProfile()
        {
            CreateMap<DespesasRequest, Despesa>()
                .ForMember(x => x.Id, opt => opt.Ignore())                
                .AfterMap((src, dest) => dest.notificada = 0)
                .ReverseMap();

            CreateMap<Despesa, DespesaResponse>()                
                .ReverseMap();
        }
    }
}
