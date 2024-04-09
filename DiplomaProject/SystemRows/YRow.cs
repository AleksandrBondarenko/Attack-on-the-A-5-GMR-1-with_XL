using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaProject
{
    public class YRow : MonomRowBase
    {
        private MonomBase[] _rowVector = new MonomY[Constants.YMonomsCount];

        override public int MonomsCount => Constants.YMonomsCount;

        override public MonomBase[] RowVector
        {
            get => _rowVector;
            set => _rowVector = value;
        }

        protected override void Init()
        {
            for (int i = 0; i < MonomY.variablesCount; i++)
            {
                for (int j = i; j < MonomY.variablesCount; j++)
                {
                    var monom = new MonomY();
                    monom.MonomVector[i] = 1;
                    monom.MonomVector[j] = 1;
                    _rowVector[monom.IndexInArray()] = monom;
                }
            }
        }
    }
}
