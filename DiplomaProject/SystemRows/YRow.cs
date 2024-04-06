using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaProject
{
    public class YRow : MonomRowBase
    {
        private MonomBase[] _rowVector = new MonomY[_YMonomsCount];

        public const int _YMonomsCount = 253;

        override public int MonomsCount => _YMonomsCount;

        override public MonomBase[] RowVector
        {
            get => _rowVector;
            set => _rowVector = value;
        }
    }
}
