using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Strategy.Domain.Models
{
    public abstract class Unit : GameObject
    {
        public Unit(Player player, int x, int y)
        {
            Player = player;
            Coordinates = new Coordinates(x, y);
            IsDead = false;
            DeadUnitSourse = BuildSourceFromPath("Resources/Units/Dead.png");
        }
       
        public Unit(Player player)
        {
            Player = player;
            IsDead = false;
            DeadUnitSourse = BuildSourceFromPath("Resources/Units/Dead.png");
        }
        /// <summary>
        /// Игрок, который управляет юнитом.
        /// </summary>
        public Player Player { get; }
        public int RadiusMove { get; set; }
        public int RadiusAttack { get; set; }
        private int hp;
        public int HP { get {
                return hp;
            } set {
                if (IsDead) return;
                hp = value;
                if (hp<= 0)
                {
                    hp = 0;
                    IsDead = true;
                }
            } }
        public bool IsDead { get; set; }
       
       public ImageSource DeadUnitSourse { get; set; }
        public bool CanMove(Ground ground)
        {
            if (IsDead) return false;
            if (!ground.CanMove) return false;
            if (ground.HaveUnit) return false;
            if (Math.Abs(Coordinates.X - ground.Coordinates.X)>RadiusMove || Math.Abs(Coordinates.Y-ground.Coordinates.Y)> RadiusMove)
            {
                return false;
            }
            return true;
        }
        public bool CanAttack(Unit target)
        {
            if (Player == target.Player) return false;
            if (target.IsDead) return false;
            if (Math.Abs(Coordinates.X - target.Coordinates.X)>RadiusAttack || Math.Abs(Coordinates.Y - target.Coordinates.Y) > RadiusAttack)
            {
                return false;
            }
            return true;
        }
        public abstract void Attack(Unit target);
        
        
    }
}
