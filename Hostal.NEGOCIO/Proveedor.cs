using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostal.NEGOCIO
{
    public class Proveedor
    {
        private string _rut, _nombre, _rubro;
        private int _usuarioId;

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

        public string Rubro
        {
            get
            {
                return _rubro;
            }

            set
            {
                _rubro = value;
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

        public int UsuarioId
        {
            get
            {
                return _usuarioId;
            }

            set
            {
                _usuarioId = value;
            }
        }

        public Proveedor()
        {
            this.Init();
        }

        private void Init()
        {
            this._rut = string.Empty;
            this._nombre = string.Empty;
            this._rubro = string.Empty;
            this._usuarioId = 0;
        }

        public Proveedor getProveedor()
        {
            try
            {
                Hostal.DALC.PROVEEDOR proveedor = CommonBC.Modelo.PROVEEDOR.FirstOrDefault(us => us.RUT == this.Rut);

                Proveedor prov = new Proveedor();
                prov.Rut = proveedor.RUT;
                prov.Nombre = proveedor.NOMBRE;
                prov.Rubro = proveedor.RUBRO;
                prov.UsuarioId = (int)proveedor.USUARIO_ID;

                return prov;

            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
                return null;
            }
        }

        public bool agregarProveedor()
        {
            try
            {
                DALC.PROVEEDOR prov = new DALC.PROVEEDOR();
                prov.RUT = this.Rut;
                prov.NOMBRE = this.Nombre;
                prov.RUBRO = this.Rubro;
                prov.USUARIO_ID = this.UsuarioId;

                CommonBC.Modelo.PROVEEDOR.Add(prov);
                CommonBC.Modelo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
                return false;
            }
        }

        public bool actualizarProveedor()
        {
            try
            {
                DALC.PROVEEDOR proveedor = CommonBC.Modelo.PROVEEDOR.FirstOrDefault(us => us.RUT == this.Rut);
                proveedor.NOMBRE = this.Nombre;
                proveedor.RUBRO = this.Rubro;
                proveedor.USUARIO_ID = this.UsuarioId;

                CommonBC.Modelo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
                return false;
            }
        }

        public bool borrarProveedor()
        {
            try
            {
                DALC.PROVEEDOR proveedor = CommonBC.Modelo.PROVEEDOR.FirstOrDefault(us => us.RUT == this.Rut);

                CommonBC.Modelo.PROVEEDOR.Remove(proveedor);
                CommonBC.Modelo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
                return false;
            }
        }

    }
}
