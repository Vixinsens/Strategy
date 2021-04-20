using System;
namespace Strategy.Domain.Models
{
    /// <summary>
    /// Катапульта.
    /// </summary>
    public sealed class Catapult:Unit
    {
        /// <inheritdoc />
        public Catapult(Player player, int x, int y):base(player, x, y)
        {
            RadiusMove = 1;
            RadiusAttack = 10;
            HP = 75;
            ImageSource = BuildSourceFromPath("Resources/Units/Catapult.png");
        }
        public Catapult(Player player) : base(player)
        {
            RadiusMove = 1;
            RadiusAttack = 10;
            HP = 75;
            ImageSource = BuildSourceFromPath("Resources/Units/Catapult.png");
        }
        public override void Attack(Unit target)
        {
            if (!CanAttack(target)) return;
            if (Math.Abs(Coordinates.X - target.Coordinates.X) <= 1 && Math.Abs(Coordinates.Y - target.Coordinates.Y) <= 1)
            {
                target.HP -= 50;
            }
            else target.HP -= 100;
        }

    }
}