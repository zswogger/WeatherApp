namespace WeatherApp.Models
{
    public class WeatherData
    {
        public class coord
        {
            public double lon { get; set; }
            public double lat { get; set; }
        }

        public class weather
        {
            public string main { get; set; }
            public string description { get; set; }
            public string icon { get; set; }
        }

        public class main
        {
            public double temp { get; set; }
            public double temp_min { get; set; }
            public double temp_max { get; set; }
            public double humidity { get; set; }

        }

        public class wind
        {
            public double speed { get; set; }
        }

        public class sys
        {
            public long sunrise { get; set; }
            public long sunset { get; set; }
        }

        public class root
        {
            public string name { get; set; }
            public coord Coord { get; set; }
            public List<weather> Weather { get; set; }
            public main Main { get; set; }
            public wind Wind { get; set; }
            public sys Sys { get; set; }
        }
    }
}
