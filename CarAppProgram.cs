using System;

namespace Cartrial
{
    class Program
    {
        struct Bil
        {
            public string Mærke;
            public string Model;
            public double Kilometerstand;
            public double KmPerLiter;
            // Tilføjet FuelType som datatype
            public FuelType Brændstoftype;
        }

        static bool IsPalindrome(int number)
        {
            string str = number.ToString();
            char[] arr = str.ToCharArray();
            Array.Reverse(arr);
            return str == new string(arr);
        }

        static Bil bil;
        const double LITERPRIS = 12.50;  // Fastlåst literpris

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("\n--- BILPROGRAM MENU ---");
                Console.WriteLine("1. Indlæs bilens oplysninger");
                Console.WriteLine("2. Kør en tur");
                Console.WriteLine("3. Beregn turpris");
                Console.WriteLine("4. Udskriv bilens oplysninger");
                Console.WriteLine("5. Afslut");
                Console.Write("Vælg en funktion: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        ReadCarDetails();
                        break;
                    case 2:
                        Drive();
                        break;
                    case 3:
                        CalculateTripPrice();
                        break;
                    case 4:
                        PrintCarDetails();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Ugyldigt valg! Prøv igen.");
                        break;
                }
            }
        }

        // Tilføjet FuelType enum
        public enum FuelType
        {
            Benzin,
            Diesel,
            Elektrisk,
            Hybrid
        }

        static void ReadCarDetails()
        {
            Console.Write("Indtast bilens mærke: ");
            bil.Mærke = Console.ReadLine();

            Console.Write("Indtast bilens model: ");
            bil.Model = Console.ReadLine();

            Console.Write("Indtast bilens kilometerstand: ");
            bil.Kilometerstand = Convert.ToDouble(Console.ReadLine());

            // Flyttet valg af brændstoftype før km/l
            Console.WriteLine("Vælg bilens brændstoftype:");
            Console.WriteLine("1. Benzin");
            Console.WriteLine("2. Diesel");
            Console.WriteLine("3. Elektrisk");
            Console.WriteLine("4. Hybrid");
            int fuelChoice = Convert.ToInt32(Console.ReadLine());
            bil.Brændstoftype = (FuelType)(fuelChoice - 1);

            // Tilføjet betingelse for at springe km/l over for elektriske biler
            if (bil.Brændstoftype != FuelType.Elektrisk)
            {
                Console.Write("Indtast bilens brændstofforbrug (km/l): ");
                bil.KmPerLiter = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine($"Brændstofprisen er fastlåst til: {LITERPRIS} DKK/liter.");
            }
            else
            {
                bil.KmPerLiter = 0; // Sæt km/l til 0 for elektriske biler
            }

            
        }

        static void Drive()
        {
            Console.Write("Indtast distance du har kørt: ");
            double distance = Convert.ToDouble(Console.ReadLine());

            bil.Kilometerstand += distance;
            Console.WriteLine($"Du har kørt {distance} km. Ny kilometerstand: {bil.Kilometerstand} km.");

            if (IsPalindrome((int)bil.Kilometerstand))
            {
                Console.WriteLine(" Tillykke! Din kilometerstand er et palindrom! 🎉");
            }
        }

        static void CalculateTripPrice()
        {
            Console.Write("Indtast distance du har kørt: ");
            double distance = Convert.ToDouble(Console.ReadLine());

            if (bil.Brændstoftype != FuelType.Elektrisk)
            {
                double fuelNeeded = distance / bil.KmPerLiter;
                double totalPrice = fuelNeeded * LITERPRIS;  // Brug den fastlåste literpris
                Console.WriteLine($"Pris for turen: {totalPrice:F2} DKK");
            }
            else
            {
                Console.WriteLine("Elektriske biler bruger ikke brændstof.");
            }
        }

        static void PrintCarDetails()
        {
            Console.WriteLine("\nBilens detaljer:");
            Console.WriteLine($"Mærke: {bil.Mærke}");
            Console.WriteLine($"Model: {bil.Model}");
            Console.WriteLine($"Kilometerstand: {bil.Kilometerstand} km");
            if (bil.Brændstoftype != FuelType.Elektrisk)
            {
                Console.WriteLine($"Brændstofforbrug: {bil.KmPerLiter} km/l");
            }
            Console.WriteLine($"Brændstoftype: {bil.Brændstoftype}");
            Console.WriteLine($"Brændstofpris: {LITERPRIS} DKK/liter (fastlåst)");
        }
    }
}