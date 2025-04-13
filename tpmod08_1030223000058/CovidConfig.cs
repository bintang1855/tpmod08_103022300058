using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace tpmod08_1030223000058
{
    class CovidConfig
    {
        public string SuhuSatuan { get; set; }
        public int HariBatasDemam { get; set; }
        public string PesanTolak { get; set; }
        public string PesanTerima { get; set; }

        string path = Path.GetFullPath("../../../../datas/covid_config.json");

        public CovidConfig()
        {
            SuhuSatuan = "celcius";
            HariBatasDemam = 14;
            PesanTolak = "Maaf, Anda tidak diizinkan masuk ke gedung ini.";
            PesanTerima = "Silakan masuk, Anda diizinkan masuk ke dalam gedung.";
        }

        public CovidConfig MuatKonfigurasi()
        {
            if (!File.Exists(path))
            {
                var defaultPengaturan = new CovidConfig();
                SimpanKonfigurasiBaru(defaultPengaturan);
                return defaultPengaturan;
            }

            string isiJson = File.ReadAllText(path);
            return JsonSerializer.Deserialize<CovidConfig>(isiJson);
        }

        public void SimpanKonfigurasiBaru(CovidConfig pengaturan)
        {
            var json = JsonSerializer.Serialize(pengaturan, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, json);
        }

        public void GantiSatuanSuhu()
        {
            if (SuhuSatuan.Equals("celcius"))
            {
                SuhuSatuan = "fahrenheit";
            }
            else
            {
                SuhuSatuan = "celcius";
            }

            SimpanKonfigurasiBaru(this);
        }
    }
}
