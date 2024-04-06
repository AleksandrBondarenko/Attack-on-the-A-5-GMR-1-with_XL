using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaProject
{
    public class SystemRow
    {
        public MonomRowBase XRow { get; set; }

        public MonomRowBase YRow { get; set; }

        public MonomRowBase ZRow { get; set; }

        public ushort Value { get; set; }

        public int Size { get => XRow.MonomsCount + YRow.MonomsCount + ZRow.MonomsCount; }

        public SystemRow(XRow xRow, ZRow zRow, YRow yRow, ushort value)
        {
            XRow = xRow;
            YRow = yRow;
            ZRow = zRow;
            Value = value;
        }

        public MonomBase this[int key]
        {
            get
            {
                if (key < XRow.MonomsCount && key >= 0)
                {
                    return XRow.RowVector[key];
                }
                else if (key < (XRow.MonomsCount + YRow.MonomsCount) && key >= 0)
                {
                    return YRow.RowVector[key - XRow.MonomsCount];
                }
                else if (key < (XRow.MonomsCount + XRow.MonomsCount + ZRow.MonomsCount) && key >= 0)
                {
                    return ZRow.RowVector[key - YRow.MonomsCount - XRow.MonomsCount];
                }

                throw new IndexOutOfRangeException();
            }

            set
            {
                if (key < XRow.MonomsCount && key >= 0)
                {
                    XRow.RowVector[key] = value;
                }
                else if (key < (XRow.MonomsCount + YRow.MonomsCount) && key >= 0)
                {
                    YRow.RowVector[key - XRow.MonomsCount] = value;
                }
                else if (key < (XRow.MonomsCount + XRow.MonomsCount + ZRow.MonomsCount) && key >= 0)
                {
                    ZRow.RowVector[key - YRow.MonomsCount - XRow.MonomsCount] = value;
                }

                throw new IndexOutOfRangeException();
            }
        }

            //XOR
        public static SystemRow operator ^(SystemRow a, SystemRow b)
        {
            a.XRow ^= b.XRow;
            a.YRow ^= b.YRow;
            a.ZRow ^= b.ZRow;

            a.Value ^= b.Value;

            return a;
        }
    }
}
