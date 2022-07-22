using System;
using System.Collections.Generic;

namespace FiniteAutoma
{
    class Program
    {

        class node
        {
            public string name;
            public node pre;
            public node after;
        }

        static string masir(string[] state, string[] alphabet, string[,] rules, string start, string t, int n, ref int j, List<string> a)
        {
            bool p = false;
            int i;
            for ( i = 0; i < n; i++)
            {
                if (rules[i, 0] != rules[i, 2])
                {
                    if (rules[i, 0] == start && (rules[i, 1] == t || rules[i, 1] == "$") && rules[i, 3] != "1")
                    {
                        rules[i, 3] = "1";
                        start = rules[i, 2];
                        a.Add(start);
                        if (rules[i, 1] == "$")
                        {
                            j = j - 1;
                        }
                        p = true;
                        return start;
                    }
                }
                else
                {
                    if (rules[i, 0] == start && (rules[i, 1] == t || rules[i, 1] == "$") )
                    {
                        rules[i, 3] = "1";
                        start = rules[i, 2];
                        a.Add(start);
                        if (rules[i, 1] == "$")
                        {
                            j = j - 1;
                        }
                        p = true;
                        return start;
                    }
                }

            }
            if (p == false)
            {
                if (a.Count >= 3)
                {
                    start = a[a.Count - 2];
                    for (int y = 0; y < n; y++)
                    {
                        if (rules[y, 3] == "1")
                        {
                            if (rules[y, 0] == a[a.Count - 1])
                            {
                                rules[y, 3] = "0";
                            }
                        }
                    }
                    a.RemoveAt(a.Count - 1);
                    j = a.Count - 2;
                    return start;
                }
            }

            return "false";

        }

        static void Main(string[] args)
        {
            string s1 = Console.ReadLine();
            s1 = s1.Substring(1, s1.Length - 2);
            string[] state = s1.Split(',');
            int[] visited = new int[state.Length];

            string s2 = Console.ReadLine();
            s2 = s2.Substring(1, s2.Length - 2);
            string[] alphabet = s2.Split(',');

            string s3 = Console.ReadLine();
            s3 = s3.Substring(1, s3.Length - 2);
            string[] finalstate = s3.Split(',');

            int n = int.Parse(Console.ReadLine());
            string[,] rules = new string[n, 5];
            for (int i = 0; i < n; i++)
            {
                string[] s4 = Console.ReadLine().Split(',');
                rules[i, 0] = s4[0];
                rules[i, 1] = s4[1];
                rules[i, 2] = s4[2];
            }

            string mystring = Console.ReadLine();

            string start = state[0];
            List<string> a = new List<string>();
            a.Add(start);
            for (int i = 0; i < mystring.Length; i++)
            {
                start = masir(state, alphabet, rules, start, mystring[i].ToString(), n, ref i,a);        
            }

            bool r = false;

            for (int i = 0; i < finalstate.Length; i++)
            {
                if (finalstate[i] == start)
                {
                    Console.WriteLine("Accepted");
                    r = true;
                    break;
                }
            }

            if (r == false)
            {
                Console.WriteLine("Rejected");
            }


        }
    }
}
