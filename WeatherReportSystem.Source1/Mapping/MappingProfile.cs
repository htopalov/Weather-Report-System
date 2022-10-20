using AutoMapper;
using WeatherReportSystem.Source1.Data;
using WeatherReportSystem.Source1.Models;

namespace WeatherReportSystem.Source1.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<WeatherData, WeatherDataExportModel>();
        }
    }
}
