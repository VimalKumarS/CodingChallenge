using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    class VMWAre
    {
        public int[] swap1(int[] A,int i,int j)
        {
            int temp = A[i];
            A[i] = A[j];
            A[j] = temp;
            return A;
        }

        public void swap(ref int[] A, int i, int j)
        {
            int temp = A[i];
            A[i] = A[j];
            A[j] = temp;
            //return A;
        }
        public void permute(ref int[] A,int l , int r)
        {
            //int[] A={5,1,4,3};

            if (l == r)
            {
                int sum = 0;
                for (int i = 0; i < A.Length; i++)
                {
                    sum = sum + ((i + 1) * A[i]);
                }
                Console.WriteLine(sum);
            }
            else
            {
                for (int i = l; i < r; i++)
                {
                    swap(ref A, l, i);
                    permute(ref A, l + 1, r);
                    swap(ref A, l, i);
                }

            }
        }

        public void vmQuestion(int[] A)
        {
            //int length = Convert.ToInt32(Console.ReadLine());
            //int[] B = Console.ReadLine().Split().Select(x => Convert.ToInt32(x)).ToArray();
            int sum = 0;
            for (int i = 0; i < A.Length; i++)
            {
                sum = sum + ((i + 1) * A[i]);
            }

           
            int min=sum;
            for (int i = 1; i < A.Length; i++)
            {
              int min1= (sum - A[0] + (A[0] * (i + 1)) - (A[i] * (i + 1)) + A[i]);
             int min2=(sum - (A[A.Length - 1] * A.Length) + (A[A.Length - 1] * (i + 1)) - (A[i] * (i + 1)) + (A[i] * A.Length));
             Console.WriteLine(min1);
             Console.WriteLine(min2);
            min=Math.Min(min, Math.Min(min1, min2));
                
            }
            Console.WriteLine(min);
           

        }
        
    }
}
