using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaProject
{
    public class KeyHacker
    {
        private EquentialLoader _dataLoader = new EquentialLoader();

        private const int _systemSize = 800;

        private List<SystemRow> _system = new List<SystemRow>();

        private uint[] M = { 0, 0, 0, 1, 0, 1, 1, 1 };

        private void Initialize()
        {
            _dataLoader.LoadAllData();
        }

        public KeyHacker()
        {
            Initialize();
        }

        //k - 4ced482318be6784
        //1 - 0x0005ae6c 0101 1010 1110 0110 1100
        //2 - 0x0038ef12 0011 1000 1110 1111 0001 0010
        //3 - 0x002e4966 0010 1110 0100 1001 0110 0110
        //4 - 0x00007b41

        public void HackKey()
        {
            for (uint reg_4_candidate = 0x00007b41; reg_4_candidate < 0x1ffff; reg_4_candidate++)
            {
                GenerateSystem(reg_4_candidate);


                var result = TrySolveSystem();

                if (result)
                {
                    var sb = new StringBuilder();
                    for(int i = 0; i < 719; i++)
                    {
                        if (_system[i][i].Degree() == 1)
                        {
                            sb.Append($"{_system[i][i].ToString()} = {_system[i].Value}\n");
                        }

                    }
                    Console.Write("\n");
                    Console.Write(sb.ToString());
                }

                result = true;
            }
        }

        private void GenerateSystem(uint regValue)
        {
            _system.Clear();

            int it_1 = 0;
            int it_2 = 0;
            int it_3 = 0;

            for (int j = 0; j < _systemSize; j++)
            {
                uint ctrl = (((regValue >> 15) & 1) << 2) | (((regValue >> 6) & 1) << 1) | (((regValue >> 1) & 1) << 0);
                if (M[ctrl] == ((regValue >> 15) & 1))
                {
                    it_1++;
                }
                if (M[ctrl] == ((regValue >> 6) & 1))
                {
                    it_2++;
                }
                if (M[ctrl] == ((regValue >> 1) & 1))
                {
                    it_3++;
                }

                var x = new XRow();
                var y = new YRow();
                var z = new ZRow();

                x = (XRow)(x ^ _dataLoader.XSet[it_1]);
                y = (YRow)(y ^ _dataLoader.YSet[it_2]);
                z = (ZRow)(z ^ _dataLoader.ZSet[it_3]);

                var nextRow = new SystemRow(x, y, z, _dataLoader.Gamma[j]);

                _system.Add(nextRow);

                regValue = ((regValue << 1) | (((regValue >> 16) ^ (regValue >> 13) ^ (regValue >> 12) ^ (regValue >> 8)) & 1)) & 0x1ffff;
            }
        }

        private bool TrySolveSystem()
        {
            for (int i = 0; i < 719; i++)
            {

                if (_system[i][i].PresentState == PresentFlag.NotPresent)
                {
                    _system[i] ^=_system[NextNotZeroStringIndex(i)];
                }
                for (int j = i + 1; j < _systemSize; j++)
                {
                    if (_system[j][i].PresentState == PresentFlag.Present)
                    {
                        _system[j] ^= _system[i];

                    }
                }
            }

            // check for sucsess

            for (int i = 0; i < 719; i++)
            {
                if (_system[i][i].PresentState == PresentFlag.NotPresent)
                {
                    return false;
                }
            }

            for (int i = 719; i < _systemSize; i++)
            {
                if (_system[i].XRow.RowVector.Any(x => x.PresentState == PresentFlag.Present) ||
                    _system[i].YRow.RowVector.Any(y => y.PresentState == PresentFlag.Present) ||
                    _system[i].ZRow.RowVector.Any(z => z.PresentState == PresentFlag.Present) ||
                    _system[i].Value != 0u
                    )
                {
                    return false;
                }
            }

            //reverted direction

            for (int i = 718; i >= 0; i--)
            {
                if (_system[i][i].PresentState == PresentFlag.Present)
                {
                    for (int j = i - 1; j >= 0; j--)
                    {
                        if (_system[j][i].PresentState == PresentFlag.Present)
                        {
                            _system[j] ^= _system[i];

                        }
                    }
                }
            }
            return true;
        }

        private int NextNotZeroStringIndex(int pos)
        {
            for(int i = pos + 1; i < _systemSize; i++)
            {
                if (_system[i][pos].PresentState == PresentFlag.Present)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
