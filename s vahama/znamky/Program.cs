using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<double> znamky = new List<double>();
        List<double> vahy = new List<double>();
        string input;

        Console.WriteLine("Zadejte známky (1, 1-, 2, 2-, 3, 3-, 4, 4, 5) a jejich váhy. Zadejte 'konec' pro ukončení.");

        while (true)
        {
            Console.Write("Zadejte známku nebo 'konec': ");
            input = Console.ReadLine();

            if (input.ToLower() == "konec")
            {
                break;
            }

            double znamka;
            if (ZnamkaNaHodnotu(input, out znamka))
            {
                Console.Write("Zadejte váhu pro tuto známku: ");
                if (double.TryParse(Console.ReadLine(), out double vaha) && vaha > 0)
                {
                    znamky.Add(znamka);
                    vahy.Add(vaha);
                }
                else
                {
                    Console.WriteLine("Neplatná váha. Zadejte kladné číslo.");
                }
            }
            else
            {
                Console.WriteLine("Neplatná známka. Zadejte číslo mezi 1 a 5 nebo známky s minus.");
            }
        }

        double prumer = VypocitejPrumer(znamky, vahy);
        Console.WriteLine($"Průměrná známka je: {prumer:F2}");
    }

    static bool ZnamkaNaHodnotu(string input, out double hodnota)
    {
        switch (input)
        {
            case "1":
                hodnota = 1.0;
                return true;
            case "1-":
                hodnota = 1.5;
                return true;
            case "2":
                hodnota = 2.0;
                return true;
            case "2-":
                hodnota = 2.5;
                return true;
            case "3":
                hodnota = 3.0;
                return true;
            case "3-":
                hodnota = 3.5;
                return true;
            case "4":
                hodnota = 4.0;
                return true;
            case "4-":
                hodnota = 4.5;
                return true;
            case "5":
                hodnota = 5.0;
                return true;
            default:
                hodnota = 0;
                return false;
        }
    }

    static double VypocitejPrumer(List<double> znamky, List<double> vahy)
    {
        double soucetZnamek = 0;
        double soucetVah = 0;

        for (int i = 0; i < znamky.Count; i++)
        {
            soucetZnamek += znamky[i] * vahy[i];
            soucetVah += vahy[i];
        }

        return soucetVah > 0 ? soucetZnamek / soucetVah : 0;
    }
}