using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostal.DESKTOP
{
    public static class User
    {
        static int _id;

        public static int Id
        {
            get
            {
                return (_id);
            }
            set
            {
                _id = value;
            }
        }
    }
}
