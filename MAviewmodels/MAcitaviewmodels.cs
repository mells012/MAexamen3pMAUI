using MAexamen3pMAUI.MAmodels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Net.Http.Json;
using System.Windows.Input;

namespace MAviewmodels
{
    public class MAcitaviewmodels : BaseViewModel
    {
        private const string ApiUrl = "https://quotes.rest/qod";
        public ObservableCollection<Cita> Citas { get; set; } = new();
        private Cita _citaSeleccionada;
        public Cita CitaSeleccionada
        {
            get => _citaSeleccionada;
            set
            {
                _citaSeleccionada = value;
                OnPropertyChanged();
            }
        }

        public ICommand VerDetallesCommand { get; }

        public MAcitaviewmodels()
        {
            VerDetallesCommand = new Command(OnVerDetalles);
            CargarCitas();
        }

        private async void CargarCitas()
        {
            using var httpClient = new HttpClient();
            var response = await httpClient.GetFromJsonAsync<ApiResponse>(ApiUrl);
            if (response?.Contents?.Quotes != null)
            {
                foreach (var cita in response.Contents.Quotes)
                {
                    Citas.Add(cita);
                }
            }
        }

        private async void OnVerDetalles()
        {
            if (CitaSeleccionada != null)
            {
                await Shell.Current.GoToAsync($"MADetallesPage?quoteText={CitaSeleccionada.QuoteText}&author={CitaSeleccionada.Author}");
            }
        }
    }

    public class ApiResponse
    {
        public Contents Contents { get; set; }
    }

    public class Contents
    {
        public List<Cita> Quotes { get; set; }
    }

    public class Cita
    {
        public string QuoteText { get; set; }
        public string Author { get; set; }
    }
}

