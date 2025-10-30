using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Share.Model
{
    public class cRutinaEjercicio
    {
        public int IdRutina { get; set; }
        public int IdEjercicio { get; set; }
        public int CantidadSeries { get; set; }
        public int Repeticiones { get; set; }
        public String Descripcion { get; set; }

        public cRutinaEjercicio()
        {
            IdRutina = 0;
            IdEjercicio = 0;
            CantidadSeries = 0;
            Repeticiones = 0;
            Descripcion = string.Empty;
        }
    }
}
