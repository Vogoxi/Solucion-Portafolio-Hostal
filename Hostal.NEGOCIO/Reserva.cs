using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostal.NEGOCIO
{
    public class Reserva
    {
        private int _numero;
        private int _servicio;
        private string _rut;
        private DateTime _fechaInicio,_fechaTermino;

        public Reserva()
        {
            this.Servicio = 0;
            this._numero = 0;
            this._rut = "";
            this.FechaInicio = DateTime.Today;
            this.FechaTermino = DateTime.Today;
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

        public string Rut
        {
            get
            {
                return _rut;
            }

            set
            {
                _rut = value;
            }
        }

        public DateTime FechaInicio
        {
            get
            {
                return _fechaInicio;
            }

            set
            {
                _fechaInicio = value;
            }
        }

        public DateTime FechaTermino
        {
            get
            {
                return _fechaTermino;
            }

            set
            {
                _fechaTermino = value;
            }
        }

        public int Servicio
        {
            get
            {
                return _servicio;
            }

            set
            {
                _servicio = value;
            }
        }
    }
}
