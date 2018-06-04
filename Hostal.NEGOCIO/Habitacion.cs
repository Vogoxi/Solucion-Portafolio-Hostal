using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostal.NEGOCIO
{
    public class Habitacion
    {
        private int _numero, _precio, _mantencion;
        private string _tipo, _tipoCama;

        public Habitacion()
        {
            this.Init();
        }

        public string TipoCama
        {
            get
            {
                return _tipoCama;
            }

            set
            {
                _tipoCama = value;
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
            _tipoCama = string.Empty;
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
                    habit.TIPO_CAMA = this._tipoCama;
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

                if (habit != null)
                {
                    Habitacion hab = new Habitacion();

                    hab.Numero = (int)habit.NUMERO;
                    hab.Precio = (int)habit.PRECIO;
                    hab.TipoCama = habit.TIPO_CAMA;
                    hab.Mantencion = (int)habit.MANTENCION;
                    hab.Tipo = habit.TIPO;

                    return hab;
                }else
                {
                    return null;
                }
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
                habit.TIPO_CAMA = this.TipoCama;
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
