using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaProject
{
    public class SingleMonomSystemRow
    {
        public MonomRowBase ZRow { get; set; }

        public ushort Value { get; set; }

        public int Size { get => Constants.ZMonomsCountThirdDegree; }

        public SingleMonomSystemRow(ZRow zRow, ushort value)
        {
            ZRow = new ZRow3Degree(zRow);
            Value = value;
        }

        public SingleMonomSystemRow()
        {
            Init();
        }

        protected void Init()
        {
            ZRow = new ZRow3Degree();
        }


        public MonomBase this[int key]
        {
            get
            {
                if (key < Size && key >= 0)
                {
                    return ZRow.RowVector[key];
                }

                throw new IndexOutOfRangeException();
            }

            set
            {
                if (key < Size && key >= 0)
                {
                    ZRow.RowVector[key] = value;
                }

                throw new IndexOutOfRangeException();
            }
        }

        //XOR
        public static SingleMonomSystemRow operator &(SingleMonomSystemRow a, MonomZ b)
        {
            var res = new SingleMonomSystemRow();
            foreach (var monom in a.ZRow.RowVector.Where(m => m.PresentState == PresentFlag.Present))
            {
                var newMonom = monom & b;
                newMonom.PresentState = PresentFlag.Present;
                res.ZRow.RowVector[newMonom.IndexInArrayThirdDegree()] ^= newMonom;
            }
            if (a.Value == 1)
            {
                res.ZRow.RowVector[b.IndexInArrayThirdDegree()] ^= b;
                res.Value = 0;
            }

            return res;
        }

        public static SingleMonomSystemRow operator ^(SingleMonomSystemRow a, SingleMonomSystemRow b)
        {
            a.ZRow ^= b.ZRow;

            a.Value ^= b.Value;

            return a;
        }

        public override string ToString()
        {
            return $"{ZRow.ToString()} = {Value}";
        }
    }
}
