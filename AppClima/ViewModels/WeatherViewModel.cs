using AppClima.Models;
using AppClima.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AppClima.ViewModels
{
    class WeatherViewModel : INotifyPropertyChanged
    {
        private WeatherData _weatherData = new WeatherData();
        public WeatherData WeatherDataInfo
        {
            get => _weatherData;
            set
            {
                if(_weatherData != value)
                {
                    _weatherData = value;
                    OnPropertyChanged();
                }
            }
        }
        public WeatherViewModel()
        {
            GetCurrentWeatherFromLocation();
        }
        public async void GetCurrentWeatherFromLocation()
        {
            WeatherServices weatherServices = new WeatherServices();
            WeatherDataInfo = await weatherServices.GetCurrentLocationWeatherAsync();
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
