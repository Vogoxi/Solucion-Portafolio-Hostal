using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostal.NEGOCIO
{
    public class Plato
    {
        private int _id, _idServicio;
        private string _nombre;

        public Plato()
        {
            this._id = 0;
            this._idServicio = 0;
            this._nombre = string.Empty;
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

        public int getPlatoMaxId()
        {
            try
            {
                int user = (int)CommonBC.Modelo.PLATO.Max(us => us.ID);
                return user;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public bool AgregarPlato()
        {

            DALC.PLATO plato = new DALC.PLATO();

            try
            {
                // ID por trigger
                plato.ID_SERVICIO = (int)this.IdServicio;
                plato.NOMBRE = this.Nombre;

                CommonBC.Modelo.PLATO.Add(plato);
                CommonBC.Modelo.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                CommonBC.Modelo.PLATO.Remove(plato);
                Logger.Log("Plato.cs");
                Logger.Log(ex.Message);
                if (ex.InnerException != null)
                {
                    Logger.Log(ex.InnerException.ToString());
                }
                return false;
            }
        }


        public Plato Getplato()
        {
            DALC.PLATO plato = new DALC.PLATO();

            try
            {
                plato = CommonBC.Modelo.PLATO.FirstOrDefault(r => this.Id == r.ID);

                if (plato != null)
                {
                    Plato pla = new Plato();

                    pla.IdServicio = (int)plato.ID_SERVICIO;
                    pla.Nombre = plato.NOMBRE;


                    return pla;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                Logger.Log("Plato.cs");
                Logger.Log(ex.Message);
                if (ex.InnerException != null)
                {
                    Logger.Log(ex.InnerException.ToString());
                }
                return null;
            }
        }

        public bool ActualizarPlato()
        {
            DALC.PLATO plato = new DALC.PLATO();

            try
            {
                plato = CommonBC.Modelo.PLATO.FirstOrDefault(r => this.Id == r.ID);

                plato.NOMBRE = this.Nombre;
                plato.ID_SERVICIO = this.IdServicio;

                CommonBC.Modelo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log("Plato.cs");
                Logger.Log(ex.Message);
                if (ex.InnerException != null)
                {
                    Logger.Log(ex.InnerException.ToString());
                }
                return false;
            }
        }

        public bool BorrarPlato()
        {
            DALC.PLATO plato = new DALC.PLATO();

            try
            {
                plato = CommonBC.Modelo.PLATO.FirstOrDefault(r => this.Id == r.ID);

                CommonBC.Modelo.PLATO.Remove(plato);
                CommonBC.Modelo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log("Plato.cs");
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
