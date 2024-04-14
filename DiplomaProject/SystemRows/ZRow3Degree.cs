using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DiplomaProject
{
    public class ZRow3Degree : MonomRowBase
    {
        private MonomZ[] _rowVector = new MonomZ[Constants.ZMonomsCountThirdDegree];

        override public int MonomsCount => Constants.ZMonomsCountThirdDegree;

        [JsonIgnore]
        override public MonomBase[] RowVector
        {
            get => _rowVector;
        }

        public ZRow3Degree(ZRow zrow) : base()
        {
            foreach (var row in zrow.RowVector)
            {
                RowVector[row.IndexInArrayThirdDegree()] ^= row;
            }
        }

        public ZRow3Degree() : base() { }

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
                    for (int k = j; k < Constants.ZVariablesCount; k++)
                    {
                        var monom = new MonomZ();
                        monom.MonomVector[i] = 1;
                        monom.MonomVector[j] = 1;
                        monom.MonomVector[k] = 1;
                        _rowVector[monom.IndexInArrayThirdDegree()] = monom;
                    }
                }
            }
        }
    }
}
