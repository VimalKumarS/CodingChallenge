using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    class Program
    {
        static void Main(string[] args)
        {
            // maximumsizeSubmatrix();
            // largestRectangleSize();
            // string[] str1= str();

            Console.Write(new Interface1.callme().get());

            VMWAre vmobj = new VMWAre();
            int[] A={5,1,4,3};
            int[] b = { 2,3,5,1,4};
            //vmobj.permute(ref A,1,4);
            vmobj.vmQuestion(b);
            String strInput="the cat can catch the mouse";
            TrieNode root = new TrieNode(null, '?');

            string[] chunks = strInput.Split(null);
            foreach (string chunk in chunks)
            {
                root.AddWord(chunk.Trim());
            }
            Dictionary<string, int> lststring = new Dictionary<string,int>();
            root.GetAllWordCount(root,ref lststring, string.Empty);

            // Use OrderBy method.
            foreach (var item in lststring.OrderBy(l => l.Value))
            {
                Console.WriteLine(item);
            }


            var items = from pair in lststring
                        orderby pair.Value descending
                        select pair;

            dicegame(new string[]{
                    "4","137","364","115","724"
            });
            // NumberOfPairs(new int[]{6,6,3,9,3,5,1},12);
            /* an array with 5 rows and 2 columns*/
            int[,] a = new int[5, 2] { { 0, 0 }, { 1, 2 }, { 2, 4 }, { 3, 6 }, { 4, 8 } };
            int i, j;

            /* output each array element's value */
            for (i = 0; i < 5; i++)
            {
                for (j = 0; j < 2; j++)
                {
                    Console.WriteLine("a[{0},{1}] = {2}", i, j, a[i, j]);
                }
            }
            Console.ReadKey();
        }


        static void countword()
        {
            string input = "that I have not that place sunrise beach like not good dirty beach trash beach";
            var wrodList = input.Split(null);
            var output = wrodList.GroupBy(x => x).Select(x => new Word { charchter = x.Key, repeat = x.Count() }).OrderBy(x => x.repeat);
            foreach (var item in output)
            {
               // textBoxfile.Text += item.charchter + " : " + item.repeat + Environment.NewLine;
            }
        }

        static int
            dicegame(string[] result)
        {
            int testSpin = Convert.ToInt32(result[0]);
            int count = 0;
            for (int i = 1; i < result.Length; i++)
            {

                HashSet<int> set = new HashSet<int>();
                int num = Convert.ToInt32(result[i]);
                while (num != 0)
                {
                    int j = num % 10;
                    num = num / 10;
                    set.Add(j);
                }
                count += set.Count;

            }
            return count;
        }
        static void repeatedString()
        {
            string s = "He   had had quite";
            s = s.Replace(" ", "#");
            s = s.Replace(":", "#");
            s = s.Replace(";", "#");
            s = s.Replace(",", "#");
            s = s.Replace(".", "#");
            s = s.Replace("-", "#");
            string[] strsplit = s.Split('#');
            HashSet<string> strHashSet = new HashSet<string>();
            string result = string.Empty;
            foreach (string split in strsplit)
            {
                if (strHashSet.Contains(split) && split != string.Empty)
                {
                    result = split;
                    break;
                }
                else
                {
                    strHashSet.Add(split);
                }

            }
        }
        static void merge2Aray()
        {
            int[] a = new int[] { 2, 4, 5, 9, 9 };
            int[] b = new int[] { 0, 1, 2, 4 };

            List<int> lst = new List<int>();
            int alen = a.Length;
            int blen = b.Length;
            int i = 0;
            int j = 0;
            while (i < alen && j < blen)
            {
                if (a[i] < b[j])
                {
                    lst.Add(a[i]);
                    i++;
                }
                else if (a[i] > b[j])
                {
                    lst.Add(b[j]);
                    j++;
                }
                else if (a[i] == b[j])
                {
                    lst.Add(b[j]);
                    lst.Add(a[i]);
                    j++;
                    i++;
                }

            }

            while (i < alen)
            {
                lst.Add(a[i]);
                i++;
            }

            while (j < blen)
            {
                lst.Add(b[i]);
                j++;
            }
            int[] c = lst.ToArray();

        }
        public static void maximumsizeSubmatrix()
        {
            int[][] a = new int[6][];
            a[0] = new int[5] { 0, 1, 1, 0, 1 };
            a[1] = new int[5] { 1, 1, 0, 1, 0 };
            a[2] = new int[5] { 0, 1, 1, 1, 0 };
            a[3] = new int[5] { 1, 1, 1, 1, 0 };
            a[4] = new int[5] { 1, 1, 1, 1, 1 };
            a[5] = new int[5] { 0, 0, 0, 0, 0 };

            int[][] s = new int[6][];
            s[0] = a[0];

            for (int i = 1; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a[i].GetLength(0); j++)
                {
                    if (j == 0)
                    {
                        s[i] = new int[5];
                        s[i][j] = a[i][j];
                    }
                    else if (a[i][j] == 1)
                    {
                        s[i][j] = Math.Min(Math.Min(s[i][j - 1], s[i - 1][j]), s[i - 1][j - 1]) + 1;

                    }
                    else
                    {
                        s[i][j] = 0;
                    }
                }
            }

        }

        public static void largestRectangleSize()
        {
            Stack<int> height = new Stack<int>();
            Stack<int> index = new Stack<int>();

            int[] a = new int[] { 6, 2, 5, 4, 5, 1, 6 };
            int largestSize = -1;
            for (int i = 0; i < a.Length; i++)
            {
                if (height.Count == 0 || a[i] > height.Peek())
                {
                    height.Push(a[i]);
                    index.Push(i);
                }
                else if (a[i] < height.Peek())
                {
                    int lastindex = 0;
                    while (height.Count != 0 && a[i] < height.Peek())
                    {
                        lastindex = index.Pop();
                        int temp = height.Pop() * (i - lastindex);
                        if (largestSize < temp)
                        {
                            largestSize = temp;
                        }
                    }
                    height.Push(a[i]);
                    index.Push(lastindex);
                }
            }

            while (height.Count != 0)
            {
                int temp = height.Pop() * (a.Length - index.Pop());
                if (largestSize < temp)
                {
                    largestSize = temp;
                }
            }

        }


        public static string[] str()
        {
            List<string> lstoutput = new List<string>();
            String[] str ={
                              "{",
                              "",
                          };

            char[] startbraces = { '{', '[', '(' };
            char[] closebraces = { '}', ']', ')' };
            string[] pair = {
                               "{}","[]","()"
                           };
            foreach (String s in str)
            {
                if (!String.IsNullOrEmpty(s))
                {
                    char[] ch = s.ToCharArray();
                    Stack<char> stBraces = new Stack<char>();

                    stBraces.Push(ch[0]);

                    for (int i = 1; i < ch.Length; i++)
                    {
                        if (startbraces.Contains(ch[i]))
                        {
                            stBraces.Push(ch[i]);
                        }
                        else if (closebraces.Contains(ch[i]))
                        {
                            if (stBraces.Count > 0)
                            {
                                char topchar = stBraces.Peek();
                                string strpair = (topchar).ToString() + (ch[i]).ToString();
                                if (pair.Contains(strpair))
                                {
                                    stBraces.Pop();

                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }

                    if (stBraces.Count == 0)
                    {
                        lstoutput.Add("YES");
                        Console.WriteLine();
                    }
                    else
                    {
                        lstoutput.Add("NO");
                    }
                }

            }
            return lstoutput.ToArray();
        }

        static int NumberOfPairs(int[] a, long k)
        {
            Array.Sort(a);
            a = a.Distinct().ToArray();
            Dictionary<Tuple<int, int>, int> pairs = new Dictionary<Tuple<int, int>, int>();

            int start = 0;
            int last = a.Length - 1;
            int sum;
            /* while(start<last)
             {
                 sum = a[start] + a[last];
                 if (k == sum)
                 {

                 }
             }*/

            for (int i = 0; i < a.Length; i++)
            {
                for (int j = i + 1; j < a.Length; j++)
                {
                    Tuple<int, int> t = new Tuple<int, int>(a[i], a[j]);
                    if (!pairs.ContainsKey(t))
                    {
                        pairs.Add(t, a[i] + a[j]);
                    }
                }
            }

            int x1 = pairs.Where(x => x.Value == k).Count();


            return 0;
        }
    }
  
}
