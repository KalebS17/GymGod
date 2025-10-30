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
    public class dsCategoria
    {
        private string sqlConnectionString {  get; set; } 
        public dsCategoria(string sqlConnectionString)
        {
            this.sqlConnectionString = sqlConnectionString;
        }
        protected SqlConnection dbcon()
        {
            return new SqlConnection(sqlConnectionString);
        }
        public async Task<List<cCategoria>> getCategorias()
        {
            try
            {
                var db = dbcon();
                var sql = @"select IdCategoria,Categoria from Categoria order by idCategoria";
                var resultado = await db.QueryAsync<cCategoria>(sql.ToString());
                return resultado.ToList();
            }
            catch { 
                return new List<cCategoria>();
            }
        }

        //*************************************************************************************************************************
        public async Task<bool> insertarCategoria(cCategoria _Categoria)
        {
            try
            {
                var db = dbcon();
                var sql = @"insert into Categoria (Categoria) values (@Categoria)";
                var resultado = await db.ExecuteAsync(sql.ToString(),_Categoria);
                return resultado > 0;
            }
            catch { return false; }

        }
        //*************************************************************************************************************************
        public async Task<bool> actuallizarCategoria(cCategoria _Categoria)
        {
            try
            {
                var db = dbcon();
                var sql = @"update Categoria set Categoria=@Categoria where IdCategoria=@IdCategoria";
                var resultado = await db.ExecuteAsync(sql.ToString(), _Categoria);
                return resultado > 0;
            }
            catch { return false; }

        }
        //*************************************************************************************************************************
        public async Task<bool> deleteCategoria(cCategoria _Categoria)
        {
            try
            {
                var db = dbcon();
                var sql = @"delete from Categoria where IdCategoria=@IdCategoria";
                var resultado = await db.ExecuteAsync(sql.ToString(), _Categoria);
                return resultado > 0;
            }
            catch { return false; }

        }

    }
}
