using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaProject
{
    public class XRow : MonomRowBase
    {
        
        private MonomBase[] _rowVector = new MonomX[Constants.XMonomsCount];

        override public int MonomsCount => Constants.XMonomsCount;

        override public MonomBase[] RowVector
        {
            get => _rowVector;
            set => _rowVector = value;
        }

        protected override void Init()
        {
            for(int i = 0; i < MonomX.variablesCount; i++)
            {
                for (int j = i; j < MonomX.variablesCount; j++)
                {
                    var monom = new MonomX();
                    monom.MonomVector[i] = 1;
                    monom.MonomVector[j] = 1;
                    _rowVector[monom.IndexInArray()] = monom;
                }
            }
        }

    }
}
