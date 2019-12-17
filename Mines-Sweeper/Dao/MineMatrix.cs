﻿using System;
using System.Collections.Generic;
using System.Linq;
using Mines_Sweeper.Classes;
using Mines_Sweeper.Const;

namespace Mines_Sweeper.Dao
{
    public class MineMatrix
    {
        public GameStatus Status;
        public string Token;
        public int Bombs;
        public int Height;
        public int Width;
        public Dictionary<int, Cell> Matrix;

        public MineMatrix(int height, int width, int bombs,string token)
        {
            Height = height;
            Width = width;
            Bombs = bombs;
            Token = token;
            Status = GameStatus.PLAYING;

            int[] bpositions = GenerateBombsPositions(height, width, bombs);
            Matrix = GenerateMatrix(height, width, bpositions);

        }

        private Dictionary<int,Cell> GenerateMatrix(int x, int y, int[] bombsPositions)
        {
            Dictionary<int, Cell> matrixToReturn = new Dictionary<int, Cell>();
            int maxPosition = x * y;

            for (int i = 0; i < maxPosition; i++)
            {
                Cell cell = new Cell();
                if (bombsPositions.Any(x => x == i))
                {
                    cell.Type = CellType.BOMB;
                }

                matrixToReturn.Add(i, cell);
            }

            return matrixToReturn;
        }

        private int[] GenerateBombsPositions(int x,int y,int bombs)
        {
            List<int> positions = new List<int>();
            int maxPosition = x * y;

            Random rand = new Random((int)DateTime.Now.Ticks);
            for (int i = 0; i < bombs; i++)
            {
                int pos = rand.Next(maxPosition);
                positions.Add(pos);
            }

            //TODO validate that bombs positions are not repeated.

            return positions.ToArray();
         }
     }
}
