using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorters
{
    public partial class Sorter
    {
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
    }
}
