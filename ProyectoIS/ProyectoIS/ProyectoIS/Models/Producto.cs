using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIS.Models
{

        public class Producto
        {
            public int id_producto { get; set; }
            public string nombre { get; set; }
            public string proveedor { get; set; }
            public string descripcion { get; set; }
            public int cantidad_bodega { get; set; }
            public int precio { get; set; }

        public string toJson()
            {

                return "{ \"id_producto\": \"" + id_producto + "\"nombre\": \"" + nombre + "\"proveedor\": \"" + proveedor + "\"descripcion\":\"" + descripcion + "\"cantidad_bodega\":\"" + cantidad_bodega + "\"precio\":\"" + precio + "}";

            }
        }
}
