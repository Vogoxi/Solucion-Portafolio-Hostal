using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostal.NEGOCIO
{
    public class Usuario
    {
        #region Campos
        private int _id;
        private string _usuario, _contrasena;
        private string _tipoUsuario;
        #endregion

        #region Propiedades
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

        public string User
        {
            get
            {
                return _usuario;
            }

            set
            {
                _usuario = value;
            }
        }

        public string Contrasena
        {
            get
            {
                return _contrasena;
            }

            set
            {
                _contrasena = value;
            }
        }

        public string TipoUsuario
        {
            get
            {
                return _tipoUsuario;
            }

            set
            {
                _tipoUsuario = value;
            }
        }
        #endregion

        #region Constructor
        public Usuario()
        {
            Init();
        }


        private void Init()
        {
            Id = 0;
            User = string.Empty;
            Contrasena = string.Empty;
            TipoUsuario = string.Empty;
        }

        #endregion

        #region Metodos

        public int getUsuarioMaxId()
        {
            try
            {
                int user = (int)CommonBC.Modelo.USUARIO.Max(us => us.ID);
                return user;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public Usuario getUsuario()
        {
            try
            {
                Hostal.DALC.USUARIO usuario = CommonBC.Modelo.USUARIO.First(us => us.ID == this.Id);

                Usuario user = new Usuario();
                user.Id = (int)usuario.ID;
                user.User = usuario.USUARIO1;
                user.Contrasena = usuario.CONTRASENA;
                user.TipoUsuario = usuario.TIPO_USUARIO;
                return user;
                
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
                return null;
            }
        }

        public int getUsuarioIdByName(string nombre)
        {
            try
            {
                DALC.USUARIO usuario = CommonBC.Modelo.USUARIO.FirstOrDefault(us => us.USUARIO1 == nombre);
                if (usuario != null)
                {
                    return (int)usuario.ID;
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

        public bool agregarUsuario(string nombre)
        {
            try
            {
                if (null == CommonBC.Modelo.USUARIO.FirstOrDefault(us => us.USUARIO1 == nombre))
                {
                    DALC.USUARIO user = new DALC.USUARIO();
                    user.ID = getUsuarioMaxId() + 1;
                    user.USUARIO1 = this.User;
                    user.CONTRASENA = this.Contrasena;
                    user.TIPO_USUARIO = this.TipoUsuario;

                    CommonBC.Modelo.USUARIO.Add(user);
                    CommonBC.Modelo.SaveChanges();
                    return true;
                }else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
                return false;
            }
        }

        public int validarUsuario(string nombre, string password)
        {
            try
            {
                DALC.USUARIO usuario = CommonBC.Modelo.USUARIO.FirstOrDefault(us => us.USUARIO1 == nombre && us.CONTRASENA == password);

                if (null != usuario)
                {
                    return (int)usuario.ID;
                }else
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

        public bool actualizarUsuario()
        {
            try
            {
                DALC.USUARIO usuario = CommonBC.Modelo.USUARIO.FirstOrDefault(us => us.ID == this.Id);
                usuario.USUARIO1 = this.User;
                usuario.TIPO_USUARIO = this.TipoUsuario;
                usuario.CONTRASENA = this.Contrasena;
                CommonBC.Modelo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
                return false;
            }
        }

        public bool borrarUsuario()
        {
            try
            {
                DALC.USUARIO usuario = CommonBC.Modelo.USUARIO.FirstOrDefault(us => us.ID == this.Id);

                CommonBC.Modelo.USUARIO.Remove(usuario);
                CommonBC.Modelo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
                return false;
            }
        }

        #endregion

    }
}
