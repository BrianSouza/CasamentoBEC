using CasamentoBEC.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CasamentoBEC.Provider.Interface
{
    public interface IAPIProvider
    {
        Task<Convidado> GetConvidadoAsync(string identificador);
        Task<HttpResponseMessage> ConfirmarPresencaAsync(Convidado convidado);
        Task<Fotos> GetFotosAsync(int tipo);
        Task<Avisos> GetAvisos();
    }
}
