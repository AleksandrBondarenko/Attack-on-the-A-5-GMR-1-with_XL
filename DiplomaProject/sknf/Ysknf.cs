using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaProject
{
    public class Ysknf : SknfBase
    {
        private List<ushort[]> _sknf = new List<ushort[]>();
        public override int FormSize => Constants.YVariablesCount;

        public override List<ushort[]> SKNF => _sknf;

        protected override SknfBase DiffInternal(SknfBase another)
        {
            throw new NotImplementedException();
        }
    }
}
