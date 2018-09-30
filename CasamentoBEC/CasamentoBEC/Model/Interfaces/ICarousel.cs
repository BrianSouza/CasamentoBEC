using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CasamentoBEC.Model.NewFolder
{
    interface ICarousel
    {
        UriImageSource ImageURL { get; set; }
        string Name { get; set; }
    }
}
