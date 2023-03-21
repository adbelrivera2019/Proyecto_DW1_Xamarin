using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIS.Models
{
    class Estadopago
    {
        public int id_estado { get; set; }
        public string descripcion { get; set; }

        public string toJson()
        {

            return "{ \"id_estado\": \"" + id_estado + "\"descripcion\": \"" + descripcion + "\"}";

        }
    }
}
