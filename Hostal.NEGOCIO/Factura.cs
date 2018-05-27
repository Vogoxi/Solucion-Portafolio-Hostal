﻿using System;
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

        public bool AgregarFactura()
        {
            DALC.FACTURA factura = new DALC.FACTURA();

            try
            {
                //SE ASUME QUE ACA EL ID SE GENERA EN BASE DE DATOS CON UN TRIGGER.
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
