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

        public string toString() {

            return fecha.ToString("MM-dd-yyyy") + " - " + nombre_plato + " - calorias: " + calorias + "\n\t";
        }

        public void CalculoCalorias() {


            switch (nombre_plato) {

                case "Pizza":
                    calorias = 700;
                    break;

                case "Hamburgesa":
                    calorias = 800;
                    break;

                case "Ensalada":
                    calorias = 400;
                    break;

                case "Desayuno Tipico":
                    calorias= 500;
                    break;
                case "Licuado":
                    calorias = 200;
                    break;
                case "Mandarina":
                    calorias = 80;
                    break;
                case "Banano":
                    calorias = 110;
                    break;
                default:
                    break;
            
            
            }

        }



    }
}
