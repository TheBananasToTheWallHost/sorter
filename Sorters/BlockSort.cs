using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorters
{
    public partial class Sorter
    {
        public static void BlockSort<T>(Span<T> span) where T : IComparable<T> {
            // TODO: will implement last
        }

        public static int FloorToPowerOfTwo(int x) {
            for(int i = 1; i < 32; i*=2) {
                x |= (x >> i);
            }
            return x - (x >> 1);
        }
    }
}
