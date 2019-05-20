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

        Task<Convidado> ConfirmarPresencaAsync(Convidado convidado);
    }
}
