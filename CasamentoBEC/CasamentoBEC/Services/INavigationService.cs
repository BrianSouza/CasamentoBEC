using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CasamentoBEC.Services
{
    interface INavigationService
    {
        Task PopNavigation();

        Task NavigateTo(string viewName, object param);

        Task NavigateToMain();

    }
}
