using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaProject
{
    public class EquentialsGenerator
    {
        private List<MonomBase>[] XRegestry = new List<MonomBase>[Constants.XVariablesCount];
        private List<MonomBase>[] YRegestry = new List<MonomBase>[Constants.YVariablesCount];
        private List<MonomBase>[] ZRegestry = new List<MonomBase>[Constants.ZVariablesCount];

        public EquentialsGenerator()
        {
            Initialize();
        }

        private void Initialize()
        {
            for(int i = 0; i < Constants.XVariablesCount; i++)
            {
                XRegestry[i] = new List<MonomBase>();
                var monom = new MonomX();
                monom.MonomVector[i] = 1;
                XRegestry[i].Add(monom);

            }

            for (int i = 0; i < Constants.YVariablesCount; i++)
            {
                YRegestry[i] = new List<MonomBase>();
                var monom = new MonomY();
                monom.MonomVector[i] = 1;
                YRegestry[i].Add(monom);
            }

            for (int i = 0; i < Constants.ZVariablesCount; i++)
            {
                ZRegestry[i] = new List<MonomBase>();
                var monom = new MonomZ();
                monom.MonomVector[i] = 1;
                ZRegestry[i].Add(monom);
            }
        }

        private void RotateX()
        {
            var last = XRegestry[Constants.XVariablesCount - 1];

            //calculate new - 13, 16, 17
            
            foreach(var monom in XRegestry[17])
            {
                if (last.Contains(monom))
                {
                    last.Remove(monom);
                }
                else
                {
                    last.Add(monom);
                }
            }

            foreach (var monom in XRegestry[16])
            {
                if (last.Contains(monom))
                {
                    last.Remove(monom);
                }
                else
                {
                    last.Add(monom);
                }
            }

            foreach (var monom in XRegestry[13])
            {
                if (last.Contains(monom))
                {
                    last.Remove(monom);
                }
                else
                {
                    last.Add(monom);
                }
            }

            for (int i = Constants.XVariablesCount - 1; i > 0; i--)
            {
                XRegestry[i] = XRegestry[i - 1];
            }

            XRegestry[0] = last;
        }

        private void RotateY()
        {
            var last = YRegestry[Constants.YVariablesCount - 1];

            //calculate new - 12, 16, 20

            foreach (var monom in YRegestry[20])
            {
                if (last.Contains(monom))
                {
                    last.Remove(monom);
                }
                else
                {
                    last.Add(monom);
                }
            }

            foreach (var monom in YRegestry[16])
            {
                if (last.Contains(monom))
                {
                    last.Remove(monom);
                }
                else
                {
                    last.Add(monom);
                }
            }

            foreach (var monom in YRegestry[12])
            {
                if (last.Contains(monom))
                {
                    last.Remove(monom);
                }
                else
                {
                    last.Add(monom);
                }
            }

            for (int i = Constants.YVariablesCount - 1; i > 0; i--)
            {
                YRegestry[i] = YRegestry[i - 1];
            }

            YRegestry[0] = last;
        }
        private void RotateZ()
        {
            var last = ZRegestry[Constants.ZVariablesCount - 1];

            //calculate new - 17, 18, 21

            foreach (var monom in ZRegestry[21])
            {
                if (last.Contains(monom))
                {
                    last.Remove(monom);
                }
                else
                {
                    last.Add(monom);
                }
            }

            foreach (var monom in ZRegestry[18])
            {
                if (last.Contains(monom))
                {
                    last.Remove(monom);
                }
                else
                {
                    last.Add(monom);
                }
            }

            foreach (var monom in ZRegestry[17])
            {
                if (last.Contains(monom))
                {
                    last.Remove(monom);
                }
                else
                {
                    last.Add(monom);
                }
            }

            for (int i = Constants.ZVariablesCount - 1; i > 0; i--)
            {
                ZRegestry[i] = ZRegestry[i - 1];
            }

            ZRegestry[0] = last;
        }

        public List<XRow> GenerateX(int count)
        {
            var generetedSet = new List<List<MonomX>>();

            for (int i = 0; i < count; i++)
            {
                var resultList = new List<MonomBase>();

                Func(XRegestry, resultList, 1, 6);
                Func(XRegestry, resultList, 1, 15);
                Func(XRegestry, resultList, 6, 15);

                foreach (var item in XRegestry[11])
                {
                    if (resultList.Contains(item))
                    {
                        resultList.Remove(item);
                        continue;
                    }
                    resultList.Add(item);
                }

                generetedSet.Add(resultList.Select(x => 
                {
                    x.PresentState = PresentFlag.Present;
                    return (MonomX)x;
                }).ToList());

                resultList.Clear();

                RotateX();
            }

            return generetedSet.Select(m => ToXRow(m)).ToList();

        }

        public List<YRow> GenerateY(int count)
        {
            var generetedSet = new List<List<MonomY>>();

            for (int i = 0; i < count; i++)
            {
                var resultList = new List<MonomBase>();

                Func(YRegestry, resultList, 3, 8);
                Func(YRegestry, resultList, 3, 14);
                Func(YRegestry, resultList, 8, 14);

                foreach (var item in YRegestry[1])
                {
                    if (resultList.Contains(item))
                    {
                        resultList.Remove(item);
                        continue;
                    }
                    resultList.Add(item);
                }

                generetedSet.Add(resultList.Select(x => 
                { 
                    x.PresentState = PresentFlag.Present; 
                    return (MonomY)x; 
                }).ToList());

                resultList.Clear();

                RotateY();
            }

            return generetedSet.Select(m => ToYRow(m)).ToList(); ;

        }

        public List<ZRow> GenerateZ(int count)
        {
            var generetedSet = new List<List<MonomZ>>();

            for (int i = 0; i < count; i++)
            {
                var resultList = new List<MonomBase>();

                Func(ZRegestry, resultList, 4, 15);
                Func(ZRegestry, resultList, 4, 19);
                Func(ZRegestry, resultList, 15, 19);

                foreach (var item in ZRegestry[0])
                {
                    if (resultList.Contains(item))
                    {
                        resultList.Remove(item);
                        continue;
                    }
                    resultList.Add(item);
                }

                generetedSet.Add(resultList.Select(x =>
                {
                    x.PresentState = PresentFlag.Present;
                    return (MonomZ)x;
                }).ToList());

                resultList.Clear();

                RotateZ();
            }

            return generetedSet.Select(m => ToZRow(m)).ToList();

        }

        private void Func(List<MonomBase>[] source, List<MonomBase> resultList, int pos_1, int pos_2)
        {
            foreach (var first in source[pos_1])
            {
                foreach (var second in source[pos_2])
                {
                    var resultMonom = first | second;

                    if (resultList.Contains(resultMonom))
                    {
                        resultList.Remove(resultMonom);
                        continue;
                    }
                    resultList.Add(resultMonom);
                }
            }
        }

        private XRow ToXRow(List<MonomX> monoms)
        {
            var result = new XRow();

            foreach(var monom in monoms)
            {
                result.RowVector[monom.IndexInArray()] ^= monom;
            }

            return result;
        }

        private YRow ToYRow(List<MonomY> monoms)
        {
            var result = new YRow();

            foreach (var monom in monoms)
            {
                result.RowVector[monom.IndexInArray()] ^= monom;
            }

            return result;
        }

        private ZRow ToZRow(List<MonomZ> monoms)
        {
            var result = new ZRow();

            foreach (var monom in monoms)
            {
                result.RowVector[monom.IndexInArray()] ^= monom;
            }

            return result;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            return sb.ToString();
        }
    }
}
