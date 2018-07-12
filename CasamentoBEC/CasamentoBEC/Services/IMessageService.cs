using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CasamentoBEC.Services
{
    interface IMessageService
    {
        Task ShowAsync(string tittle,string message,string cancel);
    }
}
