using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Strategy.Domain.Models;

namespace Strategy.Domain
{
    /// <summary>
    /// Контроллер хода игры.
    /// </summary>
    public class GameController
    {
        private readonly Map _map;

        // Очки жизни каждого юнита.
        

       

        /// <inheritdoc />
        public GameController(Map map)
        {
            _map = map;
        }


        /// <summary>
        /// Получить координаты объекта.
        /// </summary>
        /// <param name="o">Координаты объекта, которые необходимо получить.</param>
        /// <returns>Координата x, координата y.</returns>
        public Coordinates GetObjectCoordinates(GameObject o)
        {
            return o.Coordinates;
        }
       
        /// <summary>
        /// Возвращает клетку с заданными координатами
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private Ground GetGround(int x, int y)
        {
            foreach (Ground g in _map.Ground)
            {
                if (g.Coordinates.Equals(new Coordinates(x, y)))
                {
                    return g;
                }
            }
            throw new Exception("Клетки с такими координатами не существует");
        }
        /// <summary>
        /// Может ли юнит передвинуться в указанную клетку.
        /// </summary>
        /// <param name="u">Юнит.</param>
        /// <param name="x">Координата X клетки.</param>
        /// <param name="y">Координата Y клетки.</param>
        /// <returns>
        /// <see langvalue="true" />, если юнит может переместиться
        /// <see langvalue="false" /> - иначе.
        /// </returns>
        /// 
        public bool CanMoveUnit(Unit u, int x, int y)
        {
            Ground ground = GetGround(x, y);
            return u.CanMove(ground);
           
        }

        /// <summary>
        /// Передвинуть юнита в указанную клетку.
        /// </summary>
        /// <param name="u">Юнит.</param>
        /// <param name="x">Координата X клетки.</param>
        /// <param name="y">Координата Y клетки.</param>
        public void MoveUnit(Unit u, int x, int y)
        {
            if (!CanMoveUnit(u, x, y))
                return;
            Ground groundOld = GetGround(u.Coordinates.X, u.Coordinates.Y);
            groundOld.HaveUnit = false;
            Ground groundNew = GetGround(x, y);
            groundNew.HaveUnit = true;
            u.Coordinates = new Coordinates(x, y);
        }

        /// <summary>
        /// Проверить, может ли один юнит атаковать другого.
        /// </summary>
        /// <param name="au">Юнит, который собирается совершить атаку.</param>
        /// <param name="tu">Юнит, который является целью.</param>
        /// <returns>
        /// <see langvalue="true" />, если атака возможна
        /// <see langvalue="false" /> - иначе.
        /// </returns>
        public bool CanAttackUnit(Unit au, Unit tu)
        {
            return au.CanAttack(tu);
        }

        /// <summary>
        /// Атаковать указанного юнита.
        /// </summary>
        /// <param name="au">Юнит, который собирается совершить атаку.</param>
        /// <param name="tu">Юнит, который является целью.</param>
        public void AttackUnit(Unit au, Unit tu)
        {
            au.Attack(tu);
        }

        /// <summary>
        /// Получить изображение объекта.
        /// </summary>
        public ImageSource GetObjectSource(GameObject o)
        {
            if (o is Unit)
            {
                Unit u = o as Unit;
                if (u.IsDead) return u.DeadUnitSourse;
            }
            return o.ImageSource;
        }

        /// <summary>
        /// Проверить, что указанный юнит умер.
        /// </summary>
        /// <param name="u">Юнит.</param>
        /// <returns>
        /// <see langvalue="true" />, если у юнита не осталось очков здоровья,
        /// <see langvalue="false" /> - иначе.
        /// </returns>
        private bool IsDead(Unit u)
        {
            return u.IsDead;
        }

        
       
        
    }
}