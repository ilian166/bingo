using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bingo
{
    internal class BingoJatekos
    {
        public string Nev;
        public int[,] Kartya = new int[5, 5];
        public bool[,] Talalatok = new bool[5, 5];

        public BingoJatekos(string filenev)
        {
            this.Nev = Path.GetFileNameWithoutExtension(filenev);
            string[] sorok = File.ReadAllLines(filenev);

            for (int i = 0; i < 5; i++)
            {
                string[] elemek = sorok[i].Split(';');
                for (int j = 0; j < 5; j++)
                {
                    if (elemek[j] == "X")
                    {
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
    }
}
