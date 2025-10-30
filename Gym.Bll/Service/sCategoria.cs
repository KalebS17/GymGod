using Gym.Bll.Interface;
using Gym.Bll.Model;
using Gym.Share.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Gym.Bll.Service
{
    public class sCategoria : ICategoria
    {
        private string urlApi = "";
        //********************************************************************************************************************

        public async Task<List<cCategoria>> getCategorias()
        {
            try
            {
                cApiUrl mapi = new cApiUrl();
                // Asegurar una sola barra entre base y ruta del API
                urlApi = mapi.getWebApiUrl().ToString().TrimEnd('/') + "/api/categoria/getCategorias";
                var httpClient = new HttpClient();
                var respuesta = await httpClient.GetAsync(urlApi);
                if (respuesta.IsSuccessStatusCode)
                {
                    List<cCategoria> mLista = await respuesta.Content.ReadFromJsonAsync<List<cCategoria>>();
                    return mLista;
                }
                else
                {
                    return new List<cCategoria>();
                }
            }
            catch (Exception ex)
            {
                return new List<cCategoria>();
            }
        }

        public async Task<bool> agregarCategoria(cCategoria pCategoria)
        {
            try
            {
                cApiUrl mapi = new cApiUrl();
                urlApi = mapi.getWebApiUrl().ToString().Trim() + $"api/categoria/agregarcat";
                var httpClient = new HttpClient();
                var mcategoriaSerializado = JsonSerializer.Serialize(pCategoria);
                HttpContent mContent = new StringContent(mcategoriaSerializado.ToString(), Encoding.UTF8, "application/json");
                var respuesta = await httpClient.PostAsync(urlApi, mContent);
                if (respuesta.IsSuccessStatusCode)
                {
                    return true;
                }
                else { return false; }
                
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> actualizarCategoria(cCategoria pCategoria)
        {
            try
            {
                cApiUrl mapi = new cApiUrl();
                urlApi = mapi.getWebApiUrl().ToString().Trim() + $"api/categoria/actualizarCategoria";
                var httpClient = new HttpClient();
                var mcategoriaSerializado = JsonSerializer.Serialize(pCategoria);
                HttpContent mContent = new StringContent(mcategoriaSerializado.ToString(), Encoding.UTF8, "application/json");
                var respuesta = await httpClient.PutAsync(urlApi, mContent);
                if (respuesta.IsSuccessStatusCode)
                {
                    return true;
                }
                else { return false; }

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> eliminarCategoria(int pIdCategoria)
        {
            try
            {
                cApiUrl mapi = new cApiUrl();
                urlApi = mapi.getWebApiUrl().ToString().Trim() + $"api/categoria/eliminarCategoria/{pIdCategoria}";
                var httpClient = new HttpClient();
                var respuesta = await httpClient.DeleteAsync(urlApi);
                if (respuesta.IsSuccessStatusCode)
                {
                    return true;
                }
                else { return false; }

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}