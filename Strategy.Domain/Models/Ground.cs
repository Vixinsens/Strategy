using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.Domain.Models
{
    public abstract class Ground : GameObject
    {
        public Ground(int x, int y)
        {
            Coordinates = new Coordinates(x, y);
           
        }
        public Ground() { }
        /// <summary>
        /// Стоит ли на клетке юнит
        /// </summary>
        public bool HaveUnit { get; set; }
        /// <summary>
        /// Может ли юнит передвигаться по клетке
        /// </summary>
        public bool CanMove { get; set; }
    }
}
