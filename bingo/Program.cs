namespace bingo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<BingoJatekos> jatekosok = new List<BingoJatekos>();

            string[] fajlnevek = File.ReadAllLines("nevek.text");

            foreach (string fajl in fajlnevek)
            {
                if (jatekosok.Count < 100)
                {
                    jatekosok.Add(new BingoJatekos(fajl));
                }
            }

            Console.WriteLine("4. feladat!");
            Console.WriteLine($"A regisztrált játékosok száma: {jatekosok.Count}");
        }
    }
}
