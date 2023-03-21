using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;



namespace ProyectoIS.Models
{
    internal class ciudades
    {
        [JsonProperty("ciudad")]
        public string ciudad { get; set; }
    }
}
