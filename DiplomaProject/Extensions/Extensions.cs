using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaProject
{
    public static class Extensions
    {
        public static int IndexInArray(this MonomBase monom)
        {
            int firstIndex = -1;
            int secondIndex = -1;

            for (int i = 0; i < monom.VariablesCount; i++)
            {
                if (firstIndex == -1 && monom.MonomVector[i] != 0)
                {
                    firstIndex = i;
                }
                else if (monom.MonomVector[i] != 0)
                {
                    secondIndex = i;
                    break;
                }
            }

            int startFromIndex = 0;

            if (firstIndex != 0)
            {
                startFromIndex = firstIndex * monom.VariablesCount - (int)(((double)((double)firstIndex - 1d) / 2d) * (double)firstIndex);
            }

            int paddingFromStart = 0;

            if (secondIndex > 0)
            {
                paddingFromStart = secondIndex - firstIndex;
            }

            return startFromIndex + paddingFromStart;
        }

        public static Zsknf ToZSknf(this ZRow zRow)
        {
            var existedVariables = new ushort[Constants.ZVariablesCount];
            var posList = new List<int>();

            foreach (var monom in zRow.RowVector)
            {
                if (monom.PresentState == PresentFlag.Present)
                {
                    for (int i = 0; i < Constants.ZVariablesCount; i++)
                    {
                        existedVariables[i] |= monom.MonomVector[i];
                        posList.Add(i);
                    }
                }
            }

            

            var sknf = new Zsknf();
            ushort res = 0;
            List<ushort> monomValues = new List<ushort>();
            ushort monomValue = 0;

            for (uint i = 0; i < Math.Pow(2, existedVariables.Count()) ; i++)
            {
                res = 0;

                foreach(var monom in zRow.RowVector.Select(m => m.PresentState == PresentFlag.Present))
                {
                    monomValues.Clear();
                    //for (int j = 0; j < monom.VariablesCount; j++)
                    //{
                    //    if (monom.MonomVector[j] == 1)
                    //    {
                    //        monomValues.Add((ushort)((i >> j) & 1u));
                    //    }
                    //}
                    monomValue = 1;

                    foreach(var val in monomValues)
                    {
                        monomValue &= val;
                    }

                    res ^= monomValue;
                }

                if (res == 0)
                {
                    var arr = new ushort[Constants.ZVariablesCount];

                    for (int j = 0; j < Constants.ZVariablesCount; j++)
                    {
                        arr[j] = (ushort)(i & (1 << j));
                    }
                }
            }
            return sknf;
        }

        public static SknfRow ToSknf(this SystemRow row)
        {
            //for(int i = 0; i < 0b111_1111_1111_1111_1111)
            //{
                
            //}

            //for (int i = 0; i < 0b11_1111_1111_1111_1111_1111)
            //{

            //}

            //for (int i = 0; i < 0b111_1111_1111_1111_1111_1111)
            //{

            //}
            throw new NotImplementedException();
        }
    }
    
}
