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

        public string toString() { 
            
            return fecha.ToString("MM-dd-yyyy")  + " - " + nombre_actividad + " - tiempo " + tiempo + " - calorias " + calorias_quemadas + " \t\n ";
        }

        public void CalcularCalorias() {

            switch (nombre_actividad) {

                case "Boxeo":
                    calorias_quemadas = 600 * (tiempo/60.00);
                    break;
                case "Correr":
                    calorias_quemadas = 500 * (tiempo / 60.00);
                    break;
                case "Caminar":
                    calorias_quemadas = 350 * (tiempo / 60.00);
                    break;
                case "Taekwondoe":
                    calorias_quemadas = 550 * (tiempo / 60.00);
                    break;
                case "Nadar":
                    calorias_quemadas = 800 * (tiempo / 60.00);
                    break;
                default:
                    break;


            }
            
        }

    }
}
