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
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
                return 0;
            }
        }

        public Usuario getUsuario(string nombre)
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

        public bool agregarUsuario(string nombre)
        {
            try
            {
                if (null == CommonBC.Modelo.USUARIO.First(us => us.USUARIO1 == nombre))
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

        #endregion

    }
}
