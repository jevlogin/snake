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
            upLine.Draw();
            downLine.Draw();
            leftLine.Draw();
            rightLine.Draw();

            Point p1 = new Point(4, 5, '*');
            Snake snake = new Snake(p1, 4, Direction.RIGHT);
            snake.Draw();

            FoodCreator foodCreator = new FoodCreator(WIDTH, HEIGHT, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();

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
    }
}
