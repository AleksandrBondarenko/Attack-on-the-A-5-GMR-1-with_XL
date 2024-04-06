using System;
using System.Collections.Generic;
using System.Linq;
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
    }
    
}
