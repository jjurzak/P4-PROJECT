using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Globalization;


namespace ProjektP4
{
    class Program
    {
        static void DisplayHotels(Hotels h)
        {
            Console.WriteLine($"Lp.: {h.Lp} Nazwa własna: {h.NazwaWlasnna} Telefon: {h.Telefon} Email: {h.Email} Charakter usług:" +
                              $" {h.CharakterUslug} Kategoria obiektu: {h.KategoriaObiektu} Rodzaj obiektu: {h.RodzajObiektu} Adres: {h.Adres}");
        }
        
        static void Main(string[] args)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";"
            };
            
            using (var reader = new StreamReader("hotele.csv"))
            using (var csv = new CsvReader(reader, config))
            {
                csv.Context.RegisterClassMap<HotelsMap>();
                var records = csv.GetRecords<Hotels>().ToList();
                foreach (var h in records)
                {
                    DisplayHotels(h);
                }
            }
        }
    }

    
}