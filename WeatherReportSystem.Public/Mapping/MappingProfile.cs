using AutoMapper;
using WeatherReportSystem.Public.Models;

namespace WeatherReportSystem.Public.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<WeatherDataFromJsonModel, WeatherDataExport>();
            this.CreateMap<WeatherDataFromXmlModel, WeatherDataExport>()
                .ForMember(dest => dest.Pressure, opt => opt.MapFrom(s => s.Data.Pressure))
                .ForMember(dest => dest.Temperature, opt => opt.MapFrom(s => s.Data.Temperature));
        }
    }
}
