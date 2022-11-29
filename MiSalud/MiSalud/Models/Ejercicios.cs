using System;
using System.Collections.Generic;
using System.Text;

namespace MiSalud.Models
{
    [Serializable]
    public class Ejercicios
    {
        public string nombre_actividad { get; set; }
        public double tiempo { get; set; }
        public double calorias_quemadas { get; set; }
        public DateTime fecha { get; set; }

    }
}
