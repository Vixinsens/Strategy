namespace Strategy.Domain.Models
{
    /// <summary>
    /// Непроходимая наземная поверхность.
    /// </summary>
    public sealed class Water:Ground
    {
        /// <inheritdoc />
        public Water(int x, int y):base(x, y)
        {
            CanMove = false;
            HaveUnit = false;
            ImageSource = BuildSourceFromPath("Resources/Ground/Water.png");
        }
        public Water() : base()
        {
            CanMove = false;
            HaveUnit = false;
            ImageSource = BuildSourceFromPath("Resources/Ground/Water.png");
        }
       
    }
}