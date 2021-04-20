using System.Collections.Generic;
using System;

namespace Strategy.Domain.Models
{
    /// <summary>
    /// Карта.
    /// </summary>
    public sealed class Map
    {
        /// <inheritdoc />
        public Map(IReadOnlyList<Ground> ground, IReadOnlyList<Unit> units)
        {
            Ground = ground;
            Units = units;
            if (Ground == null || Units == null) return;
            foreach (Unit unit in Units)
            {
               Ground g = GetGround(unit.Coordinates.X, unit.Coordinates.Y);
                if (g == null) return;
                if (!g.CanMove)
                {
                    throw new Exception("В данной клетке нельзя передвигаться");
                }
                if (g.HaveUnit)
                {
                    throw new Exception("В данной клетке уже есть юнит");
                }
                g.HaveUnit = true;
            }
        }
        private Ground GetGround(int x, int y)
        {
            foreach (Ground ground in Ground)
            {
                if (ground.Coordinates.X==x && ground.Coordinates.Y == y)
                {
                    return ground;
                }
            }
            return null;
        }

        /// <summary>
        /// Поверхность под ногами.
        /// </summary>
        public IReadOnlyList<Ground> Ground { get; }

        /// <summary>
        /// Список юнитов.
        /// </summary>
        public IReadOnlyList<Unit> Units { get; }
    }
}