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
            public void Elhelyez(int N)
            {
                Random rnd = new Random();
                for (int i = 0; i < N; i++)
                {
                    int sor = rnd.Next(0, 8);
                    int oszlop = rnd.Next(0, 8);
                    while (T[sor, oszlop] == 'K')
                    {
                        sor = rnd.Next(0, 8);
                        oszlop = rnd.Next(0, 8);
                    }
                    T[sor, oszlop] = 'K';   
                } 
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
            public bool UresOszlop(int oszlop)
            {
                int i = 0;
                while (i< T.GetLength(1) && T[i, oszlop] == '#')
                {
                    i += 1;
                }
                if (i < T.GetLength(1))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool UresSor(int sor)
            {
                int i = 0;
                while (i < T.GetLength(0) && T[sor, i] == '#')
                {
                    i += 1;
                }
                if (i < T.GetLength(0))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Királynők feladat");
            Tabla t = new Tabla('#');
            Console.WriteLine("Üres tábla:");
            t.Megjelenit();
            t.Elhelyez(8);
            Console.WriteLine();
            t.Megjelenit();
            Console.WriteLine("Melyik sor: "); int szam = int.Parse(Console.ReadLine())-1;
            t.UresSor(szam);
            if (t.UresSor(szam) == true)
            {
                Console.WriteLine($"A(z) {szam}. sor üres.");
            }
            else
            {
                Console.WriteLine($"A(z) {szam}. sor nem üres.");
            }
            Console.ReadKey();
        }
    }
}
