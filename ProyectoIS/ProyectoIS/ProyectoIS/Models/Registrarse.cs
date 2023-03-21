using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIS.Models
{
    public class Registrarse
    {
        public string nombre { set; get; }
        public string apellido { get; set; }
        public int id_sucursal { get; set; }
        public string user { get; set; }
        public string pass { get; set; }
        public int active { get; set; }
        public int rol { get; set; }

        public string toJson()
        {

            return "{ \"nombre\": \"" + nombre + "\" , \"apellido\": \"" + apellido + "\", \"ciudad\": \" " + id_sucursal + "\"\"user\": \"" + user + "\" , \"pass\": \"" + pass + "\", \"active\": \" " + active + " }";

        }
    }
}
