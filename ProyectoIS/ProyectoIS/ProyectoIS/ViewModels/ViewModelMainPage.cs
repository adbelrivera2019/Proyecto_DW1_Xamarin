using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Xamarin.Forms;
using ProyectoIS.Models;
using ProyectoIS.Views;


namespace ProyectoIS.ViewModels
{
    public class ViewModelMainPage : INotifyPropertyChanged
    {
        public ViewModelMainPage()
        {
            registrese = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new ViewRegistrese());
            });
            inicioSesion = new Command(async () =>
            {


                HttpClient empleado = new HttpClient();


                var respuesta = await empleado.GetAsync(url + "/" + this.user + "/" + this.pass);

                if (respuesta.IsSuccessStatusCode)
                {

                    var contenido = await respuesta.Content.ReadAsStringAsync();



                    var inicioSesion = System.Text.Json.JsonSerializer.Deserialize<List<logIn>>(contenido);


                    if (inicioSesion[0].is_valid == 1 && inicioSesion[0].rol == 2)
                    {

                        await Application.Current.MainPage.Navigation.PushAsync(new ViewInicio());
                        
                    }
                    if (inicioSesion[0].is_valid == 1 && inicioSesion[0].rol == 1)
                    {

                        await Application.Current.MainPage.Navigation.PushAsync(new ViewAdmin());

                    }
                    else
                    {

                        Resultado = "Inicio de Sesión Erroneo";
                    }

                }

            });

        }


            INavigation navigation;

            string url = "https://desfrlopez.me/crivera/api/login";

            string user;
        public string Usuario
        {
            get => user;
            set
            {
                user = value;
                var args = new PropertyChangedEventArgs(nameof(Usuario));
                PropertyChanged?.Invoke(this, args);

            }
        }

        string pass;
        public string Pass
        {
            get => pass;
            set
            {
                pass = value;
                var args = new PropertyChangedEventArgs(nameof(Pass));
                PropertyChanged?.Invoke(this, args);

            }
        }

        string resultado;
        public string Resultado
        {
            get => resultado;
            set
            {
                resultado = value;
                var args = new PropertyChangedEventArgs(nameof(Resultado));
                PropertyChanged?.Invoke(this, args);

            }
        }

        public Command inicioSesion { get; }
        public Command registrese { get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
