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

        private static readonly short MAX_STACK_ALLOC_SIZE = 4096;
        #endregion

        public static void HeapSort<T>(Span<T> span) where T : IComparable<T> {

        }

        public static void TreeSort<T>(Span<T> span) where T : IComparable<T> {

        }
    }
}
