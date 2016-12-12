using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipesExperiment
{
    class Program
    {
        GameField game;

        static void Main(string[] args)
        {
            var game = new GameField(10, 10);
            game = game.WithAvailablePieces(straight: 5, elbow: 5, tee: 3, cross: 2, knob: 1);
            game = game.WithPlayedPieces(new ElbowPiece() { Position = new Position(6, 2), Rotation = 1 });
            game.Render();
            Console.ReadLine();
        }


    }
}
