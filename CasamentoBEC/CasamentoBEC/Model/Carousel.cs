﻿using CasamentoBEC.Model.NewFolder;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CasamentoBEC.Model
{
    public class Carousel : ICarousel
    {
        public UriImageSource ImageURL { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
