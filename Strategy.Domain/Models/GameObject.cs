using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Strategy.Domain.Models
{
    public abstract class GameObject
    {
        /// <summary>
        /// Координаты объекта на карте.
        /// </summary>
        public Coordinates Coordinates { get; set; }
        public ImageSource ImageSource { get; set; }
        public static ImageSource BuildSourceFromPath(string path)
        {
            return new BitmapImage(new Uri(path, UriKind.Relative));
        }
    }
}
