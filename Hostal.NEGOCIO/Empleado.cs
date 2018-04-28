using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostal.NEGOCIO
{
    public class Empleado
    {
        private int _id, _usuarioId;
        private string _nombre, _apellido;

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

        public Empleado()
        {
            this.Init();
        }

        private void Init()
        {
            this._id = 0;
            this._usuarioId = 0;
            this._nombre = string.Empty;
            this._apellido = string.Empty;
        }

        public int getEmpleadoMaxId()
        {
            try
            {
                int emp = (int)CommonBC.Modelo.EMPLEADO.Max(us => us.ID);
                return emp;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public Empleado getEmpleado()
        {
            try
            {
                Hostal.DALC.EMPLEADO empleado = CommonBC.Modelo.EMPLEADO.First(us => us.ID == this.Id);

                Empleado emp = new Empleado();
                emp.Id = (int)empleado.ID;
                emp.Nombre = empleado.NOMBRE;
                emp.Apellido = empleado.APELLIDO;
                emp.UsuarioId = (int)empleado.USUARIO_ID;

                return emp;

            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
                return null;
            }
        }

        public int getEmpleadoIdByName(string nombre)
        {
            try
            {
                DALC.EMPLEADO empleado = CommonBC.Modelo.EMPLEADO.FirstOrDefault(us => us.NOMBRE == nombre);
                if (empleado != null)
                {
                    return (int)empleado.ID;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
                return 0;
            }
        }

        public bool agregarEmpleado()
        {
            try
            {
                DALC.EMPLEADO emp = new DALC.EMPLEADO();
                emp.ID = getEmpleadoMaxId() + 1;
                emp.NOMBRE = this.Nombre;
                emp.APELLIDO = this.Apellido;
                emp.USUARIO_ID = this.UsuarioId;

                CommonBC.Modelo.EMPLEADO.Add(emp);
                CommonBC.Modelo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
                return false;
            }
        }

        public bool actualizarEmpleado()
        {
            try
            {
                DALC.EMPLEADO empleado = CommonBC.Modelo.EMPLEADO.FirstOrDefault(us => us.ID == this.Id);
                empleado.USUARIO_ID = this.UsuarioId;
                empleado.NOMBRE = this.Nombre;
                empleado.APELLIDO = this.Apellido;

                CommonBC.Modelo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
                return false;
            }
        }

        public bool borrarEmpleado()
        {
            try
            {
                DALC.EMPLEADO empleado = CommonBC.Modelo.EMPLEADO.FirstOrDefault(us => us.ID == this.Id);

                CommonBC.Modelo.EMPLEADO.Remove(empleado);
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
