using AutoMapper;
using WeatherReportSystem.Source1.Models;

using static WeatherReportSystem.Source1.Data.WeatherDataProvider;

namespace WeatherReportSystem.Source1.Services
{
    public class WeatherDataService : IWeatherDataService
    {
        private readonly IMapper mapper;

        public WeatherDataService(IMapper mapper)
            => this.mapper = mapper;

        public WeatherDataExportModel GetData()
        {
            var random = new Random();

            var index = random.Next(DataContainer().Count);

            var currentData = DataContainer()[index];

            return this.mapper.Map<WeatherDataExportModel>(currentData);

        }
    }
}
