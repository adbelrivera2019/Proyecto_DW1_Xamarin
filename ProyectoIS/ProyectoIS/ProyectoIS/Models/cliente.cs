using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIS.Models
{
    public class Cliente
    {


        public int id_cliente { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string ciudad { get; set; }

        public string toJson()
        {

            return "{ \"nombre\": \"" + nombre + "\" , \"apellido\": \"" + apellido + "\", \"ciudad\": \" " + ciudad + "\"  }";

        }

    }
}
