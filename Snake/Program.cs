using System;
using System.Collections.Generic;
using System.Threading;

/*
 * 
 * Евгений Логинов, 
 * 89013827902
 * JEVLOGIN * <-- Ник во всех сетях. Например vk.com/jevlogin
 * студент 
 * Факультет
 * Geek University разработки игр
 * 
 */

namespace Snake
{
    class Program
    {
        const int MINXY = 0;
        const char HVLINE = '*';
        const int WIDTH = 100;
        const int HEIGHT = 40;

        static void Main(string[] args)
        {
            // Установил рамки окна консоли.. Важный момент, есть какие-то невидимые символы, 
            //  Подозреваю, что это символ переноса строки, поэтому граница чуть больше на 2 деления.
            Console.SetWindowSize(WIDTH + 2, HEIGHT + 2);
            Console.SetBufferSize(WIDTH + 2, HEIGHT + 2);

            //  отрисовка рамки
            HorizontalLine upLine = new HorizontalLine(MINXY, WIDTH, MINXY, HVLINE);
            HorizontalLine downLine = new HorizontalLine(MINXY, WIDTH, HEIGHT, HVLINE);
            VerticalLine leftLine = new VerticalLine(MINXY, MINXY, HEIGHT, HVLINE);
            VerticalLine rightLine = new VerticalLine(WIDTH, MINXY, HEIGHT, HVLINE);
            
            //upLine.Draw();
            //downLine.Draw();
            //leftLine.Draw();
            //rightLine.Draw();

            Point p1 = new Point(4, 5, '*');
            Snake snake = new Snake(p1, 4, Direction.RIGHT);

            //  создали фигуру змейка
            //Snake fSnake = new Snake(p1, 4, Direction.RIGHT);
            //  отрисовали фигуру змейка
            //Draw(fSnake);
            //  явно привели фигуру к типу змейка
            //Snake snake = (Snake)fSnake;
            //snake.Draw(); //нам не зачем  больше рисовать змейку через объект змейки.

            FoodCreator foodCreator = new FoodCreator(WIDTH, HEIGHT, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();

            //  Создаем список фигур
            List<Figure> figures = new List<Figure>();
            //  Добавили змейку, верхнюю линию, нижнюю, левую, правую.
            figures.Add(snake);
            figures.Add(upLine);
            figures.Add(downLine);
            figures.Add(leftLine);
            figures.Add(rightLine);
            //  а вот еду не получится добавить, потому что она не является наследником класса фигура
            // figures.Add(food);

            foreach (var f in figures)
            {
                f.Draw();
            }

            

            while (true)
            {
                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    food.Draw();
                }
                else
                {
                    snake.Move();
                }
                
                Thread.Sleep(100);

                if (Console.KeyAvailable)
                {
                    //  Читаем клавишу нажатую пользователем
                    ConsoleKeyInfo key = Console.ReadKey();
                    //  Передаем клавишу в класс Snake для обработки
                    snake.HandleKey(key.Key);
                }
            }
        }

        private static void Draw(Figure figure)
        {
            figure.Draw();
        }
    }
}
