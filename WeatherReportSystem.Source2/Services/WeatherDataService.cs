using AutoMapper;
using WeatherReportSystem.Source2.Models;
using WeatherReportSystem.Source2.Utils;
using static WeatherReportSystem.Source2.Data.WeatherDataProvider;

namespace WeatherReportSystem.Source2.Services
{
    public class WeatherDataService : IWeatherDataService
    {
        private readonly IMapper mapper;

        public WeatherDataService(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public string GetData()
        {
            var random = new Random();

            var index = random.Next(DataContainer().Count);

            var currentData = DataContainer()[index];

            var dataElement = this.mapper.Map<WeatherDataElementExportModel>(currentData);

            var export = new WeatherDataXmlExportModel
            {
                Data = dataElement,
                Success = true,
                Error = 0
            };

            return Serializer.SerializeResponseBody(export);
        }
    }
}
