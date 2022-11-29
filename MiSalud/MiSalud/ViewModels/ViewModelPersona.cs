using MiSalud.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Xamarin.Forms;

namespace MiSalud.ViewModels
{
    public class ViewModelPersona : INotifyPropertyChanged
    {
        public ViewModelPersona() {

            CrearPersona = new Command( ()=> {

                Persona p = new Persona() { 
                
                    nombre = this.nombre, 
                    fecha_nacimiento = this.fecha_nacimiento, 
                    genero = this.genero, 
                    peso_lbs = this.peso, 
                    altura = this.altura
                        
                };

                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(
                    System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal)  ,
                    "persona.aut");

                Stream archivo = new FileStream( ruta, FileMode.Create, FileAccess.Write, FileShare.None  )  ;
                formatter.Serialize(archivo, p);
                archivo.Close();
            
            } );
        
        
        }
        
        
        string nombre;

        public string Nombre {
            get => nombre;
            set {
                nombre = value;
                var arg = new PropertyChangedEventArgs(nameof(Nombre));
                PropertyChanged?.Invoke(this, arg);
            
            }
        }

        DateTime fecha_nacimiento;

        public DateTime Fecha_Nacimiento
        {
            get => fecha_nacimiento;
            set
            {
                fecha_nacimiento = value;
                var arg = new PropertyChangedEventArgs(nameof(Fecha_Nacimiento));
                PropertyChanged?.Invoke(this, arg);

            }
        }

        string genero;

        public string Genero
        {
            get => genero;
            set
            {
                genero = value;
                var arg = new PropertyChangedEventArgs(nameof(Genero));
                PropertyChanged?.Invoke(this, arg);

            }
        }

        double peso;

        public double Peso
        {
            get => peso;
            set
            {
                peso = value;
                var arg = new PropertyChangedEventArgs(nameof(Peso));
                PropertyChanged?.Invoke(this, arg);

            }
        }

        double altura;

        public double Altura
        {
            get => altura;
            set
            {
                altura = value;
                var arg = new PropertyChangedEventArgs(nameof(Altura));
                PropertyChanged?.Invoke(this, arg);

            }
        }


        public Command CrearPersona { get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
