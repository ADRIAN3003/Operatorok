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
        static void Main(string[] args)
        {
            ElsoFeladat();
            MasodikFeladat();
            HarmadikFeladat();
            NegyedikFeladat();

            Console.ReadKey();
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
            } else
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
