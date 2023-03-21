using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using ProyectoIS.Models;
using Xamarin.Forms;

namespace ProyectoIS.ViewModels
{
  
        public class ViewModelInicio : INotifyPropertyChanged
        {

            public ViewModelInicio()
            {
                getClientes();
            getProducto();
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

        private async void getProducto()
        {

            ListProducto = new ObservableCollection<Producto>();

            HttpClient httpClient = new HttpClient();

            var respuesta = await httpClient.GetAsync(urlprod);

            if (respuesta.IsSuccessStatusCode)
            {

                var contenido = await respuesta.Content.ReadAsStringAsync();
                JsonSerializerOptions opciones = new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                };
                var listado = System.Text.Json.JsonSerializer.Deserialize<List<Producto>>(contenido, opciones);


                foreach (var item in listado)
                {

                    ListProducto.Add(item);


                }

            }
        }
        INavigation navigation;

        string urlprod = "https://desfrlopez.me/crivera/api/producto/";
        ObservableCollection<Producto> listProducto = new ObservableCollection<Producto>();

        public ObservableCollection<Producto> ListProducto
        {
            get => listProducto;
            set
            {

                listProducto = value;
                var args = new PropertyChangedEventArgs(nameof(ListProducto));
                PropertyChanged?.Invoke(this, args);

            }


        }


        string url = "https://desfrlopez.me/crivera/api/pedido";

            ObservableCollection<Cliente> listClientes = new ObservableCollection<Cliente>();

            public ObservableCollection<Cliente> ListClientes
        {
                get =>listClientes;
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

            public event PropertyChangedEventHandler PropertyChanged;
        }
    }

