namespace Strategy.Domain.Models
{
    /// <summary>
    /// Координаты на карте.
    /// </summary>
    public sealed class Coordinates
    {
        /// <inheritdoc />
        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }


        /// <summary>
        /// Координата X.
        /// </summary>
        public int X { get; }

        /// <summary>
        /// Координата Y.
        /// </summary>
        public int Y { get; }


        /// <inheritdoc />
        public bool Equals(Coordinates obj)
        {
            if (X == obj.X && Y == obj.Y) return true;
            else return false;
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }

        /// <summary>
        /// Проверить на равенство с другим объектом.
        /// </summary>
       
    }
}