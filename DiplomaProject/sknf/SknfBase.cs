using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaProject
{
    public abstract class SknfBase
    {
        public abstract int FormSize { get; }

        public abstract List<ushort[]> SKNF { get; }

        public ushort Value { get; set; }

        public static SknfBase Diff(SknfBase a, SknfBase b)
        {
            if (a.GetType()  != b.GetType())
            {
                throw new ArgumentException();
            }

            return a.DiffInternal(b);
        }

        protected abstract SknfBase DiffInternal(SknfBase another); 
    }
}
