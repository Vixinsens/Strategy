namespace Strategy.Domain.Models
{
    /// <summary>
    /// Класс всадника.
    /// </summary>
    public sealed class Horseman:Unit
    {
        /// <inheritdoc />
        public Horseman(Player player, int x, int y):base(player, x, y)
        {
            RadiusMove = 10;
            RadiusAttack = 1;
            HP = 200;
            ImageSource= BuildSourceFromPath("Resources/Units/Horseman.png");
        }
        public Horseman(Player player) : base(player)
        {
            RadiusMove = 10;
            RadiusAttack = 1;
            HP = 200;
            ImageSource = BuildSourceFromPath("Resources/Units/Horseman.png");
        }
        public override void Attack(Unit target)
        {
            if (!CanAttack(target)) return;
            target.HP -= 75;
        }

    }
}