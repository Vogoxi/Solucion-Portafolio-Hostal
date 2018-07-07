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

        public string NomHuesped
        {
            get
            {
                DALC.HUESPED HUESPED = CommonBC.Modelo.HUESPED.FirstOrDefault(e => e.RUT == this.IdHuesped);

                return Auxiliar.UppercaseWords(String.Format("{0} {1}",HUESPED.NOMBRE,HUESPED.APELLIDO));
            }

        }

        public string RutHuesped
        {
            get
            {
                DALC.HUESPED HUESPED = CommonBC.Modelo.HUESPED.FirstOrDefault(e => e.RUT == this.IdHuesped);

                return HUESPED.RUT;
            }

        }

        public long NHabitacion
        {
            get
            {
                DALC.HABITACION HABITACION = CommonBC.Modelo.HABITACION.FirstOrDefault(e => e.NUMERO == this.IdHabitacion);

                return HABITACION.NUMERO;
            }

        }

        public string ShortIngreso
        {
            get
            {
                return _fechaIngreso.ToShortDateString();
            }
        }

        public string ShortSalida
        {
            get
            {
                return _fechaSalida.ToShortDateString();
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

        public int IdFactura
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

        public int IdHabitacion
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

        public DetalleFactura()
        {
            Init();
        }

        private void Init()
        {
            Id = 0;
            IdFactura = 0;
            IdHabitacion = 0;
            IdServicio = 0;
            FechaIngreso = DateTime.Today;
            FechaSalida = DateTime.Today;
            IdHuesped = string.Empty;
        }

        public int getDetalleFacturaMaxId()
        {
            try
            {
                int user = (int)CommonBC.Modelo.DETALLE_FACTURA.Max(us => us.ID);
                return user;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public bool AgregarDetalleFactura()
        {
            DALC.DETALLE_FACTURA detFactura = new DALC.DETALLE_FACTURA();

            try
            {
                detFactura.ID = getDetalleFacturaMaxId() + 1;
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
