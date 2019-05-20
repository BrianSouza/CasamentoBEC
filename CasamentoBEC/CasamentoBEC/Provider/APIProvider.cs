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
                string url = $"http://apicasamento.sa-east-1.elasticbeanstalk.com/api/Convidados/{identificador}";
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

        public async Task<Convidado> ConfirmarPresencaAsync(Convidado convidado)
        {
            try
            {
                string url = $"http://apicasamento.sa-east-1.elasticbeanstalk.com/api/Convidados/{convidado.Identificador}";
                string jsonString = JsonConvert.SerializeObject(convidado);
                var response =  await client.GetStringAsync(url);
                var convidadoRetorno = JsonConvert.DeserializeObject<Convidado>(response);
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
