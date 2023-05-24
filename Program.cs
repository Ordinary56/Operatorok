//usng System;
//using System.Collection.Generics;
//using System.Linq;
namespace LINQ_assignment
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<int> napiCsapadek = new();
            List<string> versenyzok = new()
            {
                "Kovács-Béla",
                "Gipsz-Jakab",
                "Papp-András",
                "Varga-Katalin",
                "Szabó-Péter",
                "Kiss-Ádám",
                "Nagy-Dávid"
            };
            List<double> maxHofok = new();
            List<string> diakok = new(){
                "Gipsz Jakab",
                "Lakatos Krisztina Mária",
                "Benedek Elek",
                "Kiss Sándor",
                "Veréb András János"
            };

            //napiCsapadék feltöltése randopm adatokkal
            Enumerable.Range(1, 365).ToList().ForEach(x => napiCsapadek.Add(new Random().Next(1, 301)));
            //maxHofok feltöltése randopm adatokkal
            Enumerable.Range(1, 30).ToList().ForEach(x => maxHofok.Add(new Random().NextDouble() * 30));


            //1. feladat
            Console.WriteLine(maxHofok.Count(x => x > 20));
            //2. feladat
            List<double> hofokok = maxHofok.OrderByDescending(x => x).ToList();
            //3. feladat
            Console.WriteLine($"Ennyi tanulónak van 2 keresztneve: {diakok.Count(x => x.Split(' ').Length == 3)}");
            //4. feladat
            foreach (string diak in diakok.OrderBy(x => x))
            {
                if (diak.Trim().Length > 15) Console.WriteLine(diak);
            }
            //5. feladat
            napiCsapadek.Count(x => x > 10);
            //6.feladat
            napiCsapadek.OrderByDescending(x => x);
            //7.feladat
            List<int> aligesett = napiCsapadek.Where(x => x < 3).ToList();
            //8. feladat
            versenyzok.OrderBy(x => x.Trim().Length).ThenBy(x => x);
            //9.feladat
            napiCsapadek.Count(x => x.Equals(0));
            //10. feladat
            List<int> sokeso = napiCsapadek.Where(x => x > 5).ToList();
            //11. feladat
            versenyzok
            .Where(x => x.Split('-')[1].Equals("Dávid"))
            .ToList().ForEach(x => Console.WriteLine(x));
            //12. feladat
            Console.WriteLine($"A legnagyobb hőmérséklet különbség: {maxHofok.Max() - maxHofok.Min()}");
            //13. feladat
            Console.WriteLine(napiCsapadek.OrderBy(x => x).ToList()[1]);
            //14. feladat   
            System.Console.WriteLine(napiCsapadek.Average());
            //15. feladat
            System.Console.WriteLine(versenyzok.Any(x => x.Equals("Szuper-Béla")) ? "Van ilyen versenyző"
            : "Nincs ilyen versenyző");
            //16. feladat
            napiCsapadek.FindLastIndex(x => x > 30);
            //17. feladat
            diakok.DistinctBy(x => x.Split(' ')[0]).Count();
            //18. feladat
            versenyzok.Find(x => x.Contains("Vajk"));
            //19. feladat
            List<string> nevek = diakok.Select(x => x.Split(' ')[1]).ToList();
            //20. feladat
            List<string> angolul = versenyzok
            .Where(nev => nev.Contains("Béla"))
            .Select(x => x.Split('-')[1] + " " + x.Split('-')[0])
            .ToList();

        }

    }

}
