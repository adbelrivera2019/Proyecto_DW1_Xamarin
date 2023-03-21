using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIS.Models
{
        public class Sucursal
        {
            public int id_sucursal { get; set; }
            public string ciudad { get; set; }
        public string departamento { get; set; }
        public int telefono { get; set; }

        public string toJson()
            {

                return "{ \"id_sucursal\": \"" + id_sucursal + "\"ciudad\": \"" + ciudad + "\"departamento\": \""+departamento+"\"telefono\":\""+telefono+"}";

            }
        }
    }
