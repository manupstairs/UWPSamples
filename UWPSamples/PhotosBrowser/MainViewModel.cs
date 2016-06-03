using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotosBrowser
{
    public class MainViewModel
    {
        public List<Photo> Photos { get; set; }

        public MainViewModel()
        {
            InitData();
        }

        private void InitData()
        {
            Photos = new List<Photo>
            {
                new Photo { ImageUri = new Uri("ms-appx:///Assets/1.png") },
                new Photo { ImageUri = new Uri("ms-appx:///Assets/2.png") },
                new Photo { ImageUri = new Uri("ms-appx:///Assets/3.png") }
            };
        }
    }

    public class Photo
    {
        public Uri ImageUri { get; set; }
    }
}
