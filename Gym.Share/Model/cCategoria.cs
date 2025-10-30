using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Share.Model
{
    public class cCategoria
    {
        public short IdCategoria { get; set; }
        public string Categoria { get; set; }

        public cCategoria()
        {
            IdCategoria = 0;
            Categoria = string.Empty;
        }

    }
}
