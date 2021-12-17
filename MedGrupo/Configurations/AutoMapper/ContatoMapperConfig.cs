using Apl.ERP.API.Models;
using Apl.ERP.API.ModelViews;

using AutoMapper;

using System;

namespace Apl.ERP.API.Configurations.AutoMapper
{
    public class ContatoMapperConfig : Profile
    {
        public ContatoMapperConfig()
        {
            CreateMap<Contato, ContatoView>()
                .ForMember(c => c.ContatoID, cv => cv.MapFrom(m => m.ContatoID))
                .ForMember(c => c.Idade, cv => cv.MapFrom(m => m.Idade))
                .ForMember(c => c.Nascimento, cv => cv.MapFrom(m => m.Nascimento.ToString("dd/MM/yyyy")))
                .ForMember(c => c.Nome, cv => cv.MapFrom(m => m.Nome))
                .ForMember(c => c.Sexo, cv => cv.MapFrom(m => m.Sexo))
                .ForMember(c => c.Status, cv => cv.MapFrom(m => m.Status));

            CreateMap<ContatoView, Contato>()
                .ForMember(cv => cv.ContatoID, c => c.MapFrom(m => m.ContatoID))
                .ForMember(cv => cv.Idade, c => c.MapFrom(m => m.Idade))
                .ForMember(cv => cv.Nascimento, c => c.MapFrom(m => DateTime.Parse(m.Nascimento)))
                .ForMember(cv => cv.Nome, c => c.MapFrom(m => m.Nome))
                .ForMember(cv => cv.Sexo, c => c.MapFrom(m => m.Sexo))
                .ForMember(cv => cv.Status, c => c.MapFrom(m => m.Status));

        }
    }
}
