using System;
using System.Collections.Generic;
using CSharpExtensions;

namespace Sorters
{
    public class Sorter
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

        public static void SelectionSort<T>(Span<T> span) where T : IComparable<T> {

        }

        public static void SelectionSort<T>(Span<T> span, IComparer<T> comparer) {

        }

        public static void InsertionSort<T>(Span<T> span) where T : IComparable<T> {

        }

        public static void MergeSort<T>(Span<T> span) where T : IComparable<T> {

        }

        public static void QuickSort<T>(Span<T> span) where T : IComparable<T> {

        }

        public static void TimSort<T>(Span<T> span) where T : IComparable<T> {

        }

        public static void HeapSort<T>(Span<T> span) where T : IComparable<T> {

        }

        public static void BogoSort<T>(Span<T> span) where T : IComparable<T> {

        }
    }
}
