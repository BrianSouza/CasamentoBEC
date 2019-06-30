using CasamentoBEC.Model;
using CasamentoBEC.Provider.Interface;
using Newtonsoft.Json;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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

        public async Task<HttpResponseMessage> ConfirmarPresencaAsync(Convidado convidado)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string requestUrl = $"http://apicasamento.sa-east-1.elasticbeanstalk.com/api/Convidados/{convidado.Identificador}?rsvp={convidado.PresencaConfirmada}";

                    var response = await httpClient.PutAsync(new Uri(requestUrl), null);
                    return response.EnsureSuccessStatusCode();
                }
            }
            catch (HttpRequestException requestException)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        public async Task<Fotos> GetFotosAsync(int tipo)
        {
            try
            {
                string url = $"http://apicasamento.sa-east-1.elasticbeanstalk.com/api/Fotos?tipoFoto={tipo}";
                var response = await client.GetStringAsync(url);
                Fotos fotos = new Fotos { FotosIE = JsonConvert.DeserializeObject<IEnumerable<Foto>>(response) };
                fotos.Sucesso = true;
                return fotos;
            }
            catch (HttpRequestException requestException)
            {
                return new Fotos { Sucesso = false, CodErro = "1", MsgErro = requestException.Message };
            }
            catch (Exception ex)
            {
                return new Fotos { Sucesso = false, CodErro = "2", MsgErro = ex.Message };
            }
        }

        public async Task<Avisos> GetAvisos()
        {
            try
            {
                string url = $"http://apicasamento.sa-east-1.elasticbeanstalk.com/api/Avisos";
                var response = await client.GetStringAsync(url);
                Avisos avisos = new Avisos { IEAvisos = JsonConvert.DeserializeObject<IEnumerable<Aviso>>(response) };
                avisos.Sucesso = true;
                return avisos;
            }
            catch (HttpRequestException requestException)
            {
                return new Avisos { Sucesso = false, CodErro = "1", MsgErro = requestException.Message };
            }
            catch (Exception ex)
            {
                return new Avisos { Sucesso = false, CodErro = "2", MsgErro = ex.Message };
            }
        }

    }
}
