using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Bingo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<BingoJatekos> jatekosok = new List<BingoJatekos>();
            if (File.Exists("nevek.text"))
            {
                string[] fajlok = File.ReadAllLines("nevek.text");
                foreach (var fajl in fajlok)
                {
                    if (jatekosok.Count < 100 && File.Exists(fajl)) 
                    {
                        jatekosok.Add(new BingoJatekos(fajl));
                    }
                }
            }

            Console.WriteLine("4. feladat!");
            Console.WriteLine($"A regisztrált játékosok száma: {jatekosok.Count}");

            Console.WriteLine("\n7. feladat!");
            Random rnd = new Random();
            List<int> sorszamok = Enumerable.Range(1, 75).OrderBy(x => rnd.Next()).ToList();
            bool vanNyertes = false;
            int kor = 0;

            while (!vanNyertes && kor < sorszamok.Count)
            {
                int huzott = sorszamok[kor];
                Console.WriteLine($"{kor + 1,2}. sorszám: {huzott,2}"); 

                foreach (var jatekos in jatekosok)
                {
                    jatekos.SorsoltSzamotJelol(huzott);
                    if (jatekos.BingoEll()) vanNyertes = true;
                }
                kor++;
            }

            Console.WriteLine("\n8. feladat!");
            foreach (var jatekos in jatekosok)
            {
                if (jatekos.BingoEll())
                {
                    Console.WriteLine($"Név: {jatekos.Nev}");
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            if (jatekos.Talalatok[i, j])
                            {
                                string ki = (jatekos.Kartya[i, j] == -1) ? "X" : jatekos.Kartya[i, j].ToString();
                                Console.Write($"{ki,3}");
                            }
                            else
                            {
                                Console.Write($"{"0",3}");
                            }
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                }
            }

            Console.ReadKey();
        }
    }
}