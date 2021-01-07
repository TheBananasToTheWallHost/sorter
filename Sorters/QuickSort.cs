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
        public delegate (int, int) PartitionDelegate<T>(Span<T> span, int start, int end);

        public static void OptimizedQuickSort<T>(Span<T> span) where T : IComparable<T> {
            QuickSort(span, 0, span.Length - 1, OptimizedPartition);
        }

        private static void QuickSort<T>(Span<T> span, int start, int end, PartitionDelegate<T> partition) where T : IComparable<T> {
            if (start < end) {
                (int bottomEnd, int topStart) = partition(span, start, end);
                QuickSort(span, start, bottomEnd - 1, partition);
                QuickSort(span, topStart + 1, end, partition);
            }
        }

        /// <summary>
        /// Uses a median of three rule to select the pivot and uses a three-way partitioning method to deal with
        /// repeated values. The median of three rule is used in an attempt to try to balance the partitions so a
        /// roughly equal number of values are left to the right and left of the pivot after partitioning. 
        /// The three way partitioning algorithm can be found here:
        /// <see href="https://en.wikipedia.org/wiki/Dutch_national_flag_problem"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="span"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private static (int, int) OptimizedPartition<T>(Span<T> span, int start, int end) where T : IComparable<T> {
            int mid = start + (end - start) / 2;

            if (span[mid].CompareTo(span[start]) < 0) {
                span.Swap(mid, start);
            }
            if (span[end].CompareTo(span[start]) < 0) {
                span.Swap(end, start);
            }
            if (span[mid].CompareTo(span[end]) < 0) {
                span.Swap(end, mid);
            }

            T pivot = span[end];

            int i = 0;
            int j = 0;
            int k = end;

            while(j <= k) {
                if(span[j].CompareTo(pivot) < 0) {
                    span.Swap(i, j);
                    i++;
                    j++;
                }
                else if(span[j].CompareTo(pivot) > 0) {
                    span.Swap(j, k);
                    k--;
                }
                else {
                    j++;
                }
            }

            return (i, j - 1);
        }
    }
}
