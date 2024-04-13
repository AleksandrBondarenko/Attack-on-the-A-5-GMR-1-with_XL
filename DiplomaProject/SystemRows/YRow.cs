using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DiplomaProject
{
    public class YRow : MonomRowBase
    {
        private MonomY[] _rowVector = new MonomY[Constants.YMonomsCount];

        override public int MonomsCount => Constants.YMonomsCount;

        [JsonIgnore]
        override public MonomBase[] RowVector
        {
            get => _rowVector;
        }

        public MonomY[] RowYVector
        {
            get => _rowVector;
            set => _rowVector = value;
        }

        protected override void Init()
        {
            for (int i = 0; i < Constants.YVariablesCount; i++)
            {
                for (int j = i; j < Constants.YVariablesCount; j++)
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
