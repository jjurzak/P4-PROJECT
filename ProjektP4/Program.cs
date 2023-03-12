using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Globalization;
using System.Text.RegularExpressions;


namespace ProjektP4
{
    class Program
    {
        static void DisplayHotels(IEnumerable<Hotels> hotels)
        {
            foreach (var h in hotels)
            {
                Console.WriteLine($"Lp.: {h.Lp} Nazwa własna: {h.NazwaWlasnna} Telefon: {h.Telefon} Email: {h.Email} Charakter usług:" +
                                  $" {h.CharakterUslug} Kategoria obiektu: {h.KategoriaObiektu} Rodzaj obiektu: {h.RodzajObiektu} Adres: {h.Adres}");
            }
            
        }
        
        
        
        static void Main(string[] args)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";"
            };
            //1
            using (var reader = new StreamReader("hotele.csv"))
            using (var csv = new CsvReader(reader, config))
            {
                csv.Context.RegisterClassMap<HotelsMap>();
                var hotels = csv.GetRecords<Hotels>().ToList();
                
                //DisplayHotels(hotels);
                Console.WriteLine("\n2. Wyszukaj hotele, których nazwa zaczyna się na literę 's'. ------------------------------------------------------------------------------------------------------------\n");
                //2
                var sHotelsList = hotels.Where(h => h.NazwaWlasnna.StartsWith("S", StringComparison.OrdinalIgnoreCase));
                DisplayHotels(sHotelsList);
               
                Console.WriteLine("\n3. Oblicz ile hoteli ma charakter sezonowy. \n");
                //3
                var seasonHotelCount = hotels.Count(h => h.CharakterUslug == "sezonowy");
                Console.WriteLine($"Liczba hoteli z sezonowym charakterem usług: {seasonHotelCount}");
               
                Console.WriteLine("\n4. Wyświetl wszystkie typy charakterów usług bez powtórzeń. \n");
                //4
                var serviceTypeHotels = hotels.DistinctBy(h => h.CharakterUslug);
                DisplayHotels(serviceTypeHotels);
                
                Console.WriteLine("\n5. Wyświetl wszystkie kategorie hoteli bez powtórzeń. \n");
                //5
                var categoryHotels = hotels.DistinctBy(h => h.KategoriaObiektu);
                DisplayHotels(categoryHotels);
                
                Console.WriteLine("\n6. Wyświetl hotele z okolicy Bielska-Białej (numer telefonu zaczyna się 33). \n");
                //6
                var phoneHotlesfromBielsko = hotels.Where(h => h.Telefon.StartsWith("33"));
                DisplayHotels(phoneHotlesfromBielsko);

                Console.WriteLine("\n7. Grupuj hotele wg kategorii i zwróć ile hoteli występuje w każdej grupie. \n");
                var groupedByCategoryHotels = hotels.GroupBy(h => h.KategoriaObiektu).
                        Select(g => new
                        {
                            Kategoria = g.Key,
                            Ilość = g.Count()
                        });
                foreach (var g in groupedByCategoryHotels)
                {
                    Console.WriteLine($"Kategoria: {g.Kategoria}, Ilosc: {g.Ilość}");
                }

                Console.WriteLine("\n8. Grupuj hotele wg charakteru usług i zwróć ile hoteli występuje w każdej grupie. \n");
                var groupedByServicesHotels = hotels.GroupBy(h => h.CharakterUslug).Select(g => new
                {
                    CharakterUslug = g.Key,
                    Ilość = g.Count()
                });
                foreach (var g in groupedByServicesHotels)
                {
                    Console.WriteLine($"Charakter Usług: {g.CharakterUslug}, Ilość: {g.Ilość}");
                }
            }
        }
    }

    
}