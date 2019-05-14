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
                var convidado = JsonConvert.DeserializeObject<Convidado>(response);
                convidado.Sucesso = true;
                return convidado;
            }
            catch (HttpRequestException requestException)
            {
                return new Convidado { Sucesso = false, CodErro = "1", MsgErro = requestException.Message };
            }
            catch (Exception ex)
            {
                return new Convidado { Sucesso = false, CodErro = "2", MsgErro = ex.Message };
            }
        }

        public async Task<Convidado> SentConvidadoAsync(Convidado convidado)
        {
            try
            {
                string url = $"https://apicasamento.azurewebsites.net/api/Convidados/identificador?identificador={convidado.Identificador}";
                string jsonString = JsonConvert.SerializeObject(convidado);
                var response = await client.PostAsync(url, new StringContent(jsonString, Encoding.UTF8, "application/json"));
                await response.Content.ReadAsStringAsync();
                return new Convidado { Sucesso = true };
            }
            catch (HttpRequestException requestException)
            {
                return new Convidado { Sucesso = false, CodErro = "1", MsgErro = requestException.Message };
            }
            catch (Exception ex)
            {
                return new Convidado { Sucesso = false, CodErro = "2", MsgErro = ex.Message };
            }
        }
    }
}
