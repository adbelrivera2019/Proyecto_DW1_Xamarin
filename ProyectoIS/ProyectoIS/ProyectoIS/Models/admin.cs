using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIS.Models
{
    public class admin
    {
        public string rnombre { get; set; }
        public string rapellido { get; set; }
        public int id_sucursal { get; set; }
        public string user { get; set; }
        public string pass { get; set; }
        public int active { get; set; }
        public int rol { get; set; }

        public string toJson()
        {

            return "{ \"nombre\": \"" + rnombre + "\" , \"apellido\": \"" + rapellido + "\", \"ciudad\": \" " + id_sucursal + "\"  }";

        }
    }
}
