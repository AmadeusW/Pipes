using System;
using System.Collections.Generic;

namespace PipesExperiment
{
    internal abstract class GamePiece
    {
        public Position Position { get; private set; }
        public int Rotation { get; private set; }
        public bool Filled { get; private set; }

        public abstract char Render();
        public abstract List<Position> Next(Position previous);
    }

    internal class StraightPiece : GamePiece
    {
        public override List<Position> Next(Position previous)
        {
            switch (Rotation)
            {
                case 0:
                case 2:
                    return new List<Position>() { new Position(-previous.X, previous.Y) };
                case 1:
                case 3:
                    return new List<Position>() { new Position(previous.X, -previous.Y) };
                default:
                    throw new InvalidOperationException("Invalid rotation");
            }
        }

        public override char Render()
        {
            switch (Rotation)
            {
                case 0:
                case 2:
                    return '═';
                case 1:
                case 3:
                    return '║';
                default:
                    throw new InvalidOperationException("Invalid rotation");
            }
        }
    }

    internal class ElbowPiece : GamePiece
    {
        public override List<Position> Next(Position previous)
        {
            switch (Rotation)
            {
                case 0: // ╔
                    if (previous.X == 0 && previous.Y == 1)
                        return new List<Position>() { new Position(1, 0) };
                    if (previous.X == 1 && previous.Y == 0)
                        return new List<Position>() { new Position(0, 1) };
                    return null;
                case 1: // ╗
                    if (previous.X == 0 && previous.Y == 1)
                        return new List<Position>() { new Position(-1, 0) };
                    if (previous.X == -1 && previous.Y == 0)
                        return new List<Position>() { new Position(0, 1) };
                    return null;
                case 2: // ╝
                    if (previous.X == 0 && previous.Y == -1)
                        return new List<Position>() { new Position(-1, 0) };
                    if (previous.X == -1 && previous.Y == 0)
                        return new List<Position>() { new Position(0, -1) };
                    return null;
                case 3: // ╚
                    if (previous.X == 0 && previous.Y == -1)
                        return new List<Position>() { new Position(1, 0) };
                    if (previous.X == 1 && previous.Y == 0)
                        return new List<Position>() { new Position(0, -1) };
                    return null;
                default:
                    throw new InvalidOperationException("Invalid rotation");
            }
        }

        public override char Render()
        {
            switch (Rotation)
            {
                case 0:
                    return '╔';
                case 1:
                    return '╗';
                case 2:
                    return '╝';
                case 3:
                    return '╚';
                default:
                    throw new InvalidOperationException("Invalid rotation");
            }
        }
    }

    internal class TeePiece : GamePiece
    {
        public override List<Position> Next(Position previous)
        {
            switch (Rotation)
            {
                case 0: // ╠
                    if (previous.X == 0 && previous.Y == -1)
                        return new List<Position>() { new Position(1, 0), new Position(0, 1) };
                    if (previous.X == 1 && previous.Y == 0)
                        return new List<Position>() { new Position(0, -1), new Position(0, 1) };
                    if (previous.X == 0 && previous.Y == 1)
                        return new List<Position>() { new Position(1, 0), new Position(0, -1) };
                    return null;
                case 1: // ╩
                    if (previous.X == 0 && previous.Y == -1)
                        return new List<Position>() { new Position(-1, 0), new Position(1, 0) };
                    if (previous.X == 1 && previous.Y == 0)
                        return new List<Position>() { new Position(0, -1), new Position(-1, 0) };
                    if (previous.X == -1 && previous.Y == 0)
                        return new List<Position>() { new Position(0, -1), new Position(1, 0) };
                    return null;
                case 2: // ╣
                    if (previous.X == 0 && previous.Y == -1)
                        return new List<Position>() { new Position(-1, 0), new Position(0, 1) };
                    if (previous.X == -1 && previous.Y == 0)
                        return new List<Position>() { new Position(0, -1), new Position(0, 1) };
                    if (previous.X == 0 && previous.Y == 1)
                        return new List<Position>() { new Position(-1, 0), new Position(0, -1) };
                    return null;
                case 3: // ╦
                    if (previous.X == 0 && previous.Y == 1)
                        return new List<Position>() { new Position(-1, 0), new Position(1, 0) };
                    if (previous.X == 1 && previous.Y == 0)
                        return new List<Position>() { new Position(0, -1), new Position(1, 0) };
                    if (previous.X == -1 && previous.Y == 0)
                        return new List<Position>() { new Position(0, -1), new Position(1, 0) };
                    return null;
                default:
                    throw new InvalidOperationException("Invalid rotation");
            }
        }

        public override char Render()
        {
            switch (Rotation)
            {
                case 0:
                    return '╠';
                case 1:
                    return '╩';
                case 2:
                    return '╣';
                case 3:
                    return '╦';
                default:
                    throw new InvalidOperationException("Invalid rotation");
            }
        }
    }

    internal class CrossPiece : GamePiece
    {
        public override List<Position> Next(Position previous)
        {
            switch (Rotation)
            {
                case 0:
                case 1:
                case 2:
                case 3: // ╬
                    if (previous.X == 0 && previous.Y == 1)
                        return new List<Position>() { new Position(1, 0), new Position(-1, 0), new Position(0, -1), };
                    if (previous.X == 0 && previous.Y == -1)
                        return new List<Position>() { new Position(1, 0), new Position(-1, 0), new Position(0, 1), };
                    if (previous.X == 1 && previous.Y == 0)
                        return new List<Position>() { new Position(0, 1), new Position(-1, 0), new Position(0, -1), };
                    if (previous.X == -1 && previous.Y == 0)
                        return new List<Position>() { new Position(0, 1), new Position(1, 0), new Position(0, -1), };
                    return null;
                default:
                    throw new InvalidOperationException("Invalid rotation");
            }
        }

        public override char Render()
        {
            switch (Rotation)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    return '╬';
                default:
                    throw new InvalidOperationException("Invalid rotation");
            }
        }
    }

    internal class KnobPiece : GamePiece
    {
        public override List<Position> Next(Position previous)
        {
            switch (Rotation)
            {
                case 0:
                case 1:
                case 2:
                case 3: // █
                    return new List<Position>();
                default:
                    throw new InvalidOperationException("Invalid rotation");
            }
        }

        public override char Render()
        {
            switch (Rotation)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    return '█';
                default:
                    throw new InvalidOperationException("Invalid rotation");
            }
        }
    }

}