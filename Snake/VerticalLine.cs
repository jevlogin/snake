using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class VerticalLine
    {
        List<Point> pList;

        public VerticalLine(int xLeft, int yBeginning, int yEnd, char sym)
        {
            pList = new List<Point>();

            for (int y = yBeginning; y <= yEnd; y++)
            {
                Point p = new Point(xLeft, y, sym);
                pList.Add(p);
            }
        }
        public void Drow()
        {
            foreach (var p in pList)
            {
                p.Draw();
            }
        }
    }
}
