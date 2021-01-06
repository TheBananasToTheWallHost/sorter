using NUnit.Framework;
using Sorters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SortTester
{
    public class SorterTests
    {
        int[] unsortedInts;
        int[] sortedInts;
        char[] unsortedChars;
        char[] sortedChars;

        [SetUp]
        public void Setup() {
            unsortedChars = new char[] { 'a', 'b', 'm', 'z', ';', 'w', '!', '%', '+', 'C', 'K', 'P' };
            sortedChars = new char[unsortedChars.Length];
            unsortedChars.CopyTo(sortedChars, 0);
            
            Array.Sort(sortedChars);
        }

        [TestCaseSource(nameof(IntArrays))]
        public void IntBubbleSortTest(int[] intArray) {
            PrepareTestArrays(intArray, out sortedInts, out unsortedInts);

            Span<int> intSpan = unsortedInts.AsSpan();
            Sorter.BubbleSort(intSpan);
            Assert.IsTrue(unsortedInts.SequenceEqual(sortedInts));
            //Span<char> charSpan = unsortedChars.AsSpan();
        }

        [TestCaseSource(nameof(CharArrays))]
        public void CharBubbleSortTest(char[] charArray) {
            PrepareTestArrays(charArray, out sortedChars, out unsortedChars);

            Span<char> charSpan = unsortedChars.AsSpan();
            Sorter.BubbleSort(charSpan);
            Assert.IsTrue(unsortedChars.SequenceEqual(sortedChars));
        }

        private void PrepareTestArrays<T>(T[] dataArray, out T[] sortedArray, out T[] unsortedArray) {
            unsortedArray = new T[dataArray.Length];
            sortedArray = new T[dataArray.Length];
            dataArray.CopyTo(unsortedArray, 0);
            dataArray.CopyTo(sortedArray, 0);
            Array.Sort(sortedArray);
        }

        private static object[] IntArrays = {
            new int[] {},
            new int[] { 1, 5, 3, 6, 7, 34, 2, 121, 34, 76, 5, 4, 32, 87, 6, 5, 9 },
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
    }
}