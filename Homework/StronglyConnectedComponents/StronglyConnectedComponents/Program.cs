using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StronglyConnectedComponents
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sWatch = new Stopwatch();
            sWatch.Start();
            Dictionary<int, List<int>> headToTailsDict = ReadGraph("SCC.txt");
            sWatch.Stop();
            Console.WriteLine($"Finished. Execution took {sWatch.ElapsedMilliseconds} ms.");
            Console.ReadLine();
        }

        static Dictionary<int, List<int>> ReadGraph(string inputFileName)
        {

            using (StreamReader sr = new StreamReader(inputFileName))
            {
                string line = null; // line: vertice1 vertice2
                List<int> tails = null;
                Dictionary<int, List<int>> headToTailsDictionary = new Dictionary<int, List<int>>();
                int head, tail;
                string[] headAndTail = new string[2];
                while ((line = sr.ReadLine()) != null)
                {
                    headAndTail = line.Split(' ');
                    head = Int32.Parse(headAndTail[0]);
                    tail = Int32.Parse(headAndTail[1]);
                    if (!headToTailsDictionary.ContainsKey(head))
                    {
                        tails = new List<int>();
                        headToTailsDictionary.Add(head, tails);
                    }
                    tails.Add(tail);
                }

                return headToTailsDictionary;
            }


        }
    }
}
