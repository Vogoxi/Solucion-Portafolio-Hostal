using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostal.NEGOCIO
{
    public class Huesped
    {
        private string _rut,_nombre,_apellido,_telefono,_EmpresaRut;

        public string NomApe
        {
            get
            {
                return Nombre + " " + Apellido;
            }
        }

        public string Apellido
        {
            get
            {
                return _apellido;
            }

            set
            {
                _apellido = value;
            }
        }

        public string EmpresaRut
        {
            get
            {
                return _EmpresaRut;
            }

            set
            {
                _EmpresaRut = value;
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

        public Huesped()
        {
            this.Init();
        }

        private void Init()
        {
            this.Rut = string.Empty;
            this.Nombre = string.Empty;
            this.Apellido = string.Empty;
            this.Telefono = string.Empty;
            this.EmpresaRut = string.Empty;
        }

        public Huesped getHuesped()
        {
            try
            {
                Hostal.DALC.HUESPED huesped = CommonBC.Modelo.HUESPED.FirstOrDefault(us => us.RUT == this.Rut);

                Huesped hues = new Huesped();
                hues.Rut = huesped.RUT;
                hues.Nombre = huesped.NOMBRE;
                hues.Apellido = huesped.APELLIDO;
                hues.Telefono = huesped.TELEFONO;
                hues.EmpresaRut = huesped.EMPRESA_RUT;

                return hues;

            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
                return null;
            }
        }

        public bool agregarHuesped()
        {
            try
            {
                DALC.HUESPED hues = new DALC.HUESPED();
                hues.RUT = this.Rut;
                hues.NOMBRE = this.Nombre;
                hues.APELLIDO = this.Apellido;
                hues.TELEFONO = this.Telefono;
                hues.EMPRESA_RUT = this.EmpresaRut;

                CommonBC.Modelo.HUESPED.Add(hues);
                CommonBC.Modelo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
                return false;
            }
        }

        public bool actualizarHuesped()
        {
            try
            {
                DALC.HUESPED huesped = CommonBC.Modelo.HUESPED.FirstOrDefault(us => us.RUT == this.Rut);
                huesped.NOMBRE = this.Nombre;
                huesped.APELLIDO = this.Apellido;
                huesped.TELEFONO = this.Telefono;
                huesped.EMPRESA_RUT = this.EmpresaRut;

                CommonBC.Modelo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
                return false;
            }
        }

        public bool borrarHuesped()
        {
            try
            {
                DALC.HUESPED huesped = CommonBC.Modelo.HUESPED.FirstOrDefault(us => us.RUT == this.Rut);

                CommonBC.Modelo.HUESPED.Remove(huesped);
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
