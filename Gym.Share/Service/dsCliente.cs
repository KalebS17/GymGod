using Dapper;
using Gym.Share.Model;
using Microsoft.Data.SqlClient;
using System.Linq.Expressions;

namespace Gym.Share.Service
{
    public class dsCliente
    {
        private String sqlConnectionString { get; set; }

        public dsCliente(String sqlConnectionString)
        {
            this.sqlConnectionString = sqlConnectionString;
        }

        protected SqlConnection dbcon()
        {
            return new SqlConnection(sqlConnectionString);
        }

        public async Task<List<cCliente>> getClientes()
        {
            try
            {
                var db = dbcon();
                var sql = @"select Identificacion, Nombre, FechaNacimiento, Estatura, IMC, Peso, Correo from Cliente order by Nombre";
                var resultado = await db.QueryAsync<cCliente>(sql.ToString());
                return resultado.ToList();
            }
            catch (Exception ex)
            {
                return new List<cCliente>();
            }
        }

        public async Task<bool> insertarCliente(cCliente _Cliente)
        {
            try
            {
                var db = dbcon();
                var sql = @"insert into Cliente(Identificacion, Nombre, FechaNacimiento, Estatura, IMC, Peso, Correo) values (@Identifiacion, @Nombre, @FechaNacimiento, @Estatura, @IMC, @Peso, @Correo)";
                var resultado = await db.ExecuteAsync(sql.ToString(), _Cliente);
                return resultado > 0;
            }
            catch { return false; }

        }

        public async Task<bool> actualizarCliente(cCliente _Cliente)
        {
            try
            {
                var db = dbcon();
                var sql = @"update Cliente set Identificacion=@Identifiacion, Nombre=@Nombre, FechaNacimiento=@FechaNacimiento, Estatura=@Estatura, IMC=@IMC, Peso=@Peso, Correo=@Correo where Identificacion=@Identificacion";
                var resultado = await db.ExecuteAsync(sql.ToString(), _Cliente);
                return resultado > 0;
            }
            catch { return false; }
        }

        public async Task<bool> eliminarCliente(cCliente _Cliente)
        {
            try
            {
                var db = dbcon();
                var sql = @"delete from Cliente where Identificacion=@Identificacion";
                var resultado = await db.ExecuteAsync(sql.ToString(), _Cliente);
                return resultado > 0;
            }
            catch { return false; }
        }
    }
}


