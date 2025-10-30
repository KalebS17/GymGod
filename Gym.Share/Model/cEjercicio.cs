using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Share.Model
{
    public class cEjercicio
    {
        public int IdEjercicio { get; set; }
        public short IdCategoria { get; set; }

        public String Descripcion { get; set; }

        public cEjercicio() 
        {
            IdEjercicio = 0;
            IdCategoria = 0;
            Descripcion = string.Empty;
        }

    }
}
