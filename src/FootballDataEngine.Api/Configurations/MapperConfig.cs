using AutoMapper;
using FootballDataEngine.Api.Data;
using FootballDataEngine.Api.Models.Match;

namespace FootballDataEngine.Api.Configurations
{
    public class MapperConfig: Profile
    {
        public MapperConfig() 
        {
            CreateMap<MatchDto, Match>()
                .ForMember(dest => dest.MatchId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();
        }
    }
}
