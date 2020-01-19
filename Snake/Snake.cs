using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Snake : Figure
    {
        Direction direction;
        public Snake(Point tail, int length, Direction direction)
        {
            this.direction = direction;
            pList = new List<Point>();

            for (int i = 0; i < length; i++)
            {
                Point p = new Point(tail);
                p.Move(i, this.direction);
                pList.Add(p);
            }
        }

        internal void Move()
        {
            //  получили значение хвоста
            Point tail = pList.First();
            //  удалили из списка, точку хвоста
            pList.Remove(tail);
            //  Получаем новую точку головы
            Point head = GetNextPoint();
            //  Добавили голову в список, в змейку
            pList.Add(head);

            //  Стираем хвост
            tail.Clear();
            //  Нарисовали новую точку головы... змейки. Здесь мы рисуем просто точку... но это есть змейка ))
            head.Draw();
        }

        private Point GetNextPoint()
        {
            //  Получили координаты головы (последней точки, или "первой")
            Point head = pList.Last();
            //  Создали новую точку на основании предыдущей головы
            Point nextPoint = new Point(head);
            //  Сдвинули новую точку, на 1 единицу. Тем самым реализовав сдвиг
            nextPoint.Move(1, direction);
            //  Вернули значение новой точки
            return nextPoint;
        }

        internal bool IsHitTail()
        {
            var head = pList.Last();
            for (int i = 0; i < pList.Count - 2; i++)
            {
                if (head.IsHit(pList[i]))
                {
                    return true;
                }
            }
            return false;
        }

        public void HandleKey(ConsoleKey key)
        {
            if (key == ConsoleKey.LeftArrow)
            {
                direction = Direction.LEFT;
            }
            else if (key == ConsoleKey.RightArrow)
            {
                direction = Direction.RIGHT;
            }
            else if (key == ConsoleKey.UpArrow)
            {
                direction = Direction.UP;
            }
            else if (key == ConsoleKey.DownArrow)
            {
                direction = Direction.DOWN;
            }
        }

        public bool Eat(Point food)
        {
            Point head = GetNextPoint();
            if (head.IsHit(food))
            {
                food.sym = head.sym;
                pList.Add(food);
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
