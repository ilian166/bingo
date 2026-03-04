using System;
using System.IO;

namespace Bingo
{
    internal class BingoJatekos
    {
        public string Nev { get; private set; }
        public int[,] Kartya = new int[5, 5];
        public bool[,] Talalatok = new bool[5, 5];

        public BingoJatekos(string fajlUtvonal)
        {
            this.Nev = Path.GetFileNameWithoutExtension(fajlUtvonal);
            string[] sorok = File.ReadAllLines(fajlUtvonal);

            for (int i = 0; i < 5; i++)
            {
                string[] elemek = sorok[i].Split(';');
                for (int j = 0; j < 5; j++)
                {
                    if (elemek[j] == "X")
                    {
                        Kartya[i, j] = -1; 
                        Talalatok[i, j] = true;
                    }
                    else
                    {
                        Kartya[i, j] = int.Parse(elemek[j]);
                        Talalatok[i, j] = false;
                    }
                }
            }
        }

        public void SorsoltSzamotJelol(int sorsoltSzam)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (Kartya[i, j] == sorsoltSzam)
                    {
                        Talalatok[i, j] = true;
                    }
                }
            }
        }

        public bool BingoEll()
        {
            for (int i = 0; i < 5; i++)
            {
                int sorDb = 0;
                int oszlopDb = 0;
                for (int j = 0; j < 5; j++)
                {
                    if (Talalatok[i, j]) sorDb++;
                    if (Talalatok[j, i]) oszlopDb++;
                }
                if (sorDb == 5 || oszlopDb == 5) return true;
            }

            int foAtlo = 0;
            int mellekAtlo = 0;
            for (int i = 0; i < 5; i++)
            {
                if (Talalatok[i, i]) foAtlo++;
                if (Talalatok[i, 4 - i]) mellekAtlo++;
            }

            return foAtlo == 5 || mellekAtlo == 5;
        }
    }
}