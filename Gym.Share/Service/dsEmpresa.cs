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
    public class dsEmpresa
    {
        private string sqlConnectionString { get; set; }

        public dsEmpresa(string sqlConnectionString)
        {
            this.sqlConnectionString = sqlConnectionString;
        }

        protected SqlConnection dbcon()
        {
            return new SqlConnection(sqlConnectionString);
        }

        public async Task<List<cEmpresa>> getEmpresaById(cEmpresa _Empresa)
        {
            try
            {
                var db = dbcon();
                var sql = @"select Id, Nombre, Correo, Telefono, FechaCreado, Direccion, Logo from Empresa where Id=@Id";
                var resultado = await db.QueryAsync<cEmpresa>(sql.ToString(), _Empresa);
                return resultado.ToList();
            }
            catch
            {
                return new List<cEmpresa>();
            }
        }

        public async Task<bool> insertarEmpresa(cEmpresa _Empresa)
        {
            try
            {
                var db = dbcon();
                var sql = @"insert into Empresa (Id, Nombre, Correo, Telefono, FechaCreado, Direccion, Logo) values (@Id, @Nombre, @Correo, @Telefono, @FechaCreado, @Direccion, @Logo)";
                var resultado = await db.ExecuteAsync(sql.ToString(), _Empresa);
                return resultado > 0;
            }
            catch { return false; }
        }

        public async Task<bool> actualizarEmpresa(cEmpresa _Empresa)
        {
            try
            {
                var db = dbcon();
                var sql = @"update Empresa set Id=@Id, Nombre=@Nombre, Correo=@Correo, Telefono=@Telefono, FechaCreado=@FechaCreado, Direccion=@Direccion, Logo=@Logo where Id=@Id";
                var resultado = await db.ExecuteAsync(sql.ToString(), _Empresa);
                return resultado > 0;
            }
            catch { return false; }
        }

        public async Task<bool> eliminarEmpresa(cEmpresa _Empresa)
        {
            try
            {
                var db = dbcon();
                var sql = @"delete from Empresa where Id=@Id";
                var resultado = await db.ExecuteAsync(sql.ToString(), _Empresa);
                return resultado > 0;
            }
            catch { return false; }
        }
    }
}
