﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorters
{
    public partial class Sorter
    {
        public static void TimSort<T>(Span<T> span) where T : IComparable<T> {
            
            for(int i = 0; i < span.Length; i += timSortRunLength) {
                int remaining = Math.Min(span.Length - i, timSortRunLength);
                Span<T> spanSlice = span.Slice(i, remaining);
                InsertionSort(spanSlice);
            }

            for(int mergeSize = timSortRunLength; mergeSize < span.Length; mergeSize *= 2) {
                for(int leftStart = 0; leftStart < span.Length; leftStart += 2 * mergeSize) {

                    int leftSize = Math.Min(mergeSize, span.Length - leftStart);
                    int rightSize = leftSize == mergeSize ? 
                        Math.Min(mergeSize, span.Length - (leftStart + mergeSize) ):
                        0;

                    Span<T> left = span.Slice(leftStart, leftSize);
                    Span<T> right = span.Slice(leftStart + leftSize, rightSize);

                    Merge(left, right);
                }
            }
        }
    }
}
