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
    public class dsEjercicio
    {

        private string sqlConnectionString { get; set; }
        public dsEjercicio(string sqlConnectionString)
        {
            this.sqlConnectionString = sqlConnectionString;
        }

        protected SqlConnection dbcon()
        {
            return new SqlConnection(sqlConnectionString);
        }
        public async Task<List<cEjercicio>> getEjercicios()
        {
            try
            {
                var db = dbcon();
                var sql = @"select IdEjercicio, Descripcion, IdCategoria from Ejercicio order by IdEjercicio";
                var resultado = await db.QueryAsync<cEjercicio>(sql.ToString());
                return resultado.ToList();
            }
            catch
            {
                return new List<cEjercicio>();
            }
        }

        public async Task<bool> insertarEjercicio(cEjercicio _Ejercicio)
        {
            try
            {
                var db = dbcon();
                var sql = @"insert into Ejercicio (IdCategoria, Descripcion) values (@IdCategoria, @Descripcion)";
                var resultado = await db.ExecuteAsync(sql.ToString(), _Ejercicio);
                return resultado > 0;
            }
            catch { return false; }
        }

        public async Task<bool> actualizarEjercicio(cEjercicio _Ejercicio)
        {
            try
            {
                var db = dbcon();
                var sql = @"update Ejercicio set IdCategoria=@IdCategoria, Descripcion=@Descripcion where IdEjercicio=@IdEjercicio";
                var resultado = await db.ExecuteAsync(sql.ToString(), _Ejercicio);
                return resultado > 0;
            }
            catch { return false; }
        }

        public async Task<bool> eliminarEjercicio(cEjercicio _Ejercicio)
        {
            try
            {
                var db = dbcon();
                var sql = @"delete from Ejercicio where IdEjercicio=@IdEjercicio";
                var resultado = await db.ExecuteAsync(sql.ToString(), _Ejercicio);
                return resultado > 0;
            }
            catch { return false; }
        }
    }
}
