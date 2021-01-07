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
        public static void StoogeSort<T>(Span<T> span) where T : IComparable<T> {
            if(span.Length < 2) {
                return;
            }

            if(span[0].CompareTo(span[span.Length - 1]) > 0) {
                span.Swap(0, span.Length - 1);
            }

            if(span.Length > 2) {
                int oneThird = span.Length / 3;
                int twoThirds = span.Length - oneThird;

                Span<T> firstTwoThirds = span.Slice(0, twoThirds);
                Span<T> lastTwoThirds = span.Slice(oneThird);

                StoogeSort(firstTwoThirds);
                StoogeSort(lastTwoThirds);
                StoogeSort(firstTwoThirds);
            }
        }
    }
}
