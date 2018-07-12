using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CasamentoBEC.Services
{
    public class MessageService : IMessageService
    {
        public async Task ShowAsync(string titulo,string mensagem,string cancelar)
        {
           await App.Current.MainPage.DisplayAlert(titulo,mensagem,cancelar);
        }
    }
}
