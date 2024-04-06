using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaProject
{
    public class GammaGenerator
    {
        void rotate_1(ref uint reg_1)
        {
            reg_1 = ((reg_1 << 1) | (((reg_1 >>> 18) ^ (reg_1 >>> 17) ^ (reg_1 >>> 16) ^ (reg_1 >>> 13)) & 1)) & 0x7ffff;
        }
        void rotate_2(ref uint reg_2)
        {
            reg_2 = ((reg_2 << 1) | (((reg_2 >>> 21) ^ (reg_2 >>> 20) ^ (reg_2 >>> 16) ^ (reg_2 >>> 12)) & 1)) & 0x3fffff;
        }
        void rotate_3(ref uint reg_3)
        {
            reg_3 = ((reg_3 << 1) | (((reg_3 >>> 22) ^ (reg_3 >>> 21) ^ (reg_3 >>> 18) ^ (reg_3 >>> 17)) & 1)) & 0x7fffff;
        }
        void rotate_4(ref uint reg_4)
        {
            reg_4 = ((reg_4 << 1) | (((reg_4 >>> 16) ^ (reg_4 >>> 13) ^ (reg_4 >>> 12) ^ (reg_4 >>> 8)) & 1)) & 0x1ffff;
        }
        ushort rotate_1234(ref uint reg_1, ref uint reg_2, ref uint reg_3, ref uint reg_4)
        {
            uint ctrl = (((reg_4 >>> 15) & 1) << 2) | (((reg_4 >>> 6) & 1) << 1) | (((reg_4 >>> 1) & 1) << 0);
            if (((0xE8U >>> (int)ctrl) & 1) == ((reg_4 >>> 15) & 1))
            {
                rotate_1(ref reg_1);
            }
            if (((0xE8U >>> (int)ctrl) & 1) == ((reg_4 >>> 6) & 1))
            {
                rotate_2(ref reg_2);
            }
            if (((0xE8U >>> (int)ctrl) & 1) == ((reg_4 >> 1) & 1))
            {
                rotate_3(ref reg_3);
            }
            uint sum_1 = (((reg_1 >> 15) & 1) << 2) | (((reg_1 >> 6) & 1) << 1) | (((reg_1 >> 1) & 1) << 0);
            uint sum_2 = (((reg_2 >> 14) & 1) << 2) | (((reg_2 >> 8) & 1) << 1) | (((reg_2 >> 3) & 1) << 0);
            uint sum_3 = (((reg_3 >>> 19) & 1) << 2) | (((reg_3 >>> 15) & 1) << 1) | (((reg_3 >>> 4) & 1) << 0);
            rotate_4(ref reg_4);
            return (ushort)(((0xE8U >>> (int)sum_1) & 1) ^ ((0xE8U >>> (int)sum_2) & 1) ^ ((0xE8U >>> (int)sum_3) & 1) ^ ((reg_1 >>> 11) & 1) ^ ((reg_2 >>> 1) & 1) ^ ((reg_3 >>> 0) & 1));
        }
        void init_1234(ref uint reg_1, ref uint reg_2,
        ref uint reg_3, ref uint reg_4, ulong key)
        {
            for (ulong i = 0; i < 64; i++)
            {
                rotate_1(ref reg_1);
                rotate_2(ref reg_2);
                rotate_3(ref reg_3);
                rotate_4(ref reg_4);
                reg_1 ^= (uint)((key >>> (int)i) & 1);
                reg_2 ^= (uint)((key >>> (int)i) & 1);
                reg_3 ^= (uint)((key >>> (int)i) & 1);
                reg_4 ^= (uint)((key >>> (int)i) & 1);
            }

            reg_1 |= 1;
            reg_2 |= 1;
            reg_3 |= 1;
            reg_4 |= 1;

            for (int i = 0; i< 250; i++)
            {
                rotate_1(ref reg_1);
                rotate_2(ref reg_2);
                rotate_3(ref reg_3);
                rotate_4(ref reg_4);
            }
        }

        public List<ushort> GenerateGamma(ulong key, int count)
        {
            uint reg_1 = 0;
            uint reg_2 = 0;
            uint reg_3 = 0;
            uint reg_4 = 0;

            init_1234(ref reg_1, ref reg_2, ref reg_3, ref reg_4, key);

            var result = new List<ushort>();

            for (int i = 0; i < count; i++)
            {
                result.Add(rotate_1234(ref reg_1, ref reg_2, ref reg_3, ref reg_4));
            }

            return result;
        }

    }
}
