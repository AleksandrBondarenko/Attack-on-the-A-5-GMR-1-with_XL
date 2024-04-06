using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaProject
{
    public class ZRow : MonomRowBase
    {
        public const int _ZMonomsCount = 276;

        private MonomBase[] _rowVector = new MonomZ[_ZMonomsCount];

        override public int MonomsCount => _ZMonomsCount;

        override public MonomBase[] RowVector
        {
            get => _rowVector;
            set => _rowVector = value;
        }
    }
}
