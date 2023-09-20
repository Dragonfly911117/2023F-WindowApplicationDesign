using System;
using System.Collections.Generic;
using System.Text;

namespace Tutorial
{
    public delegate void WeatherUpdated();

    class WeatherSensor
    {
        protected float _temperature;
        protected float _humidity;
        protected string _location;
        protected event WeatherUpdated _stations;

        #region Properties

        public WeatherUpdated WearherStations
        {
            get { return _stations; }
            set { _stations = value; }
        }

        public float KelvinDegrees
        {
            get { return _temperature; }
            set
            {
                _temperature = value;
                NotifyWeatherStations();
            }
        }

        private void NotifyWeatherStations()
        {
            foreach (WeatherUpdated s in _stations.GetInvocationList()) s();
        }

        public float Humidity
        {
            get { return _humidity; }
            set
            {
                _humidity = value;
                NotifyWeatherStations();
            }
        }

        public string Location
        {
            get { return _location; }
        }

        #endregion

        public WeatherSensor(string location, float temperature, float humility)
        {
            _location = location;
            _temperature = temperature;
            _humidity = humility;
        }
    }

    abstract class WeatherStation
    {
        protected WeatherSensor _weather;
        protected abstract void ShowWeather();
    }

    class TaiwanWeatherStation : WeatherStation
    {
        public TaiwanWeatherStation(WeatherSensor weather)
        {
            _weather = weather;
            _weather.WearherStations += new WeatherUpdated(ShowWeather);
        }

        protected override void ShowWeather()
        {
            System.Console.WriteLine("Taiwan Weather Station:");
            System.Console.WriteLine("The weather at " + _weather.Location);
            System.Console.Write("Temperature: " + (_weather.KelvinDegrees - 273) + "C, ");
            System.Console.WriteLine("Humidity: " + _weather.Humidity + "%\n");
        }
    }

    class NewYorkWeatherStation : WeatherStation
    {
        public NewYorkWeatherStation(WeatherSensor weather)
        {
            _weather = weather;
            _weather.WearherStations += new WeatherUpdated(ShowWeather);
        }

        protected override void ShowWeather()
        {
            System.Console.WriteLine("New York Weather Station:");
            System.Console.WriteLine("The weather at " + _weather.Location);
            System.Console.Write("Temperature:" + (((_weather.KelvinDegrees - 273) * 9 / 5) + 32)
                                                + "F, ");
            System.Console.WriteLine("Humidity: " + _weather.Humidity + "%\n");
            if ((_weather.KelvinDegrees - 273) <= 0 && _weather.Humidity > 50)
                System.Console.WriteLine("It may start to snow!");
        }
    }

    public class MainEntry
    {
        public static void Main()
        {
            WeatherSensor weather = new WeatherSensor("Los Angeles", 275.0f, 40.0f);
            TaiwanWeatherStation taiwan = new TaiwanWeatherStation(weather);
            NewYorkWeatherStation newYork = new NewYorkWeatherStation(weather);
            weather.KelvinDegrees = 274.0f;
            weather.KelvinDegrees = 272.0f;
            weather.Humidity = 60.0f;
            // System.Console.Read();
        }
    }
}


