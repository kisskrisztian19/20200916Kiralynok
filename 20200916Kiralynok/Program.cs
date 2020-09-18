using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

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
                Random rnd = new Random(Guid.NewGuid().GetHashCode());
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
            public void FajlbaIr(StreamWriter fajl)
            {
                for (int i = 0; i < T.GetLength(0); i++)
                {
                    string sor = "";
                    for (int y = 0; y < T.GetLength(1); y++)
                    {
                        sor += T[i, y] + " ";
                    }
                    fajl.WriteLine(sor);
                } 
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
                while (i < T.GetLength(1) && T[i, oszlop] != 'K')
                {
                    i = i + 1;
                }
                if (i < T.GetLength(1))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            public bool UresSor(int sor)
            {
                int i = 0;
                while (i < T.GetLength(0) && T[sor, i] != 'K')
                {
                    i = i + 1;
                }
                if (i < T.GetLength(0))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        static void Main(string[] args)
        {
            //Üres tábla és létrehozások
            Console.WriteLine("Királynők feladat");
            Tabla t = new Tabla('#');
            Tabla[] tablak = new Tabla[64];
            Console.WriteLine("Üres tábla:");
            t.Megjelenit();

            //Fájlbaírás
            StreamWriter ki = new StreamWriter("Adatok.txt");
            for (int i = 0; i < 64; i++)
            {
                tablak[i] = new Tabla('*');
            }
            for (int i = 0; i < tablak.Length; i++)
            {
                tablak[i].Elhelyez(i + 1);
                tablak[i].FajlbaIr(ki);
                ki.WriteLine();
            }
            ki.Close();

            //Elhelyezés feladat
            t.Elhelyez(8);
            Console.WriteLine();
            t.Megjelenit();

            //Üres sor/oszlop feladat
            Console.WriteLine("Melyik sor: "); int szam = (int.Parse(Console.ReadLine())) - 1;
            t.UresSor(szam);
            if (t.UresSor(szam) == false)
            {
                Console.WriteLine($"A(z) {szam + 1}. sor nem üres.");
            }
            else
            {
                Console.WriteLine($"A(z) {szam + 1}. sor üres.");
            }
            Console.Write("Melyik oszlop: "); int szam1 = (int.Parse(Console.ReadLine())) - 1;
            t.UresOszlop(szam1);
            if (t.UresOszlop(szam1) == false)
            {
                Console.WriteLine($"A(z) {szam1 + 1}. oszlop üres.");
            }
            else
            {
                Console.WriteLine($"A(z) {szam1 + 1}. oszlop nem üres.");
            }

            //Üres sorok/oszlopok száma feladat
            int SorUres = 0, OszlopUres = 0;

            for (int i = 0; i < 8; i++)
            {
                if (t.UresSor(i))
                {
                    SorUres++;
                }

                if (t.UresOszlop(i))
                {
                    OszlopUres++;
                }
            }
            Console.WriteLine("8. Feladat: üres oszlopok és sorok száma:");
            Console.WriteLine($"Üres sorok: {SorUres}");
            Console.WriteLine($"Üres oszlopok: {OszlopUres}");

            Console.ReadKey();
        }
        
    }
}
