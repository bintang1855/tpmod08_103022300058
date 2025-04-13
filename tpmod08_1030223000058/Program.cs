using tpmod08_1030223000058;
using System;

class Program
{
    static void Main(string[] args)
    {
        CovidConfig pengaturan = new CovidConfig().MuatKonfigurasi();

        Console.Write("Ingin mengubah satuan suhu? (y/n): ");
        string input = Console.ReadLine();

        if (input.ToLower() == "y")
        {
            pengaturan.GantiSatuanSuhu();
            Console.WriteLine($"Satuan suhu sekarang: {pengaturan.SuhuSatuan}");
        }

        Console.Write($"\nMasukkan suhu tubuh Anda ({pengaturan.SuhuSatuan}): ");
        double suhu = Convert.ToDouble(Console.ReadLine());

        Console.Write("Berapa hari lalu Anda terakhir demam? ");
        int hariDemam = int.Parse(Console.ReadLine());

        bool suhuNormal = false;

        if (pengaturan.SuhuSatuan == "celcius")
        {
            suhuNormal = suhu >= 36.5 && suhu <= 37.5;
        }
        else
        {
            suhuNormal = suhu >= 97.7 && suhu <= 99.5;
        }

        bool diperbolehkanMasuk = suhuNormal && (hariDemam < pengaturan.HariBatasDemam);

        Console.WriteLine();
        if (diperbolehkanMasuk)
        {
            Console.WriteLine(pengaturan.PesanTerima);
        }
        else
        {
            Console.WriteLine(pengaturan.PesanTolak);
        }
    }
}
