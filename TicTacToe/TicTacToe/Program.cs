using System;
using System.Collections.Generic;

namespace TicTacToe
{

    public class AvailableThings
    {
        public List<int> Player1 = new List<int>();
        public List<int> Player2 = new List<int>();

        public AvailableThings()
        {
            Player1.Add(1);
            Player1.Add(1);
            Player1.Add(2);
            Player1.Add(2);
            Player1.Add(3);
            Player1.Add(3);
            Player2.Add(3);
            Player2.Add(3);
            Player2.Add(2);
            Player2.Add(2);
            Player2.Add(1);
            Player2.Add(1);
        }

        public bool CheckLose()
        {
            if (Player1.Count == 0 && Player2.Count == 0)
                return true;
            return false;
        }

        public string GetAvailable(Player P)
        {
            string res = "";
            if (P == Player.First)
            {
                foreach (int q in Player1)
                {
                    res += Convert.ToString(q);
                    res += ", ";
                }
            }
            else
            {
                foreach (int q in Player2)
                {
                    res += Convert.ToString(q);
                    res += ", ";
                }
            }
            return res;
        }

        public void Returning(Player P, int weigth)
        {
            if (P == Player.First)
            {
                Player1.Add(weigth);
            }
            else
            {
                Player2.Add(weigth);

            }
        }

        public bool Placed(Player P, int weigth)
        {
            if(P==Player.First)
            {
                if(Player1.Exists(x=>x==weigth))
                {
                    Player1.Remove(Player1.Find(x => x == weigth));
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                if (Player2.Exists(x => x == weigth))
                {
                    Player2.Remove(Player1.Find(x => x == weigth));
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }

    

    class Program
    {
        public static void Show(Table A,Player P,AvailableThings T)
        {
            Console.WriteLine("Player "+(int)P);
            Console.WriteLine(A.row1[0].Num + "." + A.row1[0].Tek + " | " + A.row1[1].Num + "." + A.row1[1].Tek + " | " + A.row1[2].Num + "." + A.row1[2].Tek);
            Console.WriteLine(A.row2[0].Num + "." + A.row2[0].Tek + " | " + A.row2[1].Num + "." + A.row2[1].Tek + " | " + A.row2[2].Num + "." + A.row2[2].Tek);
            Console.WriteLine(A.row3[0].Num + "." + A.row3[0].Tek + " | " + A.row3[1].Num + "." + A.row3[1].Tek + " | " + A.row3[2].Num + "." + A.row3[2].Tek);
            Console.WriteLine("Available : " + T.GetAvailable(P));
        }

        public static Player NextTurn(Player P)
        {
            if (P == Player.First)
                return Player.Second;
            else
            {
                return Player.First;
            }
        }

        static void Main(string[] args)
        {
            Table A = new Table();
            AvailableThings T = new AvailableThings();
            Player Tek = Player.First;
            while(A.CheckWin()!=-1)
            {
                if (T.CheckLose())
                {
                    Console.WriteLine("Game over");
                }
                else
                {
                    try
                    {
                        Show(A, Tek,T);
                        int x;
                        int y;
                        int weight;
                        Console.WriteLine("Enter x");
                        x = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter y");
                        y = Convert.ToInt32(Console.ReadLine());
                        y--;
                        Console.WriteLine("Enter weight");
                        weight = Convert.ToInt32(Console.ReadLine());
                        if (T.Placed(Tek, weight))
                        {


                            if (A.SetFigure(x, y, Tek, weight))
                            {
                                if (A.CheckWin() == (int)Tek)
                                {
                                    Console.WriteLine("You won");
                                    return;
                                }
                                Tek = NextTurn(Tek);

                            }
                            else
                            {
                                Console.WriteLine("Incorrect Move, try again");
                                T.Returning(Tek, weight);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Incorrect Move, try again");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Incorrect Data, try again");
                    }
                }

            }
        }
    }
}
