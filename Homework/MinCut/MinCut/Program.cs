using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinCut
{
    class Program
    {
        static Random r = new Random();
        static Stopwatch sWatch = new Stopwatch();
        static void Main(string[] args)
        {
            List<List<int>> adjList = ReadGraph("kargerMinCut.txt");
            // Run the min cut algorithm for n^2 * log n times and remember the smallest vallue.
            int n = adjList.Count;
            int N = n * n * Convert.ToInt32(Math.Log(n, 2));
            int minCut = int.MaxValue;
            Console.WriteLine($"Graph with {n} verticles\nWe should make {N} runs of Karger's cut algorithm");
            Console.WriteLine("Press enter to start. Then press q to stop if you want to stop");
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.Enter)
            {
                int i = 0;
                sWatch.Start();
                for (i = 0; i < N; i++)
                {
                    int newMinCut = MinCut(adjList);
                    if (newMinCut < minCut)
                        minCut = newMinCut;
                    if (i % 100 == 0)
                    {
                        Console.WriteLine($"{i + 1} runs completed. Min cut is {minCut}");
                        if (Console.KeyAvailable)
                        {
                            if (Console.ReadKey(true).Key == ConsoleKey.Q)
                                break;
                        }
                    }

                }
                sWatch.Stop();

                Console.WriteLine($"Graph with {n} vertices\nMinCut value is {minCut}\nWe made {i + 1} runs of Karger's cut algorithm from the recomended {N}\nExecution took {sWatch.ElapsedMilliseconds / 1000} s");

                Console.ReadLine();
            }
            
        }

        static List<List<int>> ReadGraph(string fileName)
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                List<List<int>> listToReturn = new List<List<int>>();
                string line = null;
                while ((line = sr.ReadLine()) != null)
                {
                    listToReturn.Add(ListFromString(line));
                }
                return listToReturn;
            }
        }

        private static List<int> ListFromString(string line)
        {
            List<int> listToReturn = new List<int>();
            int num = -1;
            foreach (string s in line.Split('\t'))
            {
                if (int.TryParse(s, out num))
                {
                    listToReturn.Add(num);
                }
                
            }
            return listToReturn;
        }


        static int MinCut(List<List<int>> graphAdjList)
        {
            List<int> li;
            List<List<int>> adjList = new List<List<int>>(graphAdjList.Count);
            foreach(List<int> list in graphAdjList)
            {
                li = new List<int>(list);
                adjList.Add(li);
            }

            while (adjList.Count > 2)
            {
                // Chose a random edge and fuse the vertices
                int randPivot = r.Next(0, adjList.Count);
                int pivotVertice = adjList[randPivot][0];
                int randVertice = r.Next(1, adjList[randPivot].Count);
                int randomVertice = adjList[randPivot][randVertice];
                // Fuse the vertices
                Fuse(adjList, pivotVertice, randomVertice, randPivot);
            }
            // Only two point remain, calculate the cut
            return adjList[0].Count - 1;
        }

        static void Fuse(List<List<int>> graphAdjList, int pivot, int vertex, int rPivot)
        {
            // find the vertex adj list
            List<int> vList = graphAdjList.FirstOrDefault(list => list[0] == vertex);

            // find the pivot adj list
            List<int> pList = graphAdjList[rPivot];

            // dump all the vertices that vertex is connected to onto pivot, and remove self loops
            for (int i = 1; i < vList.Count; i++)
            {
                if (vList[i] != pivot) // else is self loop
                    pList.Add(vList[i]);
            }

            // remove vertex list
            graphAdjList.Remove(vList);

            foreach (List<int> adjList in graphAdjList)
            {
                if (adjList.Contains(vertex))
                {
                    if (adjList[0] == pivot)
                    {
                        adjList.RemoveAll((delegate (int v) { return v == vertex; }));
                    }
                    else
                    {
                        for (int i = 1; i < adjList.Count; i++)
                        {
                            if (adjList[i] == vertex)
                                adjList[i] = pivot;
                        }
                    }
                }
            }

        }

    }
}
