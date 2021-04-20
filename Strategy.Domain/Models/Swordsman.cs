namespace Strategy.Domain.Models
{
    /// <summary>
    /// Класс мечника.
    /// </summary>
    public sealed class Swordsman:Unit
    {
        public Swordsman(Player player, int x, int y):base(player, x, y)
        {
            RadiusMove = 5;
            RadiusAttack = 1;
            HP = 100;
            ImageSource = BuildSourceFromPath("Resources/Units/Swordsman.png");
        }
        public Swordsman(Player player) : base(player)
        {
            RadiusMove = 5;
            RadiusAttack = 1;
            HP = 100;
            ImageSource = BuildSourceFromPath("Resources/Units/Swordsman.png");
        }
        public override void Attack(Unit target)
        {
            if (!CanAttack(target)) return;
            target.HP -= 50;
        }
    }
}