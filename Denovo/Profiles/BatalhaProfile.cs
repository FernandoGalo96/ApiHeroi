using AutoMapper;
using Denovo.HeroisContext.Dtos;
using Models;

namespace Denovo.Profiles;

public class BatalhaProfile : Profile
{
    public BatalhaProfile()
    {
        CreateMap<CreateBatalhaDto, Batalha>();
        CreateMap<UpdateBatalhaDto, Batalha>();
        CreateMap<Batalha, ReadBatalhaDto>().ForMember(batalhaDto => batalhaDto.HeroiBatalhas, opts =>
        opts.MapFrom(batalha => batalha.HeroiBatalhas));


    }
}
