using System;
using System.Collections.Generic;
using CSharpExtensions;

namespace Sorters
{
    public partial class Sorter
    {
        #region Fields/Properties
        private static int timSortRunLength = 32;
        public static int TimSortRunLength {
            get => timSortRunLength;
            set => timSortRunLength = value;
        }
        #endregion

        public static void HeapSort<T>(Span<T> span) where T : IComparable<T> {

        }

        public static void SlowSort<T>(Span<T> span) where T : IComparable<T> {

        }

        public static void TreeSort<T>(Span<T> span) where T : IComparable<T> {

        }

        public static void BlockSort<T>(Span<T> span) where T : IComparable<T> {

        }
    }
}
