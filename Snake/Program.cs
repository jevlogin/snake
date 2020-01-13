using System;
using System.Collections.Generic;

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
        const int MINCHAR = 33; // 'символ !'
        const int MAXCHAR = 42; // 'символ *'
        const int MAXPOINT = 10; //  Сколько точек будет на экране
        const int MINXY = 0;
        const char HVLINE = '#';
        const int WIGHT = 50;
        const int HEIGHT = 20;

        static void Main(string[] args)
        {
            // Установил рамки окна консоли.. Важный момент, есть какие-то невидимые символы, 
            //  Подозреваю, что это символ переноса строки, поэтому граница чуть больше на 2 деления.
            Console.SetWindowSize(WIGHT + 2, HEIGHT + 2);
            Console.SetBufferSize(WIGHT + 2, HEIGHT + 2);

            HorizontalLine hLine = new HorizontalLine(MINXY, WIGHT, MINXY, HVLINE);
            hLine.Drow();
            hLine = new HorizontalLine(MINXY, WIGHT, HEIGHT, HVLINE);
            hLine.Drow();
            VerticalLine vLine = new VerticalLine(MINXY, MINXY, HEIGHT, HVLINE);
            vLine.Drow();
            vLine = new VerticalLine(WIGHT, MINXY, HEIGHT, HVLINE);
            vLine.Drow();

            Point p1 = new Point(4, 5, '*');
            Snake snake = new Snake(p1, 4, Direction.RIGHT);
            snake.Drow();

            Console.ReadKey();
        }

    }
}
