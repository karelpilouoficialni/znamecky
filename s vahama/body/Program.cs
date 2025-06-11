using System;
using System.Collections.Generic;
using System.Globalization;

class GradePredictor
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Predvídač známek");
        Console.WriteLine("Zadejte známky postupně. Pro ukončení napište 'konec'.");
        Console.WriteLine("Po každé známce zadejte:");
        Console.WriteLine(" - získané body (např. 45,5)");
        Console.WriteLine(" - maximální počet bodů (např. 50)");
        Console.WriteLine(" - váhu známky (1 až 10)");

        var grades = new List<GradeEntry>();

        while (true)
        {
            Console.Write("\nZadejte získané body nebo 'konec' pro ukončení: ");
            string input = Console.ReadLine().Trim().ToLower();

            if (input == "konec")
                break;

            if (!double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out double points) || points < 0)
            {
                Console.WriteLine("Neplatný vstup pro body, zadejte číslo větší nebo rovné 0.");
                continue;
            }

            Console.Write("Zadejte maximální počet bodů: ");
            string maxInput = Console.ReadLine().Trim();
            if (!double.TryParse(maxInput, NumberStyles.Any, CultureInfo.InvariantCulture, out double maxPoints) || maxPoints <= 0)
            {
                Console.WriteLine("Neplatný vstup pro maximální body, zadejte číslo větší než 0.");
                continue;
            }

            if (points > maxPoints)
            {
                Console.WriteLine("Získané body nemohou být větší než maximální počet bodů.");
                continue;
            }

            Console.Write("Zadejte váhu známky (1-10): ");
            string weightInput = Console.ReadLine().Trim();
            if (!int.TryParse(weightInput, out int weight) || weight < 1 || weight > 10)
            {
                Console.WriteLine("Neplatný vstup pro váhu, zadejte celé číslo od 1 do 10.");
                continue;
            }

            grades.Add(new GradeEntry(points, maxPoints, weight));
            Console.WriteLine("Známka přidána.");
        }

        if (grades.Count == 0)
        {
            Console.WriteLine("Nebyla zadána žádná známka.");
            return;
        }

        double weightedSum = 0;
        int totalWeight = 0;
        foreach (var grade in grades)
        {
            weightedSum += grade.Weight * (grade.Points / grade.MaxPoints);
            totalWeight += grade.Weight;
        }

        double percentage = (weightedSum / totalWeight) * 100;

        Console.WriteLine($"\nVýsledné skóre: {percentage:F2} %");
    }

    class GradeEntry
    {
        public double Points { get; }
        public double MaxPoints { get; }
        public int Weight { get; }

        public GradeEntry(double points, double maxPoints, int weight)
        {
            Points = points;
            MaxPoints = maxPoints;
            Weight = weight;
        }
    }
}

