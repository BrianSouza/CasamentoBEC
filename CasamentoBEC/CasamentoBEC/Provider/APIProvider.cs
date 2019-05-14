using CasamentoBEC.Model;
using CasamentoBEC.Provider.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CasamentoBEC.Provider
{
    public class APIProvider : IAPIProvider
    {

        HttpClient client = new HttpClient();
        public async Task<Convidado> GetConvidadoAsync(string identificador)
        {
            try
            {
                string url = $"https://apicasamento.azurewebsites.net/api/Convidados/{identificador}";
                var response = await client.GetStringAsync(url);
                var filmes = JsonConvert.DeserializeObject<Convidado>(response);
                return filmes;
            }
            catch (HttpRequestException requestException)
            {
                if (requestException.InnerException is WebException &&
                  ((WebException)requestException.InnerException).Status == WebExceptionStatus.NameResolutionFailure)
                {
                    throw requestException;
                }

                throw requestException;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw ex;
            }
        }

        public async Task SentFilmesAsync(Convidado convidado)
        {
            try
            {
                string url = $"https://apicasamento.azurewebsites.net/api/Convidados/identificador?identificador={convidado.Identificador}";
                string jsonString = JsonConvert.SerializeObject(convidado);
                var response = await client.PostAsync(url, new StringContent(jsonString, Encoding.UTF8, "application/json"));
                await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
