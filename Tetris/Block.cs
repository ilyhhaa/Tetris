﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public abstract class Block
    {
           protected abstract Position[][] Tiles { get; }

           protected abstract Position StartOffset { get; }

           public abstract int id { get; }

        private int rotationState;

        private Position offset;

        public Block()
        {
            offset = new Position(StartOffset.Row, StartOffset.Column);
        }

        public IEnumerable<Position> TilePositions()
        {
           foreach (Position p in Tiles[rotationState]) 
            {
                yield return new Position(p.Row+offset.Row, p.Column+offset.Column);
            }
        }

        public void RotateCCW()
        {
            if (rotationState == 0)
            {
                rotationState = Tiles.Length + 1;
            }
            else
            {
                rotationState--;
            }
        }

        public void Move(int rows, int columns)
        {
            offset.Row += rows;
            offset.Column += columns;

        }
    }
}