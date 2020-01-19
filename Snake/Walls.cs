using System;
using System.Collections.Generic;

namespace Snake
{
    internal class Walls
    {
        const int MINXY = 0;
        const char SYM = '*';

        List<Figure> wallList;

        public Walls(int mapWidth, int mapHeight)
        {
            wallList = new List<Figure>();

            HorizontalLine upLine = new HorizontalLine(MINXY, mapWidth, MINXY, SYM);
            HorizontalLine downLine = new HorizontalLine(MINXY, mapWidth, mapHeight, SYM);
            VerticalLine leftLine = new VerticalLine(MINXY, MINXY, mapHeight, SYM);
            VerticalLine rightLine = new VerticalLine(mapWidth, MINXY, mapHeight, SYM);

            wallList.Add(upLine);
            wallList.Add(downLine);
            wallList.Add(leftLine);
            wallList.Add(rightLine);
        }


        public void Draw()
        {
            foreach (var wall in wallList)
            {
                wall.Draw();
            }
        }

        internal bool IsHit(Figure figure)
        {
            foreach (var wall in wallList)
            {
                if (wall.IsHit(figure))
                {
                    return true;
                }
            }
            return false;
        }
    }
}