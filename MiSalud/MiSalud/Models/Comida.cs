using System;
using System.Collections.Generic;
using System.Text;

namespace MiSalud.Models
{

    [Serializable]
    public class Comida
    {

        public string nombre_plato { get; set; }
        public double calorias { get; set; }
        public DateTime fecha { get; set; }

    }
}
