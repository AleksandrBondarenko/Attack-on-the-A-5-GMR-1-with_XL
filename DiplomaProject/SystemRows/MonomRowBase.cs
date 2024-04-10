using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DiplomaProject
{
    public abstract class MonomRowBase
    {
        public abstract int MonomsCount { get; }

        protected abstract void Init();

        [JsonIgnore]
        public abstract MonomBase[] RowVector { get; }

        public MonomRowBase() 
        {
            Init();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach(var monom in RowVector)
            {
                if(monom.PresentState == PresentFlag.Present)
                {
                    sb.Append($" + {monom.ToString()}");
                }
            }

            sb.Remove(0, 1); //remove first +

            return sb.ToString();
        }

        //XOR
        public static MonomRowBase operator ^(MonomRowBase a, MonomRowBase b)
        {
            if (a.GetType() != b.GetType())
            {
                throw new ArgumentException("There should be the same type of monom row");
            }

            for(int i = 0; i < a.MonomsCount; i++)
            {
                a.RowVector[i] ^= b.RowVector[i];
            }

            return a;
        }
    }
}
