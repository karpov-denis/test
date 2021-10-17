using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public class Table
    {
        public Plate[] row1;
        public Plate[] row2;
        public Plate[] row3;

        public Table()
        {
            row1 = new Plate[3] { new Plate(), new Plate(), new Plate() };
            row2 = new Plate[3] { new Plate(), new Plate(), new Plate() };
            row3 = new Plate[3] { new Plate(), new Plate(), new Plate() };
        }

        public int CheckWin()
        {
            if (row1[0].Tek == row1[1].Tek && row1[1].Tek == row1[2].Tek && (int)row1[0].Tek != 0)
                return (int)row1[0].Tek;
            if (row2[0].Tek == row2[1].Tek && row2[1].Tek == row2[2].Tek && (int)row2[0].Tek != 0)
                return (int)row2[0].Tek;
            if (row3[0].Tek == row3[1].Tek && row3[1].Tek == row3[2].Tek && (int)row3[0].Tek != 0)
                return (int)row3[0].Tek;
            if (row1[0].Tek == row2[0].Tek && row2[0].Tek == row3[0].Tek && (int)row1[0].Tek != 0)
                return (int)row1[0].Tek;
            if (row1[1].Tek == row2[1].Tek && row2[1].Tek == row3[1].Tek && (int)row1[1].Tek != 0)
                return (int)row1[1].Tek;
            if (row1[2].Tek == row2[2].Tek && row2[2].Tek == row3[2].Tek && (int)row1[2].Tek != 0)
                return (int)row1[2].Tek;
            if (row1[0].Tek == row2[1].Tek && row2[1].Tek == row3[2].Tek && (int)row1[0].Tek != 0)
                return (int)row1[0].Tek;
            if (row1[2].Tek == row2[1].Tek && row2[1].Tek == row3[0].Tek && (int)row1[2].Tek != 0)
                return (int)row1[2].Tek;
            if (row1[0].Tek != Player.None && row1[1].Tek != Player.None && row1[2].Tek != Player.None &&
                row2[0].Tek != Player.None && row2[1].Tek != Player.None && row2[2].Tek != Player.None &&
                row3[0].Tek != Player.None && row3[1].Tek != Player.None && row3[2].Tek != Player.None) //закончились поля
                return -1;
            else
                return 0;

        }

        public bool IsFigureWeightExist(int weight)
        {
            weight--; // мы можем ставить на один больше
            foreach (Plate a in row1)
            {
                if (a.Num >= weight)
                    return true;
            }
            foreach (Plate a in row2)
            {
                if (a.Num >= weight)
                    return true;
            }
            foreach (Plate a in row3)
            {
                if (a.Num >= weight)
                    return true;
            }
            return false;
        }
        public bool SetFigure(int x, int y, Player P, int weight)
        {
            if (IsFigureWeightExist(weight))
            {
                if (x == 1 && row1[y].Num < weight)
                {
                    row1[y].Num = weight;
                    row1[y].Tek = P;
                    return true;
                }
                if (x == 2 && row2[y].Num < weight)
                {
                    row2[y].Num = weight;
                    row2[y].Tek = P;
                    return true;
                }
                if (x == 3 && row3[y].Num < weight)
                {
                    row3[y].Num = weight;
                    row3[y].Tek = P;
                    return true;
                }
            }
            return false;
        }
    }
}
