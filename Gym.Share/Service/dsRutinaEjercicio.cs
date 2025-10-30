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
    public class dsRutinaEjercicio
    {
        private string sqlConnectionString { get; set; }

        public dsRutinaEjercicio(string sqlConnectionString)
        {
            this.sqlConnectionString = sqlConnectionString;
        }

        protected SqlConnection dbcon()
        {
            return new SqlConnection(sqlConnectionString);
        }

        public async Task<List<cRutinaEjercicio>> getRutinaEjercicios(int idRutina)
        {
            try
            {
                var db = dbcon();
                var sql = @"select IdRutina, IdEjercicio, CantidadSeries, Repeticiones, Descripcion from RutinaEjercicio where IdRutina = @IdRutina order by IdEjercicio";
                var resultado = await db.QueryAsync<cRutinaEjercicio>(sql.ToString(), new { IdRutina = idRutina });
                return resultado.ToList();
            }
            catch
            {
                return new List<cRutinaEjercicio>();
            }
        }

        public async Task<bool> insertarRutinaEjercicio(cRutinaEjercicio _RutinaEjercicio)
        {
            try
            {
                var db = dbcon();
                var sql = @"insert into RutinaEjercicio (IdRutina, IdEjercicio, CantidadSeries, Repeticiones, Descripcion) values (@IdRutina, @IdEjercicio, @CantidadSeries, @Repeticiones, @Descripcion)";
                var resultado = await db.ExecuteAsync(sql.ToString(), _RutinaEjercicio);
                return resultado > 0;
            }
            catch { return false; }
        }

        public async Task<bool> actualizarRutinaEjercicio(cRutinaEjercicio _RutinaEjercicio)
        {
            try
            {
                var db = dbcon();
                var sql = @"update RutinaEjercicio set CantidadSeries=@CantidadSeries, Repeticiones=@Repeticiones, Descripcion=@Descripcion where IdRutina=@IdRutina and IdEjercicio=@IdEjercicio";
                var resultado = await db.ExecuteAsync(sql.ToString(), _RutinaEjercicio);
                return resultado > 0;
            }
            catch { return false; }
        }

        public async Task<bool> eliminarRutinaEjercicio(int idRutina, int idEjercicio)
        {
            try
            {
                var db = dbcon();
                var sql = @"delete from RutinaEjercicio where IdRutina=@IdRutina and IdEjercicio=@IdEjercicio";
                var resultado = await db.ExecuteAsync(sql.ToString(), new { IdRutina = idRutina, IdEjercicio = idEjercicio });
                return resultado > 0;
            }
            catch { return false; }
        }
    }
}
