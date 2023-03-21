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
    class ViewModelProducto
    {
        public ViewModelProducto()
        {
            getProducto();
            registroProducto = new Command(async () =>
            {
                using (var httpClient = new HttpClient())
                {
                    Producto body2 = new Producto()
                    {
                        id_producto = this.id_producto,
                        nombre = this.nombre,
                        proveedor = this.proveedor,
                        descripcion = this.descripcion,
                        cantidad_bodega = this.cantidad_bodega,
                        precio = this.precio


                    };
                    var myContent = JsonConvert.SerializeObject(body2);
                    var stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");

                    var respuesta = await httpClient.PostAsync(url, stringContent);

                    if (respuesta.IsSuccessStatusCode)
                    {
                        await Application.Current.MainPage.Navigation.PushAsync(new ViewProducto());
                    }
                }
            }
            );
            actualizarProducto = new Command(async () =>
            {
                using (var httpClient = new HttpClient())
                {
                    Producto body2 = new Producto()
                    {

                        nombre = this.nombre,
                        proveedor = this.proveedor,
                        descripcion = this.descripcion,
                        cantidad_bodega = this.cantidad_bodega,
                        precio = this.precio


                    };
                    var myContent = JsonConvert.SerializeObject(body2);
                    var stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");

                    var respuesta = await httpClient.PutAsync(url + Id_producto, stringContent);

                    if (respuesta.IsSuccessStatusCode)
                    {
                        await Application.Current.MainPage.Navigation.PushAsync(new ViewProducto());
                    }
                }
            }
            );
            eliminarProducto = new Command(async () =>
            {
                using (var httpClient = new HttpClient())
                {
                    Producto body2 = new Producto()
                    {

                        nombre = this.nombre,
                        proveedor = this.proveedor,
                        descripcion = this.descripcion,
                        cantidad_bodega = this.cantidad_bodega,
                        precio = this.precio


                    };
                    var myContent = JsonConvert.SerializeObject(body2);
                    var stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");

                    var respuesta = await httpClient.DeleteAsync(url + Id_producto);

                    if (respuesta.IsSuccessStatusCode)
                    {
                        await Application.Current.MainPage.Navigation.PushAsync(new ViewProducto());
                    }
                }
            }
            );
        }

        private async void getProducto()
        {

            ListProducto = new ObservableCollection<Producto>();

            HttpClient httpClient = new HttpClient();

            var respuesta = await httpClient.GetAsync(url);

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

        string url = "https://desfrlopez.me/crivera/api/producto/";

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
        int id_producto;

        public int Id_producto
        {
            get => id_producto;
            set
            {

                id_producto = value;
                var args = new PropertyChangedEventArgs(nameof(Id_producto));
                PropertyChanged?.Invoke(this, args);

            }
        }
        int cantidad_bodega;
        public int Cantidad_bodega
        {
            get => cantidad_bodega;
            set
            {

                cantidad_bodega = value;
                var args = new PropertyChangedEventArgs(nameof(Cantidad_bodega));
                PropertyChanged?.Invoke(this, args);

            }
        }
        string proveedor;
        public string Proveedor
        {
            get => proveedor;
            set
            {

                proveedor = value;
                var args = new PropertyChangedEventArgs(nameof(Proveedor));
                PropertyChanged?.Invoke(this, args);

            }
        }
        int precio;
        public int Precio
        {
            get => precio;
            set
            {

                precio = value;
                var args = new PropertyChangedEventArgs(nameof(Precio));
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
        public Command registroProducto { get; set; }
        public Command actualizarProducto { get; set; }
        public Command eliminarProducto { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}

