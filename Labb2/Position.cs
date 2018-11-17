using System;

namespace Labb2 {

    public class Position {

        private int xPosition;
        private int yPosition;

        public int XPosition { get { return xPosition; } set { xPosition = value < 0 ? 0 : value; } }
        public int YPosition { get { return yPosition; } set { yPosition = value < 0 ? 0 : value; } }

        public Position(int xPosition, int yPosition)
        {
            XPosition = xPosition;
            YPosition = yPosition;
        }

        // Returnerar en double med avståndet från origo.
        public double Length()
        {
            double length = Math.Sqrt(Math.Pow(XPosition, 2) + Math.Pow(YPosition, 2));
            return length;
        }

        // Returnerar sant om inskrivna positionen är lika med X och Y.
        public bool Equals(Position p)
        {
            return (p.XPosition == XPosition && p.YPosition == YPosition);
        }

        // Returnerar en kopia av inskrivna kordinaten.
        public Position Clone()
        {
            return new Position(XPosition, YPosition);
        }

        // Returnerar en sträng i formatet: (X,Y)
        public override string ToString()
        {
            return "(" + XPosition + "," + YPosition + ")";
        }

        // Returnerar sant om första positionen ligger närmast origo.
        public static bool operator > (Position p1, Position p2)
        {
            if (p1.Length() > p2.Length())
            {
                return true;
            }
            return false;
        }

        //  Returnerar sant om andra positionen ligger närmast origo.
        public static bool operator < (Position p1, Position p2)
        {
            if (p1.Length() < p2.Length())
            {
                return true;
            }
            return false;
        }

        // Returnerar en ny kordinat, den första positionen plus den andra positionen.
        public static Position operator + (Position p1, Position p2)
        {
            return new Position(p1.XPosition + p2.XPosition, p1.YPosition + p2.YPosition);
        }

        // Om position 1 är mindre än position 2, returnera x2-x1 och y2-y1, annars returnera x1-x2 och y1-y2.
        public static Position operator - (Position p1, Position p2)
        {
            if (p1 < p2)
            {
                return new Position(p2.XPosition - p1.XPosition, p2.YPosition - p1.YPosition);
            }
            return new Position(p1.XPosition - p2.XPosition, p1.YPosition - p2.YPosition);
        }

        // Räknar ut avståndet mellan två positioner.
        public static double operator % (Position p1, Position p2)
        {
            return Math.Sqrt(Math.Pow(p1.XPosition - p2.XPosition, 2) + Math.Pow(p1.YPosition - p2.YPosition, 2));
        }

    }
}