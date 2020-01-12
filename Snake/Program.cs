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
        const int MAXPOINT = 4; //  Сколько точек будет на экране
        const int MINXY = 0;
        const int MAXXY = 11;
        const char HVLINE = '@';

        static void Main(string[] args)
        {
            //  Временно убираю такую реализацию... 
            //  Буду использовать анонимные точки (объекты, классы)
            //Point p1 = new Point(1, 3, '*');
            //Point p2 = new Point(4, 5, '#');

            HorizontalLine hLine = new HorizontalLine(MINXY, MAXXY, MINXY, HVLINE);
            hLine.Drow();
            hLine = new HorizontalLine(MINXY, MAXXY, MAXXY, HVLINE);
            hLine.Drow();
            VerticalLine vLine = new VerticalLine(MINXY, MINXY, MAXXY, HVLINE);
            vLine.Drow();
            vLine = new VerticalLine(MAXXY, MINXY, MAXXY, HVLINE);
            vLine.Drow();


            //  Для работы с рандомными числами...
            Random rnd = new Random();

            List<int> numlist = new List<int>();
            //  Забиваем список числами
            for (int i = 0; i < MAXPOINT * 2; i++)
            {
                numlist.Add(rnd.Next(1, 10));
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
                pList.Add(new Point(numlist[i], numlist[i + 1], charList[rnd.Next(i, charList.Count)]));
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
