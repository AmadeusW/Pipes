using System;
using System.Collections.Generic;
using System.Linq;

namespace PipesExperiment
{
    internal class GameField
    {
        private readonly int width, height;
        private readonly List<GamePiece> availablePieces;
        private readonly List<GamePiece> playedPieces;

        public GameField(int width, int height, List<GamePiece> availablePieces = null, List<GamePiece> playedPieces = null)
        {
            this.width = width;
            this.height = height;
            this.availablePieces = availablePieces ?? new List<GamePiece>();
            this.playedPieces = playedPieces ?? new List<GamePiece>();
        }

        internal void Render()
        {
            int offsetX = 1;
            int offsetY = 1;

            foreach (var piece in playedPieces)
            {
                Console.SetCursorPosition(offsetX + piece.Position.X, offsetY + piece.Position.Y);
                piece.Render();
            }

            offsetX = 3 + width;
            offsetY = 1;

            foreach (var piece in availablePieces.GroupBy(n => n.GetType()))
            {
                Console.SetCursorPosition(offsetX, offsetY);
                piece.First().Render();
                Console.Write(piece.Count());
                offsetY++;
            }
            
        }

        internal GameField WithAvailablePieces(int straight, int elbow, int tee, int cross, int knob)
        {
            var newPieces = new List<GamePiece>(availablePieces);

            for (int i = 0; i < straight; i++)
                newPieces.Add(new StraightPiece());
            for (int i = 0; i < elbow; i++)
                newPieces.Add(new ElbowPiece());
            for (int i = 0; i < tee; i++)
                newPieces.Add(new TeePiece());
            for (int i = 0; i < cross; i++)
                newPieces.Add(new CrossPiece());
            for (int i = 0; i < knob; i++)
                newPieces.Add(new KnobPiece());

            return new GameField(width, height, newPieces);
        }
    }
}