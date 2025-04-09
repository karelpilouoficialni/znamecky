using System; 
namespace HelloWorld 
{ 
    class Program 
    { 
        static void Main(string[] args) 
        { 
            Console.WriteLine("Program pro vyhodnoceni znamek:"); 
            Console.WriteLine("podporovane znamky:"); 
            Console.WriteLine("1"); 
            Console.WriteLine("2"); 
            Console.WriteLine("3"); 
            Console.WriteLine("4"); 
            Console.WriteLine("5"); 
            Console.WriteLine("Zadejte znamku:"); 
            string input = Console.ReadLine(); 
            switch (input) 
            { 
                case "1": 
                    Console.WriteLine("znamka je vyborna"); 
                    break; 
                case "2": 
                    Console.WriteLine("znamka je chvalitebna"); 
                    break; 
                case "3": 
                    Console.WriteLine("znamka je dobra"); 
                    break; 
                case "4": 
                    Console.WriteLine("znamka je dostatecna"); 
                    break; 
                case "5": 
                    Console.WriteLine("znamka je nedostatecna"); 
                    break; 
                default: 
                    Console.WriteLine("Neplatný výběr."); 
                    break; 
            } 
        } 
    } 
}