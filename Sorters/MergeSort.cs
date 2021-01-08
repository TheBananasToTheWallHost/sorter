using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sorters
{
    public partial class Sorter {

        #region Optimized Merge Sort
        public static void UnmanagedMergeSort<T>(Span<T> span) where T : unmanaged, IComparable<T> {
            Span<T> tempBuffer = (Unsafe.SizeOf<T>() * span.Length) < MAX_STACK_ALLOC_SIZE ?
                stackalloc T[span.Length] : 
                new T[span.Length];

            MergeSort(span, tempBuffer);
        }

        public static void ManagedMergeSort<T>(Span<T> span) where T : IComparable<T> {
            Span<T> tempBuffer = new T[span.Length];

            MergeSort(span, tempBuffer);
        }

        private static void MergeSort<T>(Span<T> span, Span<T> buffer) where T : IComparable<T> {
            if (span.Length <= 1) {
                return;
            }

            int middle = span.Length / 2;

            Span<T> left = span.Slice(0, middle);
            Span<T> right = span.Slice(middle);

            MergeSort(left, buffer);
            MergeSort(right, buffer);

            Merge(left, right, buffer);
        }

        private static void Merge<T>(Span<T> leftSpan, Span<T> rightSpan, Span<T> buffer) where T : IComparable<T> {
            if (leftSpan.Length < 1 || rightSpan.Length < 1) {
                return;
            }

            if (leftSpan[leftSpan.Length - 1].CompareTo(rightSpan[0]) <= 0) {
                return;
            }

            Span<T> bufferSlice = buffer.Slice(0, leftSpan.Length + rightSpan.Length);

            int leftIndex = 0, rightIndex = 0, storageIndex = 0;
            while (leftIndex < leftSpan.Length && rightIndex < rightSpan.Length) {
                if (leftSpan[leftIndex].CompareTo(rightSpan[rightIndex]) < 1) {
                    bufferSlice[storageIndex] = leftSpan[leftIndex];
                    leftIndex++;
                }
                else {
                    bufferSlice[storageIndex] = rightSpan[rightIndex];
                    rightIndex++;
                }
                storageIndex++;
            }

            while (leftIndex < leftSpan.Length) {
                bufferSlice[storageIndex] = leftSpan[leftIndex];
                leftIndex++;
                storageIndex++;
            }
            while (rightIndex < rightSpan.Length) {
                bufferSlice[storageIndex] = rightSpan[rightIndex];
                rightIndex++;
                storageIndex++;
            }

            bufferSlice.Slice(0, leftSpan.Length).CopyTo(leftSpan);
            bufferSlice.Slice(leftSpan.Length).CopyTo(rightSpan);
        }
        #endregion

        #region Basic Merge Sort
        public static void MergeSort<T>(Span<T> span) where T : IComparable<T> {
            if(span.Length <= 1) {
                return;
            }

            int middle = span.Length / 2;

            Span<T> left = span.Slice(0, middle);
            Span<T> right = span.Slice(middle);

            MergeSort(left);
            MergeSort(right);

            Merge(left, right);
        }

        private static void Merge<T>(Span<T> leftSpan, Span<T> rightSpan) where T : IComparable<T> {
            if (leftSpan.Length < 1 || rightSpan.Length < 1) {
                return;
            }

            if(leftSpan[leftSpan.Length - 1].CompareTo(rightSpan[0]) <= 0) {
                return;
            }

            T[] tempStorage = new T[leftSpan.Length + rightSpan.Length];

            int leftIndex = 0, rightIndex = 0, storageIndex = 0;
            while (leftIndex < leftSpan.Length && rightIndex < rightSpan.Length) {
                if(leftSpan[leftIndex].CompareTo(rightSpan[rightIndex]) < 1) {
                    tempStorage[storageIndex] = leftSpan[leftIndex];
                    leftIndex++;
                }
                else {
                    tempStorage[storageIndex] = rightSpan[rightIndex];
                    rightIndex++;
                }
                storageIndex++;
            }

            while(leftIndex < leftSpan.Length) {
                tempStorage[storageIndex] = leftSpan[leftIndex];
                leftIndex++;
                storageIndex++;
            }
            while (rightIndex < rightSpan.Length) {
                tempStorage[storageIndex] = rightSpan[rightIndex];
                rightIndex++;
                storageIndex++;
            }

            for(int i = 0; i < tempStorage.Length; i++) {
                if(i < leftSpan.Length) {
                    leftSpan[i] = tempStorage[i];
                }
                else {
                    rightSpan[i - leftSpan.Length] = tempStorage[i];
                }
            }
        }
        #endregion
    }
}
