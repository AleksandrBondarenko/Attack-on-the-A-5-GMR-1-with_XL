using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaProject
{
    public class MonomZ : MonomBase
    {
        private ushort[] _monomVector = new ushort[variablesCount];

        public const int variablesCount = 23;

        public override int VariablesCount => variablesCount;

        public override ushort[] MonomVector
        {
            get => _monomVector;
            set => _monomVector = value;
        }

        protected override string GetString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < variablesCount; i++)
            {
                if (_monomVector[i] != 0)
                {
                    sb.Append($"z{i + 1}");
                }
            }

            return sb.ToString();
        }

        protected override MonomBase Mult(MonomBase monom)
        {
            if (monom is not MonomZ)
            {
                throw new ArgumentException("There should be the same type of monom");
            }

            var result = new MonomZ();

            for (int i = 0; i < VariablesCount; i++)
            {
                result.MonomVector[i] = (ushort)(this.MonomVector[i] & monom.MonomVector[i]);
            }

            return result;
        }

        protected override MonomBase And(MonomBase monom)
        {
            if (monom is not MonomZ)
            {
                throw new ArgumentException("There should be the same type of monom");
            }

            var result = new MonomZ();

            for (int i = 0; i < VariablesCount; i++)
            {
                result.MonomVector[i] = (ushort)(this.MonomVector[i] | monom.MonomVector[i]);
            }

            return result;
        }
    }
}
