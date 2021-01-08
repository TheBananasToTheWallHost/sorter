using NUnit.Framework;
using Sorters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SortTester
{
    public class SorterTests {
        public delegate void SortMethodDelegate<T>(Span<T> span);

        int[] unsortedInts;
        int[] sortedInts;
        char[] unsortedChars;
        char[] sortedChars;

        [SetUp]
        public void Setup() {
        }

        [TestCaseSource(nameof(IntSortingTestCases))]
        public void IntSortTest(int[] intArray, SortMethodDelegate<int> sortMethod) {
            PrepareTestArrays(intArray, out sortedInts, out unsortedInts);

            Span<int> intSpan = unsortedInts.AsSpan();
            sortMethod(intSpan);
            Assert.IsTrue(unsortedInts.SequenceEqual(sortedInts));
        }

        [TestCaseSource(nameof(CharSortingTestCases))]
        public void CharSortTest(char[] charArray, SortMethodDelegate<char> sortMethod) {
            PrepareTestArrays(charArray, out sortedChars, out unsortedChars);

            Span<char> charSpan = unsortedChars.AsSpan();
            sortMethod(charSpan);
            Assert.IsTrue(unsortedChars.SequenceEqual(sortedChars));
        }


        #region Data
        private static object[] IntArrays = {
            new int[] {},
            new int[] { 1, 5, 6, 7, 34, 2, 121, 34, 76, 5 },
            new int[] { 0, 0, 0, 0, 0},
            new int[] {-2, -10, -50, -2, -1, -9, -13, -12, -1, -5, -23}
        };

        private static object[] CharArrays = {
            new char[] {'z', 'c', 'a', 'b', 'd'},
            new char[] {'Z', 'X', 'A', 'B', 'I', 'P'},
            new char[] {'!', '@', ',', '"', '{', '`', '*', ')'},
            new char[] {'1', '4', '6', '0', '2', '9'},
            new char[] { 'a', 'b', 'm', 'z', ';', 'w', '!', '%', '+', 'C', 'K', 'P' },
            new char[] {}
        };

        private static IEnumerable<TestCaseData> TypeSortingTestCases<T>(object[] array) where T : IComparable<T> {
            Type type = typeof(T);
            for (int i = 0; i < array.Length; i++) {
                foreach (var sortMethod in GetSortingMethods<T>()) {
                    yield return new TestCaseData(array[i], sortMethod)
                        .SetName("{m}: {0}, " + sortMethod.Method.Name)
                        .SetDescription($"Sorts integers using {sortMethod.Method.Name}")
                        .SetCategory($"{sortMethod.Method.Name}")
                        .SetCategory($"{type.Name}");
                }
            }
        }

        private static IEnumerable<SortMethodDelegate<T>> GetSortingMethods<T>() where T : IComparable<T> {
            yield return Sorter.BubbleSort;
            yield return Sorter.MergeSort;
            yield return Sorter.InsertionSort;
            yield return Sorter.SelectionSort;
            yield return Sorter.OptimizedQuickSort;
            yield return Sorter.TimSort;
            yield return Sorter.RandomBogoSort;
            yield return Sorter.DeterministicBogoSort;
            yield return Sorter.StoogeSort;
            yield return Sorter.SlowSort;
            yield return Sorter.ManagedMergeSort;
        }
        #endregion

        #region Test Data Helpers
        private static IEnumerable CharSortingTestCases() {
            return TypeSortingTestCases<char>(CharArrays);
        }

        private static IEnumerable IntSortingTestCases() {
            return TypeSortingTestCases<int>(IntArrays);
        }
        #endregion

        #region Helpers
        private void PrepareTestArrays<T>(T[] dataArray, out T[] sortedArray, out T[] unsortedArray) {
            unsortedArray = new T[dataArray.Length];
            sortedArray = new T[dataArray.Length];
            dataArray.CopyTo(unsortedArray, 0);
            dataArray.CopyTo(sortedArray, 0);
            Array.Sort(sortedArray);
        }
        #endregion
    }
}