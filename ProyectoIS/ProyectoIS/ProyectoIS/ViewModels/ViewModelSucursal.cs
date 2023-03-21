using Newtonsoft.Json;
using ProyectoIS.Models;
using ProyectoIS.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Xamarin.Forms;

namespace ProyectoIS.ViewModels
{
    public class ViewModelSucursal
    {
        public ViewModelSucursal()
        {
            getSucursal();
            registroSucursal = new Command(async () =>
            {
                using (var httpClient = new HttpClient())
                {
                    Sucursal body2 = new Sucursal()
                    {
                        id_sucursal = this.id_sucursal,
                        ciudad = this.ciudad,
                        departamento = this.departamento,
                        telefono = this.telefono


                    };
                    var myContent = JsonConvert.SerializeObject(body2);
                    var stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");

                    var respuesta = await httpClient.PostAsync(url, stringContent);

                    if (respuesta.IsSuccessStatusCode)
                    {
                        await Application.Current.MainPage.Navigation.PushAsync(new ViewAdmin());
                    }
                }
            }
            );
            actualizarSucursal = new Command(async () =>
            {
                using (var httpClient = new HttpClient())
                {
                    Sucursal body2 = new Sucursal()
                    {

                        ciudad = this.ciudad,
                        departamento = this.departamento,
                        telefono = this.telefono


                    };
                    var myContent = JsonConvert.SerializeObject(body2);
                    var stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");

                    var respuesta = await httpClient.PutAsync(url + Id_sucursal, stringContent);

                    if (respuesta.IsSuccessStatusCode)
                    {
                        await Application.Current.MainPage.Navigation.PushAsync(new ViewAdmin());
                    }
                }
            }
            );
            eliminarSucursal = new Command(async () =>
            {
                using (var httpClient = new HttpClient())
                {
                    Sucursal body2 = new Sucursal()
                    {

                        ciudad = this.ciudad,
                        departamento = this.departamento,
                        telefono = this.telefono


                    };
                    var myContent = JsonConvert.SerializeObject(body2);
                    var stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");

                    var respuesta = await httpClient.DeleteAsync(url + Id_sucursal);

                    if (respuesta.IsSuccessStatusCode)
                    {
                        await Application.Current.MainPage.Navigation.PushAsync(new ViewAdmin());
                    }
                }
            }
            );
        }

        private async void getSucursal()
        {

            ListSucursal = new ObservableCollection<Sucursal>();

            HttpClient httpClient = new HttpClient();

            var respuesta = await httpClient.GetAsync(url);

            if (respuesta.IsSuccessStatusCode)
            {

                var contenido = await respuesta.Content.ReadAsStringAsync();
                JsonSerializerOptions opciones = new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                };
                var listado = System.Text.Json.JsonSerializer.Deserialize<List<Sucursal>>(contenido, opciones);


                foreach (var item in listado)
                {

                    ListSucursal.Add(item);


                }

            }
        }
        INavigation navigation;

        string url = "https://desfrlopez.me/crivera/api/sucursal/";

        ObservableCollection<Sucursal> listSucursal = new ObservableCollection<Sucursal>();

        public ObservableCollection<Sucursal> ListSucursal
        {
            get => listSucursal;
            set
            {

                listSucursal = value;
                var args = new PropertyChangedEventArgs(nameof(ListSucursal));
                PropertyChanged?.Invoke(this, args);

            }


        }

        string ciudad;
        public string Ciudad
        {
            get => ciudad;
            set
            {

                ciudad = value;
                var args = new PropertyChangedEventArgs(nameof(Ciudad));
                PropertyChanged?.Invoke(this, args);

            }
        }
        int id_sucursal;

        public int Id_sucursal
        {
            get => id_sucursal;
            set
            {

                id_sucursal = value;
                var args = new PropertyChangedEventArgs(nameof(Id_sucursal));
                PropertyChanged?.Invoke(this, args);

            }
        }
        int telefono;
        public int Telefono
        {
            get => telefono;
            set
            {

                telefono = value;
                var args = new PropertyChangedEventArgs(nameof(Telefono));
                PropertyChanged?.Invoke(this, args);

            }
        }
        string departamento;
        public string Departamento
        {
            get => departamento;
            set
            {

                departamento = value;
                var args = new PropertyChangedEventArgs(nameof(Departamento));
                PropertyChanged?.Invoke(this, args);

            }
        }

        public Command registroSucursal { get; set; }
        public Command actualizarSucursal { get; set; }
        public Command eliminarSucursal { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}

