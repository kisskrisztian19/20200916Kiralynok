using System;

namespace _20200916Kiralynok
{
    class Program
    {
        class Tabla
        {
            char[,] T;
            char UresCella;
            int UresoszlopokSzama, UressorokSzama;
            public void Elhelyez()
            {

            }
            public void FajlbaIr()
            {

            }
            public void Megjelenit()
            {
                for (int i = 0; i < T.GetLength(0); i++)
                {
                    for (int y = 0; y < T.GetLength(1); y++)
                    {
                        Console.Write(T[i, y] + " ");
                    }
                    Console.WriteLine();
                }
            }
            public Tabla(char ch)
            {
                T = new char[8, 8];
                UresCella = ch;
                for (int i = 0; i < T.GetLength(0); i++)
                {
                    for (int y = 0; y < T.GetLength(1); y++)
                    {
                        T[i, y] = UresCella;
                    }
                }
            }
            public int UresOszlop()
            {
                return 0;
            }
            public int UresSor()
            {
                return 0;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Királynők feladat");
            Tabla t = new Tabla('#');
            Console.WriteLine("Üres tábla:");
            t.Megjelenit();
            Console.ReadKey();
        }
    }
}
