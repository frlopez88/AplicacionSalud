using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using MiSalud.Models;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace MiSalud.ViewModels
{
    public class ViewModelComida : INotifyPropertyChanged
    {

        public ViewModelComida() {

            AbrirArchivo();


            CrearComida = new Command( ()=> {

                Comida c1 = new Comida()
                {
                    nombre_plato = this.plato, 
                    fecha = this.fechaComida

                };

                c1.CalculoCalorias();
                p.lista_comidas.Add(c1);

                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                    "info.aut");
                Stream archivo = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(archivo, p);
                archivo.Close();

                Resultado = "";

                foreach (Comida c in p.lista_comidas) {

                    Resultado += c.toString();

                }


            } );

        
        }

        private void AbrirArchivo()
        {

            // Es una estructura 

            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                    "info.aut");
                Stream archivo = new FileStream(ruta, FileMode.Open, FileAccess.Read, FileShare.None);

                p = (Persona)formatter.Deserialize(archivo);
                archivo.Close();

                Resultado = "";

                foreach (Comida x in p.lista_comidas)
                {

                    Resultado += x.toString();

                }


            }
            catch (Exception e)
            {


            }



        }


        string resultado;

        public string Resultado
        {

            get => resultado;
            set
            {

                resultado = value;
                var args = new PropertyChangedEventArgs(nameof(Resultado));
                PropertyChanged?.Invoke(this, args);

            }

        }

        Persona p = new Persona();

        string plato;

        public string Plato {

            get => plato;
            set {

                plato = value;
                var args = new PropertyChangedEventArgs(nameof(Plato));
                PropertyChanged?.Invoke(this, args);

            }

        }


        DateTime fechaComida = DateTime.Today;

        public DateTime FechaComida
        {

            get => fechaComida;
            set
            {

                fechaComida = value;
                var args = new PropertyChangedEventArgs(nameof(FechaComida));
                PropertyChanged?.Invoke(this, args);

            }

        }

        DateTime fechaMin = DateTime.Today;

        public DateTime FechaMin
        {
            get => fechaMin;
            set
            {

                fechaMin = value;
                var arg = new PropertyChangedEventArgs(nameof(FechaMin));
                PropertyChanged?.Invoke(this, arg);

            }
        }

        public Command CrearComida { get; }



        public event PropertyChangedEventHandler PropertyChanged;
    }
}
