using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DiplomaProject
{
    public class XRow : MonomRowBase
    {
        
        private MonomX[] _rowVector = new MonomX[Constants.XMonomsCount];

        override public int MonomsCount => Constants.XMonomsCount;

        [JsonIgnore]
        override public MonomBase[] RowVector
        {
            get => _rowVector;
        }

        public MonomX[] RowXVector
        {
            get => _rowVector;
            set => _rowVector = value;
        }

        protected override void Init()
        {
            for(int i = 0; i < Constants.XVariablesCount; i++)
            {
                for (int j = i; j < Constants.XVariablesCount; j++)
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
