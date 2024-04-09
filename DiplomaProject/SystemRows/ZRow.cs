using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaProject
{
    public class ZRow : MonomRowBase
    {
        private MonomBase[] _rowVector = new MonomZ[Constants.ZMonomsCount];

        override public int MonomsCount => Constants.ZMonomsCount;

        override public MonomBase[] RowVector
        {
            get => _rowVector;
            set => _rowVector = value;
        }

        protected override void Init()
        {
            for (int i = 0; i < MonomZ.variablesCount; i++)
            {
                for (int j = i; j < MonomZ.variablesCount; j++)
                {
                    var monom = new MonomZ();
                    monom.MonomVector[i] = 1;
                    monom.MonomVector[j] = 1;
                    _rowVector[monom.IndexInArray()] = monom;
                }
            }
        }
    }
}
