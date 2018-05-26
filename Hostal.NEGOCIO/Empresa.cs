using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostal.NEGOCIO
{
    public class Empresa
    {
        private int _usuarioId;
        private string _rut,_razonSocial,_giro, _direccion,_telefono;

        public string Telefono
        {
            get
            {
                return _telefono;
            }

            set
            {
                _telefono = value;
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

        public string RazonSocial
        {
            get
            {
                return _razonSocial;
            }

            set
            {
                _razonSocial = value;
            }
        }

        public string Giro
        {
            get
            {
                return _giro;
            }

            set
            {
                _giro = value;
            }
        }

        public string Direccion
        {
            get
            {
                return _direccion;
            }

            set
            {
                _direccion = value;
            }
        }

        public Empresa()
        {
            this.Init();
        }
        private void Init()
        {
            this.Rut = string.Empty;
            this.Telefono = string.Empty;
            this.UsuarioId = 0;
            this.RazonSocial = string.Empty;
            this.Giro = string.Empty;
            this.Direccion = string.Empty;
        }


        public Empresa getEmpresa()
        {
            try
            {
                Hostal.DALC.EMPRESA empresa = CommonBC.Modelo.EMPRESA.FirstOrDefault(us => us.RUT == this.Rut);

                Empresa emp = new Empresa();
                emp.Rut = empresa.RUT;
                emp.RazonSocial = empresa.RAZON_SOCIAL;
                emp.Giro = empresa.GIRO;
                emp.Direccion = empresa.DIRECCION;
                emp.Telefono = empresa.TELEFONO;
                emp.UsuarioId = (int)empresa.USUARIO_ID;
                return emp;

            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
                return null;
            }
        }

        public Empresa getEmpresaByUserId(Usuario usuario)
        {
            try
            {
                Hostal.DALC.EMPRESA empresa = CommonBC.Modelo.EMPRESA.FirstOrDefault(us => us.USUARIO_ID == usuario.Id);

                Empresa emp = new Empresa();
                emp.Rut = empresa.RUT;
                emp.RazonSocial = empresa.RAZON_SOCIAL;
                emp.Giro = empresa.GIRO;
                emp.Direccion = empresa.DIRECCION;
                emp.Telefono = empresa.TELEFONO;
                emp.UsuarioId = (int)empresa.USUARIO_ID;
                return emp;

            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
                return null;
            }
        }

        public bool agregarEmpresa()
        {
            DALC.EMPRESA emp = new DALC.EMPRESA();
            try
            {
                emp.RUT = this.Rut;
                emp.RAZON_SOCIAL = this.RazonSocial;
                emp.GIRO = this.Giro;
                emp.DIRECCION = this.Direccion;
                emp.TELEFONO = this.Telefono;
                emp.USUARIO_ID = this.UsuarioId;

                CommonBC.Modelo.EMPRESA.Add(emp);
                CommonBC.Modelo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                CommonBC.Modelo.EMPRESA.Remove(emp);
                Logger.Log(ex.Message);
                return false;
            }
        }

        public bool actualizarEmpresa()
        {
            try
            {
                DALC.EMPRESA empresa = CommonBC.Modelo.EMPRESA.FirstOrDefault(us => us.RUT == this.Rut);
                empresa.RAZON_SOCIAL = this.RazonSocial;
                empresa.GIRO = this.Giro;
                empresa.DIRECCION = this.Direccion;
                empresa.TELEFONO = this.Telefono;
                empresa.USUARIO_ID = this.UsuarioId;

                CommonBC.Modelo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
                return false;
            }
        }

        public bool borrarEmpresa()
        {
            try
            {
                DALC.EMPRESA empresa = CommonBC.Modelo.EMPRESA.FirstOrDefault(us => us.RUT == this.Rut);

                CommonBC.Modelo.EMPRESA.Remove(empresa);
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
