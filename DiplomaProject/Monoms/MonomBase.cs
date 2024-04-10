using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaProject
{
    public enum PresentFlag
    {
        Present = 1,
        NotPresent = 0
    }
    public abstract class MonomBase
    {
        public abstract int VariablesCount { get; }
        public abstract ushort[] MonomVector { get; set; }
        public PresentFlag PresentState { get; set; } = PresentFlag.NotPresent;

        private static bool TheSameMonom(MonomBase a, MonomBase b)
        {
            return a.MonomVector.SequenceEqual(b.MonomVector);
        }

        protected abstract MonomBase Mult(MonomBase monom);

        protected abstract MonomBase And(MonomBase monom);

        public int Degree()
        {
            return MonomVector.Count(m => m == 1);
        }

        public static MonomBase operator |(MonomBase a, MonomBase b)
        {
            return a.And(b);
        }

        public static MonomBase operator &(MonomBase a, MonomBase b)
        {
            return a.Mult(b);
        }

        //XOR only for xor in table
        public static MonomBase operator ^(MonomBase a, MonomBase b)
        {
            if (!TheSameMonom(a, b))
            {
                throw new ArgumentException("There should be the same monom");
            }

            a.PresentState = a.PresentState != b.PresentState ? PresentFlag.Present : PresentFlag.NotPresent;

            return a;
        }

        protected abstract string GetString();

        public override string ToString()
        {
            return GetString();
        }

        public override bool Equals(Object? obj)
        {
            if (obj == null || !(obj is MonomBase))
            {
                return false;
            }
            else
            {
                for(int i = 0; i < VariablesCount; i++)
                {
                    if (MonomVector[i] != ((MonomBase)obj).MonomVector[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            return this.MonomVector.GetHashCode();
        }
    }
}
