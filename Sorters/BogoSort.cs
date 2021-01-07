using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Sorters
{
    public partial class Sorter
    {
        public static void RandomBogoSort<T>(Span<T> span) where T : IComparable<T> {
            while (!IsSorted(span)) {
                Shuffle(span);
            }
        }

        public static void DeterministicBogoSort<T>(Span<T> span) where T : IComparable<T> {
            GeneratePermutations(span);
        }

        private static void GeneratePermutations<T>(Span<T> span) where T : IComparable<T> {
            List<int> indices = new List<int>();
            bool permutationFound = false;

            for (int i = 0; i < span.Length; i++) {
                indices.Add(i);
            }

            Permute(span, indices, new List<T>(), ref permutationFound);
        }

        private static void Permute<T>(Span<T> span, List<int> availableIndices, List<T> permutation, ref bool permutationFound) where T : IComparable<T> {
            if (permutationFound) {
                return;
            }
            
            if (permutation.Count == span.Length) {
                if (IsSorted(permutation)) {
                    permutationFound = true;
                    for (int i = 0; i < span.Length; i++) {
                        span[i] = permutation[i];
                    }
                }
                return;
            }

            

            for (int i = 0; i < availableIndices.Count; i++) {
                int nextValIndex = availableIndices[i];

                List<T> permutationCopy = new List<T>(permutation);
                permutationCopy.Add(span[nextValIndex]);

                List<int> indicesCopy = new List<int>(availableIndices);
                indicesCopy.RemoveAt(i);
                
                Permute(span, indicesCopy, permutationCopy, ref permutationFound);
            }
        }

        private static void Shuffle<T>(Span<T> span) {
            List<int> indices = new List<int>();

            for (int i = 0; i < span.Length; i++) {
                indices.Add(i);
            }

            int initialSwapIndex = RandomNumberGenerator.GetInt32(indices.Count);
            T swapVal = span[initialSwapIndex];
            indices.RemoveAt(initialSwapIndex);

            for (int i = 0; i < indices.Count; i++) {
                int index = RandomNumberGenerator.GetInt32(indices.Count);
                int swapIndex = indices[index];

                T temp = span[swapIndex];
                span[swapIndex] = swapVal;
                swapVal = temp;
            }

            span[initialSwapIndex] = swapVal;
        }

        private static bool IsSorted<T>(Span<T> span) where T : IComparable<T> {
            for (int i = 0; i < span.Length - 1; i++) {
                if (span[i].CompareTo(span[i + 1]) > 0) {
                    return false;
                }
            }
            return true;
        }

        private static bool IsSorted<T>(List<T> list) where T : IComparable<T> {
            for (int i = 0; i < list.Count - 1; i++) {
                if (list[i].CompareTo(list[i + 1]) > 0) {
                    return false;
                }
            }
            return true;
        }
    }
}
