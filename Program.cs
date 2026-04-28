using OOP_Praktikum;
using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        // Ühine nimekiri kõikide liidest rakendavate objektide jaoks
        List<IKujund> kujundid = new List<IKujund>();


      
        while (true) // Lõputu tsükkel, kuni kasutaja valib 0
        {
            Console.WriteLine("\nVali kujund: 1=Ruut, 2=Ring, 3=Ristkülik, 4=Kolmnurk, 5=TäisnurkneKolmnurk, 0=Välju");
            string valik = Console.ReadLine();

            if (valik == "0") break; // Murrame tsüklist välja

            switch (valik)
            {
                case "1":
                    Console.Write("Sisesta ruudu küljepikkus: ");
                    // Turvaline sisestus TryParse abiga
                    if (double.TryParse(Console.ReadLine(), out double külg))
                    {
                        kujundid.Add(new Ruut(külg)); // Lisame uue objekti listi
                    }
                    else
                    {
                        Console.WriteLine("⚠️ Vigane sisend! Palun sisesta number.");
                    }
                    break;

                case "2": // Ring
                    Console.Write("Sisesta ringi raadius: ");
                    bool RaadiusOk = double.TryParse(Console.ReadLine(), out double Raadius);

                    if (RaadiusOk)
                    {
                        kujundid.Add(new Ring(Raadius));
                    }
                    else
                    {
                        Console.WriteLine("⚠️ Vigane sisend! Raadius peavad olema numbrid.");
                    }
                    break;

                case "3": // Ristkülik
                    Console.Write("Sisesta ristküliku pikkus: ");
                    bool pikkusOk = double.TryParse(Console.ReadLine(), out double pikkus);

                    Console.Write("Sisesta ristküliku laius: ");
                    bool laiusOk = double.TryParse(Console.ReadLine(), out double laius);

                    if (pikkusOk && laiusOk)
                    {
                        kujundid.Add(new Ristkülik(pikkus, laius));
                    }
                    else
                    {
                        Console.WriteLine("⚠️ Vigane sisend! Pikkus ja laius peavad olema numbrid.");
                    }
                    break;

                case "4":  // Kolmnurk
                    Console.Write("Sisesta a: ");
                    bool aOk = double.TryParse(Console.ReadLine(), out double a);

                    Console.Write("Sisesta b: ");
                    bool bOk = double.TryParse(Console.ReadLine(), out double b);

                    Console.Write("Sisesta c: ");
                    bool cOk = double.TryParse(Console.ReadLine(), out double c);

                    if (aOk && bOk && cOk)
                    {
                        kujundid.Add(new Kolmnurk(a, b, c));
                       
                    }
                    else
                    {
                        Console.WriteLine("⚠️ Vigane sisend! a, b, c peavad olema numbrid.");
                    }
                    break;

                case "5":  // TäisnurkneKolmnurk
                    Console.Write("Sisesta a: ");
                    bool aOk1 = double.TryParse(Console.ReadLine(), out double a1);

                    Console.Write("Sisesta b: ");
                    bool bOk1 = double.TryParse(Console.ReadLine(), out double b1);

                   
                    if (aOk1 && bOk1)
                    {
                        kujundid.Add(new TäisnurkneKolmnurk(a1, b1));
                        
                    }
                    else
                    {
                        Console.WriteLine("⚠️ Vigane sisend! a, b, c peavad olema numbrid.");
                    }
                    break;
                // Märkus: Ring ja Kolmnurk töötavad sama loogika alusel. 
                // Õpilased saavad need ise Switch-lausesse lisada!

                default:
                    Console.WriteLine("Tundmatu valik.");
                    break;

            }
        }


        // Tulemuste kuvamine
        Console.WriteLine("\n--- Kujundite tulemused ---");
        double kogupindala = 0;
        foreach (var kujund in kujundid)
        {
            // Polümorfism: Iga kujund arvutab pindala ja ümbermõõdu oma spetsiifilise valemi järgi!
            // kujund.GetType().Name annab meile klassi nime (nt "Ruut" või "Ring")
            // :F2 ümardab tulemused 2 komakohani
            //Console.WriteLine($"Tüüp: {kujund.GetType().Name} | Pindala: {kujund.ArvutaPindala():F2} | Ümbermõõt: {kujund.ArvutaÜmbermõõt():F2}");

            string nimi = kujund.GetType().Name;
            double pindala = kujund.ArvutaPindala();
            kogupindala += pindala;
            double ümbermõõt = kujund.ArvutaÜmbermõõt();

            string rida = $"Tüüp: {nimi,-10} | Pindala: {pindala,8:F2} | Ümbermõõt: {ümbermõõt,8:F2}";

            // KONTROLL: Kas see kujund on tegelikult Kolmnurk?   
            // Kasutame 'Pattern Matching' (kujund is Kolmnurk k)
            if (kujund is Kolmnurk k)
            {
                // Nüüd me saame kasutada muutujat 'k', et küsida Kolmnurga omadusi
                rida += $" | Liik: {k.Tüüp}";
            }

            Console.WriteLine(rida);
        }
        Console.WriteLine($"Kogupindala {kogupindala} | Suurim pindala: {kujundid.Max(k => k.ArvutaPindala()).ToString("F2")}");
    }
}