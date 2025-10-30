using Dapper;
using Gym.Share.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Share.Service
{
    public class dsRutina
    {

        private string sqlConnectionString { get; set; }

        public dsRutina(string sqlConnectionString)
        {
            this.sqlConnectionString = sqlConnectionString;
        }

        protected SqlConnection dbcon()
        {
            return new SqlConnection(sqlConnectionString);
        }

        // Metodos para agregar, actualizar, eliminar y obtener rutinas

        public async Task<List<cRutina>> getRutinas()
        {
            try
            {
                var db = dbcon();
                var sql = @"select IdRutina, Nombre, Identificacion, Estado from Rutina order by IdRutina";
                var resultado = await db.QueryAsync<cRutina>(sql.ToString());
                return resultado.ToList();
            }
            catch
            {
                return new List<cRutina>();
            }
        }

        public async Task<bool> insertarRutina(cRutina _Rutina)
        {
            try
            {
                var db = dbcon();
                var sql = @"insert into Rutina (Nombre, Identificacion, Estado) values (@Nombre, @Identificacion, @Estado)";
                var resultado = await db.ExecuteAsync(sql.ToString(), _Rutina);
                return resultado > 0;
            }
            catch { return false; }
        }

        public async Task<bool> actualizarRutina(cRutina _Rutina)
        {
            try
            {
                var db = dbcon();
                var sql = @"update Rutina set Nombre=@Nombre, Identificacion=@Identificacion, Estado=@Estado where IdRutina=@IdRutina";
                var resultado = await db.ExecuteAsync(sql.ToString(), _Rutina);
                return resultado > 0;
            }
            catch { return false; }
        }

        public async Task<bool> eliminarRutina(int idRutina)
        {
            try
            {
                var db = dbcon();
                var sql = @"delete from Rutina where IdRutina=@IdRutina";
                var resultado = await db.ExecuteAsync(sql.ToString(), new { IdRutina = idRutina });
                return resultado > 0;
            }
            catch { return false; }
        }


    }
}
