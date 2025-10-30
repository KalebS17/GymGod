using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Share.Model
{
    public class cRutina
    {
        public int IdRutina { get; set; }
        public String Nombre { get; set; }
        public String Identificacion { get; set; }
        public String Estado { get; set; }

        public cRutina()
        {
            IdRutina = 0;
            Nombre = string.Empty;
            Identificacion = string.Empty;
            Estado = string.Empty;
        }
    }
}
