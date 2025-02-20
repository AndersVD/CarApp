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
            public Double BrændstofPris;
        }

        static Bil bil;

        // Only one Main method here
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
                        return;  // Exit the program
                    default:
                        Console.WriteLine("Ugyldigt valg! Prøv igen.");
                        break;
                }
            }
        }

        static void ReadCarDetails()
        {
            Console.Write("Indtast bilens mærke: ");
            bil.Mærke = Console.ReadLine();

            Console.Write("Indtast bilens model: ");
            bil.Model = Console.ReadLine();

            Console.Write("Indtast bilens kilometerstand: ");
            bil.Kilometerstand = Convert.ToDouble(Console.ReadLine());

            Console.Write("Indtast bilens brændstofforbrug (km/l): ");
            bil.KmPerLiter = Convert.ToDouble(Console.ReadLine());

            Console.Write("Indtast BrændstofPris: ");
            bil.BrændstofPris = Convert.ToDouble(Console.ReadLine());
        }

        static void Drive()
        {
            Console.Write("Indtast distance du har kørt: ");
            double distance = Convert.ToDouble(Console.ReadLine());

            bil.Kilometerstand += distance;
            Console.WriteLine($"Du har kørt {distance} km. Ny kilometerstand: {bil.Kilometerstand} km.");
        }

        static void CalculateTripPrice()
        {
            Console.Write("Indtast distance du har kørt: ");
            double distance = Convert.ToDouble(Console.ReadLine());

            Console.Write("Indtast benzinpris per liter: ");
            double literPrice = Convert.ToDouble(Console.ReadLine());

            double fuelNeeded = distance / bil.KmPerLiter;
            double totalPrice = fuelNeeded * literPrice;
            Console.WriteLine($"Pris for turen: {totalPrice:F2} DKK");
        }

        static void PrintCarDetails()
        {
            Console.WriteLine("Bilens detaljer:");
            Console.WriteLine($"Mærke: {bil.Mærke}");
            Console.WriteLine($"Model: {bil.Model}");
            Console.WriteLine($"Kilometerstand: {bil.Kilometerstand} km");
            Console.WriteLine($"Brændstofforbrug: {bil.KmPerLiter} km/l");
        }
    }
}