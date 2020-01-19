using System;

namespace Snake
{
    class Point
    {
        //private int x;
        //private int y;
        //  Временно делаем поля открытыми
        public int x;
        public int y;
        public char sym;

        public Point()
        {

        }

        public Point(Point p)
        {
            x = p.x;
            y = p.y;
            sym = p.sym;
        }

        public Point(int x, int y, char sym)
        {
            this.x = x;
            this.y = y;
            this.sym = sym;
        }

        //  Функция смещения. (метод)
        public void Move(int offset, Direction direction)
        {
            if (direction == Direction.RIGHT)
            {
                x += offset;
            }
            else if (direction == Direction.LEFT)
            {
                x -= offset;
            }
            else if (direction == Direction.UP)
            {
                y -= offset;
            }
            else if (direction == Direction.DOWN)
            {
                y += offset;
            }
        }

        internal void Clear()
        {
            this.sym = ' ';
            Draw();
        }

        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
        }

        public override string ToString()
        {
            return x + ", " + y + ", " + sym;
        }

        internal bool IsHit(Point food)
        {
            return food.x == this.x && food.y == this.y;
        }
    }

}
