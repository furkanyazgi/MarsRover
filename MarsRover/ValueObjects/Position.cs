using System;
using System.Collections.Generic;
using MarsRover.Interfaces;

namespace MarsRover.ValueObjects
{
    public class Position:IPosition
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Directions Direction { get; set; }

        public Position()
        {
            X = Y = 0;
            Direction = Directions.N;
        }

        private void Rotate90DegreeLeft()
        {
            switch (Direction)
            {
                case Directions.N:
                    Direction = Directions.W;
                    break;
                case Directions.S:
                    Direction = Directions.E;
                    break;
                case Directions.E:
                    Direction = Directions.N;
                    break;
                case Directions.W:
                    Direction = Directions.S;
                    break;
            }
        }

        private void Rotate90DegreeRight()
        {
            switch (Direction)
            {
                case Directions.N:
                    Direction = Directions.E;
                    break;
                case Directions.S:
                    Direction = Directions.W;
                    break;
                case Directions.E:
                    Direction = Directions.S;
                    break;
                case Directions.W:
                    Direction = Directions.N;
                    break;
            }
        }

        private void MoveInSameDirection()
        {
            switch (Direction)
            {
                case Directions.N:
                    Y += 1;
                    break;
                case Directions.S:
                    Y -= 1;
                    break;
                case Directions.E:
                    X += 1;
                    break;
                case Directions.W:
                    X -= 1;
                    break;
            }
        }

        public void StartMoving(List<int> maxPoints, string moves)
        {
            foreach (var move in moves)
            {
                switch (move)
                {
                    case 'M':
                        MoveInSameDirection();
                        break;
                    case 'L':
                        Rotate90DegreeLeft();
                        break;
                    case 'R':
                        Rotate90DegreeRight();
                        break;
                    default:
                        Console.WriteLine($"Invalid Character {move}");
                        break;
                }

                if (X < 0 || X > maxPoints[0] || Y < 0 || Y > maxPoints[1])
                {
                    throw new Exception($"Position can not be beyond bounderies (0 , 0) and ({maxPoints[0]} , {maxPoints[1]})");
                }
            }
        }
    }
}
