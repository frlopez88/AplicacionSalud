using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MiSalud.Models
{
    [Serializable]
    public class Persona
    {

        public string nombre { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public string genero { get; set; }
        public double altura { get; set; }
        public double peso_lbs { get; set; }
        public ObservableCollection<Ejercicios> lista_ejercicios { get; set; } = new ObservableCollection<Ejercicios>();
        public ObservableCollection<Comida> lista_comidas { get; set; } = new ObservableCollection<Comida>();

    }
}
