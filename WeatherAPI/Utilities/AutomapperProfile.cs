using AutoMapper;
using WeatherAPI.DTO;
using WeatherAPI.Entities;
using WeatherAPI.Migrations;

namespace WeatherAPI.Utilities
{
    public class AutomapperProfile
    {
        public class AutoMapperProfile : Profile
        {
            public AutoMapperProfile()
            {
                CreateMap<PmeMember, PmeMemberDTO>().ReverseMap();
            }

        }
    }
}
