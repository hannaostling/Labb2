using System;
using System.Collections.Generic;
using System.Linq;

namespace Labb2
{
    public class SortedPosList
    {
        // Lista "Positions" privat eftersom den endast ska användas i den här klassen.
        private List<Position> Positions { get; set; }

        // Sorterad lista efter positioner.
        public SortedPosList() { Positions = new List<Position>(); }

        // Returnerar listan som sträng med ett kommatecken mellan kordinaterna.
        public override string ToString() { return string.Join(",", Positions); }

        // Returnerar antalet positioner som finns i listan.
        public int Count() { return Positions.Count; }

        // Lägger till en position till listan, och hamnar på rätt ställe i listan (sorteras på avstånd till origo).
        public void Add(Position p)
        {
            for (int i = 0; i < Count(); i++)
            {
                if (Positions[i].Length() > p.Length())
                {
                    Positions.Insert(i, p);
                    return;
                }
            }
            Positions.Insert(Count(), p);
        }

        // Tar bort en positoin från listan. Returnerar sant om positionen fanns i listan och togs bort.
        public bool Remove(Position p)
        {
            for (int i = 0; i < Count(); i++)
            {
                if (p.XPosition == Positions[i].XPosition && p.YPosition == Positions[i].YPosition)
                {
                    Positions.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        // Returnerar en ny instans av SortedPosList, som innehåller kopior av alla punkter som finns i listan. Gör en deep clone.
        public SortedPosList Clone()
        {
            SortedPosList posList = new SortedPosList();
            foreach (Position position in Positions)
            {
                posList.Add(position.Clone());
            }
            return posList;
        }

        // Returnerar en ny lista som innehåller alla positioner som befinner sig inom en given cirkel.
        public SortedPosList CircleContent(Position centerPosition, double radius)
        {
            SortedPosList circleContList = new SortedPosList();
            foreach (Position position in Positions)
            {
                if (Math.Pow((position.XPosition - centerPosition.XPosition), 2) + Math.Pow((position.YPosition - centerPosition.YPosition), 2) < Math.Pow(radius, 2))
                {
                    circleContList.Add(position.Clone());
                }
            }
            return circleContList;
        }

        // Returnerar en ny lista som är två listor ihopslagna till en lista.
        public static SortedPosList operator +(SortedPosList list1, SortedPosList list2)
        {
            SortedPosList sortedPosList = new SortedPosList();
            foreach (Position position in list1.Positions)
            {
                sortedPosList.Add(position.Clone());
            }
            foreach (Position position in list2.Positions)
            {
                sortedPosList.Add(position.Clone());
            }
            return sortedPosList;
        }

        // Hämta ett element på en given position i listan.
        public Position this[int index] => Positions[index];

    }
}