using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace DiplomaProject
{
    public class EquentialLoader
    {
        public List<List<MonomX>> XSet { get; private set; }
        public List<List<MonomY>> YSet { get; private set; }
        public List<List<MonomZ>> ZSet { get; private set; }
        public List<ushort> Gamma { get; private set; }

        public void LoadAllData()
        {
            using (FileStream fs = new FileStream(Constants.xRowsFileName, FileMode.Open))
            {
                XSet = JsonSerializer.Deserialize<List<List<MonomX>>>(fs);
            }

            using (FileStream fs = new FileStream(Constants.yRowsFileName, FileMode.Open))
            {
                YSet = JsonSerializer.Deserialize<List<List<MonomY>>>(fs);
            }

            using (FileStream fs = new FileStream(Constants.zRowsFileName, FileMode.Open))
            {
                ZSet = JsonSerializer.Deserialize<List<List<MonomZ>>>(fs);
            }

            using (FileStream fs = new FileStream(Constants.gammaFileName, FileMode.Open))
            {
                Gamma = JsonSerializer.Deserialize<List<ushort>>(fs);
            }
        }
    }
}
