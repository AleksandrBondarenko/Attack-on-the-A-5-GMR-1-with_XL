using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace DiplomaProject
{
    public class Generator
    {
        public const string gammaFileName = "gamma.json";
        public const string xRowsFileName = "x.json";
        public const string yRowsFileName = "y.json";
        public const string zRowsFileName = "z.json";

        EquentialsGenerator _eGenerator = new EquentialsGenerator();
        GammaGenerator _gGenerator = new GammaGenerator();

        public void GenerateEquentialsFiles(int equentialsCount)
        {
            var xSet = _eGenerator.GenerateX(equentialsCount);
            var ySet = _eGenerator.GenerateY(equentialsCount);
            var zSet = _eGenerator.GenerateZ(equentialsCount);

            using (FileStream fs = new FileStream(xRowsFileName, FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize(fs, xSet);
            }

            using (FileStream fs = new FileStream(yRowsFileName, FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize(fs, ySet);
            }

            using (FileStream fs = new FileStream(zRowsFileName, FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize(fs, zSet);
            }
        }

        public void GenerateGammaFile(ulong key, int gammaCount)
        {
            var gamma = _gGenerator.GenerateGamma(key, gammaCount);

            using (FileStream fs = new FileStream(gammaFileName, FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize(fs, gamma);
            }
        }

    }
}
