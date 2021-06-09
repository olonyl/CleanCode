using System;
using System.Collections.Generic;
using System.Linq;
using IntentionRevealingNames.Implementations;

namespace IntentionRevealingNames
{
    class Program
    {
        static void Main(string[] args)
        {
            var GameBoard = new List<Cell >
            {
                new Cell{1,2,3,4,5},
                new Cell{4,4,13,34,45},
                new Cell{4,4,38,19,100}
            };
            var Game = new Game(GameBoard);
            foreach (var (item, index) in Game.GetFlaggedCells().Select((value, i) => (value, i)))
            {
                Console.WriteLine($"Cell in position {index} is Flagged and values are:");
                foreach (var cell in item)
                    Console.WriteLine($"-\t{cell}");
            }
        }
    }
}
