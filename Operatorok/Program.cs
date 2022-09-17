using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Operatorok
{
    class Program
    {
        static List<Operatorok> operatorok = new List<Operatorok>();
        static Dictionary<string, int> stat = new Dictionary<string, int>();
        static void Main(string[] args)
        {
            ElsoFeladat();
            MasodikFeladat();
            HarmadikFeladat();
            NegyedikFeladat();
            OtodikFeladat();
            HetedikFeladat();
            NyolcadikFeladat();

            Console.ReadKey();
        }

        private static void NyolcadikFeladat()
        {
            Console.WriteLine("8. feladat: eredmenyek.txt");
            using (StreamWriter sw = new StreamWriter("eredmenyek.txt"))
            {
                foreach (var item in operatorok)
                {
                    sw.WriteLine($"{item.EgySor} = {Szamitas(item.EgySor)}");
                }
            }
        }

        private static void HetedikFeladat()
        {
            Console.Write("7. feladat: Kérek egy kifejezést (pl.: 1 + 1): ");
            string bekeres = Console.ReadLine();
            while (bekeres != "vége")
            {
                Console.WriteLine($"\t{bekeres} = {Szamitas(bekeres)}");
                Console.Write("7. feladat: Kérek egy kifejezést (pl.: 1 + 1): ");
                bekeres = Console.ReadLine();
            }
        }

        private static string Szamitas(string adat)
        {
            try
            {
                string[] adatok = adat.Split(' ');
                int szam1 = Convert.ToInt32(adatok[0]);
                string karakter = adatok[1];
                int szam2 = Convert.ToInt32(adatok[2]);

                if (karakter == "mod" || karakter == "/" || karakter == "div" || karakter == "-" || karakter == "*" || karakter == "+")
                {
                    if ((karakter == "mod" || karakter == "/" || karakter == "div") && szam2 == 0)
                    {
                        return "Egyéb hiba!";
                    }
                    else
                    {
                        switch (karakter)
                        {
                            case "mod":
                                return $"{szam1 % szam2}";
                            case "/":
                                return $"{(double)szam1 / (double)szam2}";
                            case "div":
                                return $"{szam1 / szam2}";
                            case "-":
                                return $"{szam1 - szam2}";
                            case "*":
                                return $"{szam1 * szam2}";
                            case "+":
                                return $"{szam1 + szam2}";
                            default:
                                return "Egyéb hiba!";
                        }
                    }
                }
                else
                {
                    return "Hibás operátor!";
                }
            }
            catch (Exception)
            {
                return "Egyéb hiba!";
            }
        }

        private static void OtodikFeladat()
        {
            Console.WriteLine("5. feladat: ");

            foreach (var item in operatorok)
            {
                if (item.Karakter == "mod" || item.Karakter == "/" || item.Karakter == "div" || item.Karakter == "-" || item.Karakter == "*" || item.Karakter == "+")
                {
                    if (stat.ContainsKey(item.Karakter))
                    {
                        stat[item.Karakter]++;
                    }
                    else
                    {
                        stat.Add(item.Karakter, 1);
                    }
                }
            }

            foreach (var item in stat)
            {
                Console.WriteLine($"\t{item.Key} -> {item.Value} db");
            }
        }

        private static void NegyedikFeladat()
        {
            Console.Write("4. feladat: ");

            bool van = false;
            int i = 0;
            while (!van && i < operatorok.Count)
            {
                if (operatorok[i].ElsoOperandus % 10 == 0 && operatorok[i].MasodikOperandus % 10 == 0)
                {
                    van = true;
                }
                i++;
            }

            if (van)
            {
                Console.WriteLine("Van ilyen kifejezés!");
            } 
            else
            {
                Console.WriteLine("Nincs ilyen kifejezés!");
            }
        }

        private static void HarmadikFeladat()
        {
            Console.WriteLine("3. feladat: Kifejezések maradékos osztással: " + operatorok.Count(i => i.Karakter == "mod"));
        }

        private static void MasodikFeladat()
        {
            Console.WriteLine("2. feladat: Kifejezések száma: " + operatorok.Count);
        }

        private static void ElsoFeladat()
        {
            FajlBeolvasas();
        }

        private static void FajlBeolvasas()
        {
            using (StreamReader sr = new StreamReader("kifejezesek.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string[] sor = sr.ReadLine().Split(' ');

                    operatorok.Add(new Operatorok(Convert.ToInt32(sor[0]), sor[1], Convert.ToInt32(sor[2])));
                }
            }
        }
    }
}
