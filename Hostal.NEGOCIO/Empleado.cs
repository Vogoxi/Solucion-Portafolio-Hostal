using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostal.NEGOCIO
{
    public class Empleado
    {
        #region Campos

        private int _id, _idUsuario;
        private string _nombre, _apellido;



        #endregion

        #region Propiedades

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

        public int IdUsuario
        {
            get
            {
                return _idUsuario;
            }

            set
            {
                _idUsuario = value;
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

        #endregion

        #region Constructor

        public Empleado()
        {
            Init();
        }

        private void Init()
        {
            _id = 0;
            _apellido = string.Empty;
            _nombre = string.Empty;
            _idUsuario = 0;
        }

        #endregion

        #region Metodos



        #endregion

    }
}
