using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostal.NEGOCIO
{
    public class DetalleFactura
    {
        private int _id, _idFactura, _idHabitacion, _idServicio;
        private DateTime _fechaIngreso, _fechaSalida;
        private string _idHuesped;

        public DetalleFactura()
        {
            Init();
        }

        private void Init()
        {
            Id1 = 0;
            IdFactura1 = 0;
            IdHabitacion1 = 0;
            IdServicio = 0;
            _fechaIngreso = DateTime.Today;
            _fechaSalida = DateTime.Today;
            _idHuesped = string.Empty;
        }

        public int Id
        {
            get
            {
                return Id1;
            }

            set
            {
                Id1 = value;
            }
        }

        public int IdFactura
        {
            get
            {
                return IdFactura1;
            }

            set
            {
                IdFactura1 = value;
            }
        }

        public int IdHabitacion
        {
            get
            {
                return IdHabitacion1;
            }

            set
            {
                IdHabitacion1 = value;
            }
        }

        public DateTime FechaIngreso
        {
            get
            {
                return _fechaIngreso;
            }

            set
            {
                _fechaIngreso = value;
            }
        }

        public DateTime FechaSalida
        {
            get
            {
                return _fechaSalida;
            }

            set
            {
                _fechaSalida = value;
            }
        }

        public string IdHuesped
        {
            get
            {
                return _idHuesped;
            }

            set
            {
                _idHuesped = value;
            }
        }

        public int Id1
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

        public int IdFactura1
        {
            get
            {
                return _idFactura;
            }

            set
            {
                _idFactura = value;
            }
        }

        public int IdHabitacion1
        {
            get
            {
                return _idHabitacion;
            }

            set
            {
                _idHabitacion = value;
            }
        }

        public int IdServicio
        {
            get
            {
                return _idServicio;
            }

            set
            {
                _idServicio = value;
            }
        }

        public bool AgregarDetalleFactura()
        {
            DALC.DETALLE_FACTURA detFactura = new DALC.DETALLE_FACTURA();

            try
            {
                //SE ASUME QUE ACA EL ID SE GENERA EN BASE DE DATOS CON UN TRIGGER.
                detFactura.FACTURA_ID = this.IdFactura;
                detFactura.HABITACION_ID = this.IdHabitacion;
                detFactura.HUESPED_ID = this.IdHuesped;
                detFactura.SERVICIO_ID = this.IdServicio;
                detFactura.FECHA_INGRESO = this.FechaIngreso;
                detFactura.FECHA_SALIDA = this.FechaSalida;


                CommonBC.Modelo.DETALLE_FACTURA.Add(detFactura);
                CommonBC.Modelo.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                CommonBC.Modelo.DETALLE_FACTURA.Remove(detFactura);
                Logger.Log("DetalleFactura.cs");
                Logger.Log(ex.Message);
                if (ex.InnerException != null)
                {
                    Logger.Log(ex.InnerException.ToString());
                }
                return false;
            }
        }

        public DetalleFactura GetDetalleFactura()
        {
            DALC.DETALLE_FACTURA detFactura = new DALC.DETALLE_FACTURA();

            try
            {
                detFactura = CommonBC.Modelo.DETALLE_FACTURA.FirstOrDefault(r => this.Id == r.ID);

                if (detFactura != null)
                {
                    DetalleFactura det = new DetalleFactura();

                    this.Id = (int)detFactura.ID;
                    this.IdFactura = (int)detFactura.FACTURA_ID;
                    this.IdHabitacion = (int)detFactura.HABITACION_ID;
                    this.IdHuesped = detFactura.HUESPED_ID;
                    this.IdServicio = (int)detFactura.SERVICIO_ID;
                    this.FechaIngreso = (DateTime)detFactura.FECHA_INGRESO;
                    this.FechaSalida = (DateTime)detFactura.FECHA_SALIDA;

                    return det;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                Logger.Log("DetalleFactura.cs");
                Logger.Log(ex.Message);
                if (ex.InnerException != null)
                {
                    Logger.Log(ex.InnerException.ToString());
                }
                return null;
            }
        }

        public bool ActualizarDetalleFactura()
        {
            DALC.DETALLE_FACTURA detFactura = new DALC.DETALLE_FACTURA();

            try
            {
                detFactura = CommonBC.Modelo.DETALLE_FACTURA.FirstOrDefault(r => this.Id == r.ID);


                detFactura.FACTURA_ID = this.IdFactura;
                detFactura.HABITACION_ID = this.IdHabitacion;
                detFactura.HUESPED_ID = this.IdHuesped;
                detFactura.SERVICIO_ID = this.IdServicio;
                detFactura.FECHA_INGRESO = this.FechaIngreso;
                detFactura.FECHA_SALIDA = this.FechaSalida;

                CommonBC.Modelo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log("DetalleFactura.cs");
                Logger.Log(ex.Message);
                if (ex.InnerException != null)
                {
                    Logger.Log(ex.InnerException.ToString());
                }
                return false;
            }
        }

        public bool BorrarDetalleFactura()
        {
            DALC.DETALLE_FACTURA detFactura = new DALC.DETALLE_FACTURA();

            try
            {
                detFactura = CommonBC.Modelo.DETALLE_FACTURA.FirstOrDefault(r => this.Id == r.ID);

                CommonBC.Modelo.DETALLE_FACTURA.Remove(detFactura);
                CommonBC.Modelo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log("DetalleFactura.cs");
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
