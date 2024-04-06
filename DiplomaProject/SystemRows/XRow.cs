using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaProject
{
    public class XRow : MonomRowBase
    {
        
        private MonomBase[] _rowVector = new MonomX[_XMonomsCount];

        const int _XMonomsCount = 190;

        override public int MonomsCount => _XMonomsCount;

        override public MonomBase[] RowVector
        {
            get => _rowVector;
            set => _rowVector = value;
        }


    }
}
