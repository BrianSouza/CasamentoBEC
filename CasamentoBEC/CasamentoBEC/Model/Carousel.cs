using CasamentoBEC.Model.NewFolder;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasamentoBEC.Model
{
    public class Carousel : ICarousel
    {
        public string ImageURL { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
