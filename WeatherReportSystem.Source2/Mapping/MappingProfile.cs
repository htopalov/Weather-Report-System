using AutoMapper;
using WeatherReportSystem.Source2.Data;
using WeatherReportSystem.Source2.Models;

namespace WeatherReportSystem.Source2.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<WeatherData, WeatherDataElementExportModel>();
        }
    }
}
