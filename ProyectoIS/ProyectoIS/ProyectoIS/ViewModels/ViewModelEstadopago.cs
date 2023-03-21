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
    class ViewModelEstadopago
    {
        public ViewModelEstadopago()
        {
            getEstadopago();
            registroEstadopago = new Command(async () =>
            {
                using (var httpClient = new HttpClient())
                {
                    Estadopago body2 = new Estadopago()
                    {
                        id_estado= this.id_estado,
                        descripcion = this.descripcion


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
            actualizarEstadopago = new Command(async () =>
            {
                using (var httpClient = new HttpClient())
                {
                    Formapago body2 = new Formapago()
                    {

                        descripcion = this.descripcion


                    };
                    var myContent = JsonConvert.SerializeObject(body2);
                    var stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");

                    var respuesta = await httpClient.PutAsync(url + Id_estado, stringContent);

                    if (respuesta.IsSuccessStatusCode)
                    {
                        await Application.Current.MainPage.Navigation.PushAsync(new ViewAdmin());
                    }
                }
            }
            );
            eliminarEstadopago = new Command(async () =>
            {
                using (var httpClient = new HttpClient())
                {
                    Formapago body2 = new Formapago()
                    {

                        descripcion = this.descripcion


                    };
                    var myContent = JsonConvert.SerializeObject(body2);
                    var stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");

                    var respuesta = await httpClient.DeleteAsync(url + Id_estado);

                    if (respuesta.IsSuccessStatusCode)
                    {
                        await Application.Current.MainPage.Navigation.PushAsync(new ViewAdmin());
                    }
                }
            }
            );
        }

        private async void getEstadopago()
        {

            ListEstadopago = new ObservableCollection<Estadopago>();

            HttpClient httpClient = new HttpClient();

            var respuesta = await httpClient.GetAsync(url);

            if (respuesta.IsSuccessStatusCode)
            {

                var contenido = await respuesta.Content.ReadAsStringAsync();
                JsonSerializerOptions opciones = new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                };
                var listado = System.Text.Json.JsonSerializer.Deserialize<List<Estadopago>>(contenido, opciones);


                foreach (var item in listado)
                {

                    ListEstadopago.Add(item);


                }

            }
        }
        INavigation navigation;

        string url = "https://desfrlopez.me/crivera/api/estado/";

        ObservableCollection<Estadopago> listEstadopago = new ObservableCollection<Estadopago>();

        public ObservableCollection<Estadopago> ListEstadopago
        {
            get => listEstadopago;
            set
            {

                listEstadopago = value;
                var args = new PropertyChangedEventArgs(nameof(ListEstadopago));
                PropertyChanged?.Invoke(this, args);

            }


        }

        string descripcion;
        public string Descripcion
        {
            get => descripcion;
            set
            {

                descripcion = value;
                var args = new PropertyChangedEventArgs(nameof(Descripcion));
                PropertyChanged?.Invoke(this, args);

            }
        }
        int id_estado;

        public int Id_estado
        {
            get => id_estado;
            set
            {

                id_estado = value;
                var args = new PropertyChangedEventArgs(nameof(Id_estado));
                PropertyChanged?.Invoke(this, args);

            }
        }

        public Command registroEstadopago { get; set; }
        public Command actualizarEstadopago { get; set; }
        public Command eliminarEstadopago { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
