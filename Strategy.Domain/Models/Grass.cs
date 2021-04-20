namespace Strategy.Domain.Models
{
    /// <summary>
    /// Проходимая поверхность на земле.
    /// </summary>
    public sealed class Grass:Ground
    {
        /// <inheritdoc />
        public Grass(int x, int y):base(x, y)
        {
            CanMove = true;
            HaveUnit = false;
            ImageSource = BuildSourceFromPath("Resources/Ground/Grass.png");
        }
        public Grass():base()
        {
            CanMove = true;
            HaveUnit = false;
            ImageSource = BuildSourceFromPath("Resources/Ground/Grass.png");
        }
       
    }
}