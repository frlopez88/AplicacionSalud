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
    public class ViewModelEjercicio : INotifyPropertyChanged
    {

        public ViewModelEjercicio() {

            AbrirArchivo();


            GuardarEjercicio = new Command( ()=> {

                double tiempoAct = CalcularTiempo(this.horaInicio, this.horaFin);

                Ejercicios e = new Ejercicios()
                {
                    nombre_actividad = this.actvidad,
                    fecha = this.fechaActividad,
                    tiempo = tiempoAct,
                    calorias_quemadas = 0
                };

                e.CalcularCalorias();

                p.lista_ejercicios.Add(e);

                //Rutina de Serializacion para guardar el ejercicio de la persona
                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                    "info.aut");
                Stream archivo = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(archivo, p);
                archivo.Close();

                Resultado = "";

                foreach (Ejercicios x in p.lista_ejercicios)
                {

                    Resultado += x.toString();

                }

            } );


        }

        private double CalcularTiempo(TimeSpan x_f_ini, TimeSpan x_f_fin) {

            //DateTime t1 = Convert.ToDateTime(x_f_ini);
            //DateTime t2 = Convert.ToDateTime(x_f_fin);
            double horas = x_f_fin.Subtract(x_f_ini).TotalMinutes;
            return horas;
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

                foreach (Ejercicios x in p.lista_ejercicios) {

                    Resultado += x.toString();
                    
                }
                
            }
            catch (Exception e)
            {


            }



        }

        Persona p = new Persona();

        string actvidad;

        public string Actividad
        {
            get => actvidad;
            set
            {
                actvidad = value;
                var arg = new PropertyChangedEventArgs(nameof(Actividad));
                PropertyChanged?.Invoke(this, arg);

            }
        }

        DateTime fechaActividad = DateTime.Today;

        public DateTime FechaActividad
        {
            get => fechaActividad;
            set
            {
                fechaActividad = value;
                var arg = new PropertyChangedEventArgs(nameof(FechaActividad));
                PropertyChanged?.Invoke(this, arg);

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

        TimeSpan horaInicio;

        public TimeSpan HoraInicio {
            get => horaInicio;
            set {

                horaInicio = value;
                var arg = new PropertyChangedEventArgs(nameof(HoraInicio));
                PropertyChanged?.Invoke(this, arg);

            }
        }

        TimeSpan horaFin;

        public TimeSpan HoraFin
        {
            get => horaFin;
            set
            {

                horaFin = value;
                var arg = new PropertyChangedEventArgs(nameof(HoraFin));
                PropertyChanged?.Invoke(this, arg);

            }
        }

        string resultado;

        public string Resultado
        {
            get => resultado;
            set
            {

                resultado = value;
                var arg = new PropertyChangedEventArgs(nameof(Resultado));
                PropertyChanged?.Invoke(this, arg);

            }
        }


        public Command GuardarEjercicio { get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
