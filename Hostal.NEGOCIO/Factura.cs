using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostal.NEGOCIO
{
    public class Factura
    {
        private int _id, _total;
        private string _idEmpresa;
        private DateTime _fechaFacturacion;

        public string NomEmpresa
        {
            get
            {
                DALC.EMPRESA EMPRESA = CommonBC.Modelo.EMPRESA.FirstOrDefault(e => e.RUT == this.IdEmpresa);

                return Auxiliar.UppercaseWords(EMPRESA.RAZON_SOCIAL);
            }

        }

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

        public string IdEmpresa
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
            this._idEmpresa = string.Empty;
            this._total = 0;
            this._fechaFacturacion = DateTime.Today;
        }

        public int getPrecioById(int id)
        {
            DALC.SERVICIO serv = CommonBC.Modelo.SERVICIO.FirstOrDefault(r => r.ID == id);

            return (int)serv.PRECIO;
        }

        public int getPrecioHabById(int id)
        {
            DALC.HABITACION serv = CommonBC.Modelo.HABITACION.FirstOrDefault(r => r.NUMERO == id);

            return (int)serv.PRECIO;
        }
        

        public int getFacturaMaxId()
        {
            try
            {
                int user = (int)CommonBC.Modelo.FACTURA.Max(us => us.ID);
                return user;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public bool AgregarFactura()
        {
            DALC.FACTURA factura = new DALC.FACTURA();

            try
            {
                factura.ID = getFacturaMaxId() + 1;
                factura.ID_EMPRESA = this.IdEmpresa;
                factura.TOTAL = this.Total;
                factura.FECHA_FACTURACION = this.FechaFacturacion;

                CommonBC.Modelo.FACTURA.Add(factura);
                CommonBC.Modelo.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                CommonBC.Modelo.FACTURA.Remove(factura);
                Logger.Log("Factura.cs");
                Logger.Log(ex.Message);
                if (ex.InnerException != null)
                {
                    Logger.Log(ex.InnerException.ToString());
                }
                return false;
            }
        }

        public Factura GetFactura()
        {
            DALC.FACTURA factura = new DALC.FACTURA();

            try
            {
               factura = CommonBC.Modelo.FACTURA.FirstOrDefault(r => this.Id == r.ID);

                if (factura != null)
                {
                    Factura fac = new Factura();

                    fac.Id = (int)factura.ID;
                    fac.IdEmpresa = factura.ID_EMPRESA;
                    fac.Total = (int)factura.TOTAL;
                    fac._fechaFacturacion = (DateTime)factura.FECHA_FACTURACION;

                    return fac;
                }else
                {
                    return null;
                }
                
            }
            catch (Exception ex)
            {
                Logger.Log("Factura.cs");
                Logger.Log(ex.Message);
                if (ex.InnerException != null)
                {
                    Logger.Log(ex.InnerException.ToString());
                }
                return null;
            }
        }

        public bool ActualizarFactura()
        {
            DALC.FACTURA factura = new DALC.FACTURA();

            try
            {
                factura = CommonBC.Modelo.FACTURA.FirstOrDefault(r => this.Id == r.ID);

                factura.ID_EMPRESA = this.IdEmpresa;
                factura.TOTAL = this.Total;
                factura.FECHA_FACTURACION = this.FechaFacturacion;

                CommonBC.Modelo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log("Factura.cs");
                Logger.Log(ex.Message);
                if (ex.InnerException != null)
                {
                    Logger.Log(ex.InnerException.ToString());
                }
                return false;
            }
        }

        public bool BorrarFactura()
        {
            DALC.FACTURA factura = new DALC.FACTURA();

            try
            {
                factura = CommonBC.Modelo.FACTURA.FirstOrDefault(r => this.Id == r.ID);

                CommonBC.Modelo.FACTURA.Remove(factura);
                CommonBC.Modelo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log("Factura.cs");
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
