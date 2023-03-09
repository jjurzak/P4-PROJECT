using CsvHelper.Configuration;
namespace ProjektP4;

public class Hotels
{
    public int Lp { get; set; }
    public string NazwaWlasnna { get; set; }
    public string Telefon { get; set; }
    public string Email { get; set; }
    public string CharakterUslug { get; set; }
    public string KategoriaObiektu { get; set; }
    public string RodzajObiektu { get; set; }
    public string Adres { get; set; }
}
public sealed class HotelsMap : ClassMap<Hotels>
{
    public HotelsMap()
    {
        Map(m => m.Lp).Index(0);
        Map(m => m.NazwaWlasnna).Index(1);
        Map(m => m.Telefon).Index(2);
        Map(m => m.Email).Index(3);
        Map(m => m.CharakterUslug).Index(4);
        Map(m => m.KategoriaObiektu).Index(5);
        Map(m => m.RodzajObiektu).Index(6);
        Map(m => m.Adres).Index(7);
    }
}
