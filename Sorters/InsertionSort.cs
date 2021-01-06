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
        public static void InsertionSort<T>(Span<T> span) where T : IComparable<T> {
            for(int i = 0; i < span.Length - 1; i++) {
                for(int j = i + 1; j > 0; j--) {
                    if(span[j].CompareTo(span[j-1]) > 0) {
                        break;
                    }
                    span.Swap(j, j - 1);
                }
            }
        }
    }
}
