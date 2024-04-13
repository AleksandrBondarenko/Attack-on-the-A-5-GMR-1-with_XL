using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DiplomaProject
{
    public class ZRow : MonomRowBase
    {
        private MonomZ[] _rowVector = new MonomZ[Constants.ZMonomsCount];

        override public int MonomsCount => Constants.ZMonomsCount;

        [JsonIgnore]
        override public MonomBase[] RowVector
        {
            get => _rowVector;
        }

        public MonomZ[] RowZVector
        {
            get => _rowVector;
            set => _rowVector = value;
        }

        protected override void Init()
        {
            for (int i = 0; i < Constants.ZVariablesCount; i++)
            {
                for (int j = i; j < Constants.ZVariablesCount; j++)
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
