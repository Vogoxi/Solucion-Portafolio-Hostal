using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostal.NEGOCIO
{
    public class Factura
    {
        private int _id, _idEmpresa, _total;
        private DateTime _fechaFacturacion;

        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public int IdEmpresa
        {
            get
            {
                return _idEmpresa;
            }

            set
            {
                _idEmpresa = value;
            }
        }

        public int Total
        {
            get
            {
                return _total;
            }

            set
            {
                _total = value;
            }
        }

        public DateTime FechaFacturacion
        {
            get
            {
                return _fechaFacturacion;
            }

            set
            {
                _fechaFacturacion = value;
            }
        }

        public Factura()
        {
            Init();
        }

        private void Init()
        {
            this._id = 0;
            this._idEmpresa = 0;
            this._total = 0;
            this._fechaFacturacion = DateTime.Today;
        }
    }
}
