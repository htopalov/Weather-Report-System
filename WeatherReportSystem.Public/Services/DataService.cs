using System.Net.Http.Headers;
using System.Text.Json;
using System.Xml.Serialization;
using AutoMapper;
using WeatherReportSystem.Public.Models;

namespace WeatherReportSystem.Public.Services
{
    public class DataService : IDataService
    {
        private readonly IConfiguration config;
        private readonly IMapper mapper;

        public DataService(IConfiguration config, IMapper mapper)
        {
            this.config = config;
            this.mapper = mapper;
        }

        public async Task<ClientDataExport> GetData()
        {
            var sourceList = GetConfigurationsOfDataSources();
            var clientData = new ClientDataExport();
            foreach (var currentDataSource in sourceList)
            {
                var responseResult = await Client(currentDataSource.BaseUrl,
                    currentDataSource.DataEndpoint,
                    currentDataSource.ContentTypeOfResponse);

                if (responseResult.StatusCode == 200 && responseResult.WeatherData.Pressure != null) //additional check for xml attribute(obj property) error in Source2 occurs!!!
                {
                    clientData.Success = true;
                    clientData.WeatherData = responseResult.WeatherData;
                    return clientData;
                }
            }

            return clientData;
        }

        private async Task<RequestResultObject> Client(string baseUrl, string dataEndpoint, string contentType)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));
            var response = new HttpResponseMessage();
            var data = new WeatherDataExport();
            try
            {
                response = await client.GetAsync(dataEndpoint);
                var body = await response.Content.ReadAsStringAsync();
                data = DeserializeResponse(body, contentType);
            }
            catch (Exception)
            {
                return new RequestResultObject
                {
                    StatusCode = 500,
                };
            }


            return new RequestResultObject
            {
                StatusCode = (int)response.StatusCode,
                WeatherData = data
            };
        }

        private WeatherDataExport DeserializeResponse(string responseBody, string contentType)
        {
            switch (contentType)
            {
                case "application/json":
                    var result = JsonSerializer.Deserialize<WeatherDataFromJsonModel>(responseBody);
                    return this.mapper.Map<WeatherDataExport>(result);
                case "application/xml":
                    var serializer = new XmlSerializer(typeof(WeatherDataFromXmlModel));
                    var data = new WeatherDataFromXmlModel();
                    using (var reader = new StringReader(responseBody))
                    {
                        data = (WeatherDataFromXmlModel)serializer.Deserialize(reader);
                    }
                    return this.mapper.Map<WeatherDataExport>(data);
                default:
                    return null;
            }
        }

        private List<SourceConfig> GetConfigurationsOfDataSources()
        {
            var source1Config = config
                .GetSection("DataSources")
                .GetSection("Source1")
                .Get<SourceConfig>();

            var source2Config = config
                .GetSection("DataSources")
                .GetSection("Source2")
                .Get<SourceConfig>();

            return new List<SourceConfig> { source1Config, source2Config };
        }
    }
}
