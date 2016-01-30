using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon
{
    class Program
    {
        static void Main(string[] args)
        {
            //rotateArray2();
            Duplicate2();
        }

        static void Duplicate2()
        {
            int numberOfLines = 4;// Convert.ToInt32(Console.ReadLine());
            Queue<Int32> queueSet = new Queue<int>();
            int[][] array = new int[numberOfLines][];
             //for (int i = 0; i < numberOfLines; i++)
            //{
            //    array[i] = Console.ReadLine().ToString().Split(' ').Select(n => Convert.ToInt32(n)).ToArray();
           // }
            array[0] = new int[] { 1, 2, 3,4 };
            array[1] = new int[] { 5,6,7,8 };
            array[2] = new int[] { 9,10,11,12 };
             array[3] = new int[] { 13,14,15,1 };
            bool bflag=false;
            int kDistance = 15;//Convert.ToInt32(Console.ReadLine());//2;
            

             for (int i = 0; i < array.Length; i++)
             {
                 for (int j = 0; j < array[i].Length; j++)
                 {

                     if (queueSet.Contains(array[i][j]))
                     {
                             bflag = true;
                             break;
                     }

                     if (queueSet.Count < kDistance)
                     {
                        
                         queueSet.Enqueue(array[i][j]);
                     }
                     else
                     {
                         
                        
                         queueSet.Dequeue();
                         queueSet.Enqueue(array[i][j]);
                     }
                 }
                 if(bflag) {
                     break;
                 }
             }
            if(bflag){
                Console.Write("YES");
            }
            else
            {
                Console.Write("NO");
            }
        }
        static void rotateArray2()
        {
           /* int[,] array = new int[,] {
                               {1,2,3},
                               {4,5,6},
                               {7,8,9}
                           };*/
           /* int[,] array = new int[,] {
                               {1,2,3,4},
                               {5,6,7,8},
                               {9,10,11,12},
                               {13,14,15,16},

                           };*/
            int numberOfLines = Convert.ToInt32(Console.ReadLine());
            int[][] array=new int[numberOfLines][];
            for (int i = 0; i < numberOfLines; i++)
            {
                array[i] = Console.ReadLine().ToString().Split(' ').Select(n => Convert.ToInt32(n)).ToArray();
            }
            int col = 0;
            int row = 0;
            int topBound = 0;
            int bottomBound = array.Length - 1;

            int leftBound = 0;
            int rightBound = array[0].Length - 1;

            if (bottomBound != rightBound)
            {
                Console.WriteLine("");
            }

            int temp1;
            while (leftBound <= rightBound && topBound <= bottomBound)
            {
                int temp = array[row][col];
                while (col < rightBound) {
                    temp1 = array[row][++col];
                    array[row][col]=temp;
                    temp = temp1;
                }
               // topBound++;
                while (row < bottomBound) 
                {
                    temp1 = array[++row][col];
                    array[row][col] = temp;
                    temp = temp1;
                   //Console.WriteLine (array[++row,col]);
                }
                rightBound--;
                while (col > leftBound) {
                    temp1 = array[row][--col];
                    array[row][col] = temp;
                    temp = temp1;
                    //Console.WriteLine(array[row, --col]);
                }
                bottomBound--;
                while (row > topBound) {
                    temp1 = array[--row][col];
                    array[row][col] = temp;
                    temp = temp1;
                    //Console.WriteLine(array[--row, col]);
                }
                ++row;
                ++col;
                topBound++;
                leftBound++;
            }

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    Console.Write(array[i][j] + " ");
                }
                Console.Write(Environment.NewLine);
            }

        }
    }
}
