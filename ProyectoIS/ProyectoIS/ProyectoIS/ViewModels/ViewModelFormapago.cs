using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;
using ProyectoIS.Models;
using ProyectoIS.Views;
using Xamarin.Forms;

namespace ProyectoIS.ViewModels
{
    public class ViewModelFormapago
    {
        public ViewModelFormapago()
        {
            getFormapago();
            registroFormapago = new Command(async () =>
            {
                using (var httpClient = new HttpClient())
                {
                    Formapago body2 = new Formapago()
                    {
                        id_formapago = this.id_formapago,
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
            actualizarFormapago = new Command(async () =>
            {
                using (var httpClient = new HttpClient())
                {
                    Formapago body2 = new Formapago()
                    {

                        descripcion = this.descripcion


                    };
                    var myContent = JsonConvert.SerializeObject(body2);
                    var stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");

                    var respuesta = await httpClient.PutAsync(url+Id_formapago, stringContent);
                    
                    if (respuesta.IsSuccessStatusCode)
                    {
                        await Application.Current.MainPage.Navigation.PushAsync(new ViewAdmin());
                    }
                }
            }
            );
            eliminarFormapago = new Command(async () =>
            {
                using (var httpClient = new HttpClient())
                {
                    Formapago body2 = new Formapago()
                    {

                        descripcion = this.descripcion


                    };
                    var myContent = JsonConvert.SerializeObject(body2);
                    var stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");

                    var respuesta = await httpClient.DeleteAsync(url + Id_formapago);

                    if (respuesta.IsSuccessStatusCode)
                    {
                        await Application.Current.MainPage.Navigation.PushAsync(new ViewAdmin());
                    }
                }
            }
            );
        }

        private async void getFormapago()
        {

            ListFormapago = new ObservableCollection<Formapago>();

            HttpClient httpClient = new HttpClient();

            var respuesta = await httpClient.GetAsync(url);

            if (respuesta.IsSuccessStatusCode)
            {

                var contenido = await respuesta.Content.ReadAsStringAsync();
                JsonSerializerOptions opciones = new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                };
                var listado = System.Text.Json.JsonSerializer.Deserialize<List<Formapago>>(contenido, opciones);


                foreach (var item in listado)
                {

                    ListFormapago.Add(item);


                }

            }
        }
        INavigation navigation;

        string url = "https://desfrlopez.me/crivera/api/formapago/";

        ObservableCollection<Formapago> listFormapago = new ObservableCollection<Formapago>();

        public ObservableCollection<Formapago> ListFormapago
        {
            get => listFormapago;
            set
            {

                listFormapago = value;
                var args = new PropertyChangedEventArgs(nameof(ListFormapago));
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
        int id_formapago;
        
        public int Id_formapago
        {
            get => id_formapago;
            set
            {

                id_formapago = value;
                var args = new PropertyChangedEventArgs(nameof(Id_formapago));
                PropertyChanged?.Invoke(this, args);
                
            }
        }
        
        public Command registroFormapago { get; set; }
        public Command actualizarFormapago { get; set; }
        public Command eliminarFormapago { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
