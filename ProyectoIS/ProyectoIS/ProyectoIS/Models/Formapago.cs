using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIS.Models
{
    public class Formapago
    {
        public int id_formapago { get; set; }
        public string descripcion { get; set; }

        public string toJson()
        {

            return "{ \"id_formapago\": \"" + id_formapago + "\"descripcion\": \"" + descripcion + "\"}";

        }
    }
}
