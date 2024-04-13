using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaProject
{
    public class MonomX : MonomBase
    {
        private ushort[] _monomVector = new ushort[Constants.XVariablesCount];

        public override int VariablesCount => Constants.XVariablesCount;

        public override ushort[] MonomVector
        {
            get => _monomVector;
            set => _monomVector = value;
        }

        protected override string GetString()
        {
            StringBuilder sb = new StringBuilder();

            for(int i = 0; i < Constants.XVariablesCount; i++)
            {
                if (_monomVector[i] != 0)
                {
                    sb.Append($"x{i+1}");
                }
            }

            return sb.ToString();
        }

        protected override MonomBase Mult(MonomBase monom)
        {
            if (monom is not MonomX)
            {
                throw new ArgumentException("There should be the same type of monom");
            }

            var result = new MonomX();

            for (int i = 0; i < VariablesCount; i++)
            {
                result.MonomVector[i] = (ushort)(this.MonomVector[i] & monom.MonomVector[i]);
            }

            return result;
        }

        protected override MonomBase And(MonomBase monom)
        {
            if (monom is not MonomX)
            {
                throw new ArgumentException("There should be the same type of monom");
            }

            var result = new MonomX();

            for (int i = 0; i < VariablesCount; i++)
            {
                result.MonomVector[i] = (ushort)(this.MonomVector[i] | monom.MonomVector[i]);
            }

            return result;
        }
    }
}
