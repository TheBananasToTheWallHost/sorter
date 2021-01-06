using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpExtensions;

namespace Sorters
{
    public partial class Sorter
    {
        public static void BubbleSort<T>(Span<T> span) where T : IComparable<T> {
            for (int i = 0; i < span.Length - 1; i++) {
                for (int j = 0; j < span.Length - i - 1; j++) {
                    if (span[j].CompareTo(span[j + 1]) > 0) {
                        span.Swap(j, j + 1);
                    }
                }
            }
        }
    }
}
