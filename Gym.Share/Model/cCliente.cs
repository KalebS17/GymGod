using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Share.Model
{
    public class cCliente
    {
        public String Nombre { get; set; }
        public String Identificacion { get; set; }
        public DateTime  FechaNacimiento { get; set; }
        public String Estatura { get; set; }
        public decimal IMC { get; set; }
        public decimal Peso { get; set; }
        public string Correo { get; set; }

    }
}
