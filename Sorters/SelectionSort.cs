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
        public static void SelectionSort<T>(Span<T> span) where T : IComparable<T> {
            for (int i = 0; i < span.Length; i++) {
                int minIndex = i;
                for (int j = i + 1; j < span.Length; j++) {
                    if (span[minIndex].CompareTo(span[j]) > 0) {
                        minIndex = j;
                    }
                }
                if (minIndex != i) {
                    span.Swap(i, minIndex);
                }
            }
        }

        public static void SelectionSort<T>(Span<T> span, IComparer<T> comparer) {

        }
    }
}
