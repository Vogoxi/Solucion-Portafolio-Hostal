using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostal.NEGOCIO
{
    public class Habitacion
    {
        private int _numero, _camas, _precio, _mantencion;
        private string _tipo;

        public Habitacion()
        {
            this.Init();
        }

        public int Camas
        {
            get
            {
                return _camas;
            }

            set
            {
                _camas = value;
            }
        }

        public int Mantencion
        {
            get
            {
                return _mantencion;
            }

            set
            {
                _mantencion = value;
            }
        }

        public int Numero
        {
            get
            {
                return _numero;
            }

            set
            {
                _numero = value;
            }
        }

        public int Precio
        {
            get
            {
                return _precio;
            }

            set
            {
                _precio = value;
            }
        }

        public string Tipo
        {
            get
            {
                return _tipo;
            }

            set
            {
                _tipo = value;
            }
        }

        private void Init()
        {
            Numero = 0;
            Camas = 0;
            Precio = 0;
            Mantencion = 0;
            Tipo = string.Empty;
        }

        
        public bool AgregarHabitacion()
        {
            DALC.HABITACION habit = new DALC.HABITACION();

            try
            {
                habit = CommonBC.Modelo.HABITACION.FirstOrDefault(r => r.NUMERO == this.Numero);

                if (habit == null)
                {
                    habit.NUMERO = this.Numero;
                    habit.PRECIO = this.Precio;
                    habit.CAMAS = this.Camas;
                    habit.MANTENCION = this.Mantencion;
                    habit.TIPO = this.Tipo;

                    CommonBC.Modelo.HABITACION.Add(habit);
                    CommonBC.Modelo.SaveChanges();
                    return true;
                }else
                {
                    return false;
                }

               
            }
            catch (Exception ex)
            {
                CommonBC.Modelo.HABITACION.Remove(habit);
                Logger.Log("Habitacion.cs");
                Logger.Log(ex.Message);
                if (ex.InnerException != null)
                {
                    Logger.Log(ex.InnerException.ToString());
                }
                return false;
            }
        }

        public Habitacion GetHabitacion()
        {
            DALC.HABITACION habit = new DALC.HABITACION();
            try
            {
                habit = CommonBC.Modelo.HABITACION.FirstOrDefault(r => r.NUMERO == this.Numero);

                Habitacion hab = new Habitacion();

                hab.Numero = (int)habit.NUMERO;
                hab.Precio = (int)habit.PRECIO;
                hab.Camas = (int)habit.CAMAS;
                hab.Mantencion = (int)habit.MANTENCION;
                hab.Tipo = habit.TIPO;

                return hab;

            }
            catch (Exception ex)
            {
                Logger.Log("Habitacion.cs");
                Logger.Log(ex.Message);
                if (ex.InnerException != null)
                {
                    Logger.Log(ex.InnerException.ToString());
                }
                return null;
            }
        }

        public bool ActualizarHabitacion()
        {
            DALC.HABITACION habit = new DALC.HABITACION();
            try
            {
                habit = CommonBC.Modelo.HABITACION.FirstOrDefault(r => r.NUMERO == this.Numero);

                habit.NUMERO = this.Numero;
                habit.PRECIO = this.Precio;
                habit.NUMERO = this.Numero;
                habit.MANTENCION = this.Mantencion;
                habit.TIPO = this.Tipo;

                CommonBC.Modelo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log("Habitacion.cs");
                Logger.Log(ex.Message);
                if (ex.InnerException != null)
                {
                    Logger.Log(ex.InnerException.ToString());
                }
                return false;
            }
        }

        public bool BorrarHabitacion()
        {
            DALC.HABITACION habit = new DALC.HABITACION();
            try
            {
                habit = CommonBC.Modelo.HABITACION.FirstOrDefault(r => r.NUMERO== this.Numero);

                CommonBC.Modelo.HABITACION.Remove(habit);
                CommonBC.Modelo.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Logger.Log("Habitacion.cs");
                Logger.Log(ex.Message);
                if (ex.InnerException != null)
                {
                    Logger.Log(ex.InnerException.ToString());
                }
                return false;
            }
        }


    }
}
