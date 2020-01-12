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


            //  Для работы с рандомными числами...
            Random rnd = new Random();

            //  создаем список чисел по оси X
            List<int> numListX = new List<int>();
            //  Забиваем список числами
            for (int i = 0; i < MAXPOINT; i++)
            {
                numListX.Add(rnd.Next(1, WIGHT));
            }
            //  создаем список чисел по оси Y
            List<int> numListY = new List<int>();
            for (int i = 0; i < MAXPOINT; i++)
            {
                numListY.Add(rnd.Next(1, HEIGHT));
            }

            //  Создаем список символов
            List<char> charList = new List<char>();
            for (int i = MINCHAR; i <= MAXCHAR; i++)
            {
                charList.Add((char)i);  //  кастуем число к символу
            }

            List<Point> pList = new List<Point>();
            for (int i = 0; i < MAXPOINT; i++)
            {
                // Буду использовать анонимные точки (объекты, классы)
                pList.Add(new Point(numListX[i], numListY[i], charList[rnd.Next(i, charList.Count)]));
            }

            //  Выводим список точек на экран
            foreach (var p in pList)
            {
                p.Draw();
            }

            Console.ReadKey();
        }

    }
}
