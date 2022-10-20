namespace WeatherReportSystem.Source1.Data
{
    public static class WeatherDataProvider
    {
        public static List<WeatherData> DataContainer()
            => new()
            {
                new()
                {
                    Temperature = 10,
                    Pressure = 1200
                },
                new()
                {
                    Temperature = 23,
                    Pressure = 980
                },
                new()
                {
                    Temperature = 21.3,
                    Pressure = 1230
                },
                new()
                {
                    Temperature = 34,
                    Pressure = 1430
                },
                new()
                {
                    Temperature = 29.4,
                    Pressure = 1100.03
                },
                new()
                {
                    Temperature = 12,
                    Pressure = 780
                },
                new()
                {
                    Temperature = -1,
                    Pressure = 970
                },
                new()
                {
                    Temperature = 0,
                    Pressure = 560.6
                },
            };
    }
}
