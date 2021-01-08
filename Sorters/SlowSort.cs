using CSharpExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorters
{
    public partial class Sorter
    {
        public static void SlowSort<T>(Span<T> span) where T : IComparable<T> {
            if (span.Length <= 1) {
                return;
            }

            int mid = span.Length / 2;
            SlowSort(span.Slice(0, mid));
            SlowSort(span.Slice(mid));
            if (span[span.Length - 1].CompareTo(span[mid - 1]) < 0) {
                span.Swap(span.Length - 1, mid - 1);
            }
            SlowSort(span.Slice(0, span.Length - 1));
        }
    }
}
