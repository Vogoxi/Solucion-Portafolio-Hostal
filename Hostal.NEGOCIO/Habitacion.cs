using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostal.NEGOCIO
{
    public class Habitacion
    {

        private int _numero, _precio, _camas, _disponible;
        private string _tipo;

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

        public int Disponible
        {
            get
            {
                return _disponible;
            }

            set
            {
                _disponible = value;
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

        public Habitacion()
        {
            this.Init();
        }

        private void Init()
        {
            _numero = 0;
            _camas = 0;
            _precio = 0;
            _disponible = 0;
            _tipo = string.Empty;
        }


        public Habitacion getHabitacion()
        {
            try
            {
                Hostal.DALC.HABITACION habitacion = CommonBC.Modelo.HABITACION.FirstOrDefault(us => us.NUMERO == this.Numero);

                Habitacion hab = new Habitacion();
                hab.Numero = (int)habitacion.NUMERO;
                hab.Precio = (int)habitacion.PRECIO;
                hab.Camas = (int)habitacion.CAMAS;
                hab.Disponible = (int)habitacion.DISPONIBLE;
                hab.Tipo = habitacion.TIPO;

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

        public bool agregarHabitacion()
        {
            try
            {
                DALC.HABITACION hab = new DALC.HABITACION();
                hab.NUMERO = this.Numero;
                hab.PRECIO = this.Precio;
                hab.TIPO = this.Tipo;
                hab.DISPONIBLE = (short)this.Disponible;
                hab.CAMAS = this.Camas;

                CommonBC.Modelo.HABITACION.Add(hab);
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

        public bool actualizarHabitacion()
        {
            try
            {
                DALC.HABITACION habitacion = CommonBC.Modelo.HABITACION.FirstOrDefault(r => r.NUMERO == this.Numero);

                this.Numero = (int)habitacion.NUMERO;
                this.Precio = (int)habitacion.PRECIO;
                this.Camas = (int)habitacion.CAMAS;
                this.Disponible = (int)habitacion.DISPONIBLE;
                this.Tipo = habitacion.TIPO;
                
                CommonBC.Modelo.HABITACION.First
            }
            catch (Exception)
            {

                throw;
            }
        }



    }
}
