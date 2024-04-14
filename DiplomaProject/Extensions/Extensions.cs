using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        public static int IndexInArrayThirdDegree(this MonomBase monom)
        {
            int firstIndex = -1;
            int secondIndex = -1;
            int thirdIndex = -1;

            if (monom.MonomVector.Count(m => m == 1) < 3)
            {
                return monom.IndexInArray();
            }

            for (int i = 0; i < monom.VariablesCount; i++)
            {
                if (firstIndex == -1 && monom.MonomVector[i] != 0)
                {
                    firstIndex = i;
                }
                else if (secondIndex == -1 && monom.MonomVector[i] != 0)
                {
                    secondIndex = i;
                }
                else if (monom.MonomVector[i] != 0)
                {
                    thirdIndex = i;
                    break;
                }
            }

            int startFromIndex = 0;

            int monomsCount = 0;

            if (monom is MonomX)
            {
                monomsCount = Constants.XMonomsCount;
            }
            else if (monom is MonomY)
            {
                monomsCount = Constants.YMonomsCount;
            }
            else if (monom is MonomZ)
            {
                monomsCount = Constants.ZMonomsCount;
            }

            ////find index

            //int countOfvariables = monom.VariablesCount - (int)((((double)((firstIndex + 2) + 1)) / 2d) * (double)(firstIndex + 2) );

            //start index

            if (firstIndex != 0)
            {
                startFromIndex = monomsCount + BeforeCount(monom.VariablesCount, firstIndex);
            }
            else
            {
                startFromIndex = monomsCount;
            }

            //pudding for second variable
            int paddingForSecond = 0;

            if (secondIndex - firstIndex > 1)
            {
                paddingForSecond = (int)(((double)((monom.VariablesCount - firstIndex - 2) + (monom.VariablesCount - firstIndex - 2) - (secondIndex - firstIndex - 2)) / 2d)
                    * (double)(secondIndex - firstIndex - 1));
            }
            else
            {
                paddingForSecond = 0;
            }

            //third index padding
            int paddingForThird = 0;

            paddingForThird = thirdIndex - secondIndex - 1;
            ///


            return startFromIndex + paddingForSecond + paddingForThird;
        }

        private static int BeforeCount(int variablesCount, int index)
        {
            int countOfvariables = 0;

            for(int i = 0; i < index; i++)
            {
                countOfvariables += VariablesCount(variablesCount, i);
            }

            return countOfvariables;
        }

        private static int VariablesCount(int variablesCount, int index)
        {
            return (int)( ((double)(variablesCount - index - 1) / 2d) * (double)(variablesCount - index - 2) );
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
