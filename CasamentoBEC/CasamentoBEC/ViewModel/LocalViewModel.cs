using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CasamentoBEC.ViewModel
{
    public class LocalViewModel : BaseViewModel
    {
        private ICommand tapMap;
        public ICommand CmdTapMap
        {
            get
            {
                return tapMap;
            }
            set
            {
                tapMap = value;
                RaisePropertyChanged();
            }
        }
        public LocalViewModel()
        {
            CmdTapMap = new Command(TappedMap);
        }
        private void TappedMap()
        {
            ValidarConexao();
            if (IsNotConnected)
                return;

            Device.OpenUri(new Uri("https://www.waze.com/ul?ll=-23.52641370%2C-46.73721970&navigate=yes&zoom=16"));
        }
    }
}
