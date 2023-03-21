using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;
using ProyectoIS.Models;
using Xamarin.Forms;

namespace ProyectoIS.ViewModels
{
    class ViewModelRegistrese : INotifyPropertyChanged
    {
        public ViewModelRegistrese()
        {

            registroUsuario = new Command(async () =>
            {
                using (var httpClient = new HttpClient())
                {
                    Registrarse body1 = new Registrarse()
                    {
                        nombre = this.nombre,
                        apellido = this.apellido,
                        id_sucursal = this.id_sucursal,
                        user = this.user,
                        pass = this.pass,
                        active = 1,
                        rol = 2

                    };
                    var myContent = JsonConvert.SerializeObject(body1);
                    var stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");

                    var respuesta = await httpClient.PostAsync(url, stringContent);

                    if (respuesta.IsSuccessStatusCode)
                    {
                        await Application.Current.MainPage.Navigation.PushAsync(new MainPage());
                    }
                }
            }
            );
        }
        INavigation navigation;

        string url = "https://desfrlopez.me/crivera/api/empleado/";

        

        string nombre;
        public string Nombre
        {
            get => nombre;
            set 
            {

                nombre = value;
                var args = new PropertyChangedEventArgs(nameof(Nombre));
                PropertyChanged?.Invoke(this, args);

            }
        }

        string apellido;
        public string Apellido
        {
            get => apellido;
            set
            {

                apellido = value;
                var args = new PropertyChangedEventArgs(nameof(Apellido));
                PropertyChanged?.Invoke(this, args);

            }
        }

        int id_sucursal;
        public int Sucursal
        {
            get => id_sucursal;
            set
            {

                id_sucursal = value;
                var args = new PropertyChangedEventArgs(nameof(Sucursal));
                PropertyChanged?.Invoke(this, args);

            }
        }
        string user;
        public string User
        {
            get => user;
            set
            {

                user = value;
                var args = new PropertyChangedEventArgs(nameof(User));
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


        public Command registroUsuario { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    
}
}
