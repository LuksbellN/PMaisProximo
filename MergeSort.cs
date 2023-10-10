using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMaisProx
{
    public class MergeSort
    {
        public static void MergeSortByY(int[][] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;
                MergeSortByY(arr, left, mid);
                MergeSortByY(arr, mid + 1, right);
                Merge(arr, left, mid, right);
            }
        }

        static void Merge(int[][] arr, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;

            int[][] L = new int[n1][];
            int[][] R = new int[n2][];

            for (int i = 0; i < n1; ++i)
            {
                L[i] = new int[] { arr[left + i][0], arr[left + i][1] };
            }
            for (int j = 0; j < n2; ++j)
            {
                R[j] = new int[] { arr[mid + 1 + j][0], arr[mid + 1 + j][1] };
            }

            int x = 0, y = 0, k = left;
            while (x < n1 && y < n2)
            {
                if (L[x][1] <= R[y][1])
                {
                    arr[k][0] = L[x][0];
                    arr[k][1] = L[x][1];
                    x++;
                }
                else
                {
                    arr[k][0] = R[y][0];
                    arr[k][1] = R[y][1];
                    y++;
                }
                k++;
            }

            while (x < n1)
            {
                arr[k][0] = L[x][0];
                arr[k][1] = L[x][1];
                x++;
                k++;
            }

            while (y < n2)
            {
                arr[k][0] = R[y][0];
                arr[k][1] = R[y][1];
                y++;
                k++;
            }
        }
    }
}
