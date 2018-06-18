using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostal.NEGOCIO
{
    public class Servicio
    {
        private int _id, _precio;
        private string _nombre;

        public Servicio()
        {
            this.Id = 0;
            this.Precio = 0;
            this.Nombre = string.Empty;
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

        public string Nombre
        {
            get
            {
                return _nombre;
            }

            set
            {
                _nombre = value;
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

        public bool AgregarServicio()
        {
            DALC.SERVICIO servicio = new DALC.SERVICIO();

            try
            {
                // ID por trigger
                servicio.NOMBRE = this.Nombre;
                servicio.PRECIO = this.Precio;

                CommonBC.Modelo.SERVICIO.Add(servicio);
                CommonBC.Modelo.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                CommonBC.Modelo.SERVICIO.Remove(servicio);
                Logger.Log("Servicio.cs");
                Logger.Log(ex.Message);
                if (ex.InnerException != null)
                {
                    Logger.Log(ex.InnerException.ToString());
                }
                return false;
            }
        }

        public Servicio GetServicio()
        {
            DALC.SERVICIO servicio = new DALC.SERVICIO();

            try
            {
                servicio = CommonBC.Modelo.SERVICIO.FirstOrDefault(r => this.Id == r.ID);

                if (servicio != null)
                {
                    Servicio ser = new Servicio();

                    ser.Id = (int)servicio.ID;
                    ser.Precio = (int)servicio.PRECIO;
                    ser.Nombre = servicio.NOMBRE;
                    

                    return ser;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                Logger.Log("Servicio.cs");
                Logger.Log(ex.Message);
                if (ex.InnerException != null)
                {
                    Logger.Log(ex.InnerException.ToString());
                }
                return null;
            }
        }

        public bool ActualizarServicio()
        {
            DALC.SERVICIO servicio = new DALC.SERVICIO();

            try
            {
                servicio = CommonBC.Modelo.SERVICIO.FirstOrDefault(r => this.Id == r.ID);

                servicio.NOMBRE = this.Nombre;
                servicio.PRECIO = this.Precio;

                CommonBC.Modelo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log("Servicio.cs");
                Logger.Log(ex.Message);
                if (ex.InnerException != null)
                {
                    Logger.Log(ex.InnerException.ToString());
                }
                return false;
            }
        }

        public bool BorrarServicio()
        {
            DALC.SERVICIO servicio = new DALC.SERVICIO();

            try
            {
                servicio = CommonBC.Modelo.SERVICIO.FirstOrDefault(r => this.Id == r.ID);

                CommonBC.Modelo.SERVICIO.Remove(servicio);
                CommonBC.Modelo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log("Servicio.cs");
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
