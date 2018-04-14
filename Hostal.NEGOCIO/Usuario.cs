using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostal.NEGOCIO
{
    public class Usuario
    {
        private int _id;
        private string _usuario, _contrasena;
        private char _tipoUsuario;

        public Usuario()
        {
            Init();
        }

        private void Init()
        {
            _id = 0;
            _usuario = string.Empty;
            _contrasena = string.Empty;
            _tipoUsuario = "";
        }
    }
}
