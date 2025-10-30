using Gym.Share.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Bll.Interface
{
    public interface ICategoria
    {
        Task<bool> actualizarCategoria(cCategoria pCategoria);
        Task<bool> agregarCategoria(cCategoria pCategoria);
        Task<bool> eliminarCategoria(int pIdCategoria);
        Task<List<cCategoria>> getCategorias();

    }
}
