using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using ProyectoIS.Models;
using ProyectoIS.Views;
using Xamarin.Forms;

namespace ProyectoIS.ViewModels
{
    class ViewModelAdmin : INotifyPropertyChanged
    {
        public ViewModelAdmin()
        {
            navegarformapago = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new ViewFormapago());
            });
            navegarestadopago = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new ViewEstadopago());
            });
            navegarsucursal = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new ViewSucursal());
            });
            navegarproducto = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new ViewProducto());
            });
        }
        
        
        private async void getClientes()
        {

            ListClientes = new ObservableCollection<Cliente>();

            HttpClient httpClient = new HttpClient();

            var respuesta = await httpClient.GetAsync(url);

            if (respuesta.IsSuccessStatusCode)
            {

                var contenido = await respuesta.Content.ReadAsStringAsync();
                JsonSerializerOptions opciones = new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                };
                var listado = System.Text.Json.JsonSerializer.Deserialize<List<Cliente>>(contenido, opciones);


                foreach (var item in listado)
                {

                    ListClientes.Add(item);


                }

            }
        }


        string url = "https://desfrlopez.me/crivera/api/cliente";

        ObservableCollection<Cliente> listClientes = new ObservableCollection<Cliente>();

        public ObservableCollection<Cliente> ListClientes
        {
            get => listClientes;
            set
            {

                listClientes = value;
                var args = new PropertyChangedEventArgs(nameof(ListClientes));
                PropertyChanged?.Invoke(this, args);

            }


        }

        string usuario;
        public string Usuario
        {
            get => usuario;
            set
            {

                usuario = value;
                var args = new PropertyChangedEventArgs(nameof(Usuario));
                PropertyChanged?.Invoke(this, args);

            }
        }
        public Command navegarformapago { get; }
        public Command navegarestadopago { get; }
        public Command navegarsucursal{ get; }
        public Command navegarproducto { get; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}

