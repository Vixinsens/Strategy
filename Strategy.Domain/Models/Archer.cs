using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Media.Imaging;
namespace Strategy.Domain.Models
{
    /// <summary>
    /// Лучник.
    /// </summary>
    public sealed class Archer:Unit
    {
        /// <inheritdoc />
        public Archer(Player player, int x, int y): base(player, x, y)
        {
            RadiusMove = 3;
            RadiusAttack = 5;
            HP = 50;
            ImageSource = BuildSourceFromPath("Resources/Units/Archer.png");
        }
        public Archer(Player player) : base(player)
        {
            RadiusMove = 3;
            RadiusAttack = 5;
            HP = 50;
            ImageSource = BuildSourceFromPath("Resources/Units/Archer.png");
        }
        public override void Attack(Unit target)
        {
            if (!CanAttack(target)) return;
            if (Math.Abs(Coordinates.X - target.Coordinates.X) <= 1 && Math.Abs(Coordinates.Y - target.Coordinates.Y) <= 1)
            {
                target.HP -= 25;
            }
            else target.HP -= 50;
        }
         

    }
}