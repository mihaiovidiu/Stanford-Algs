using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinCut
{
    class Program
    {
        static void Main(string[] args)
        {
            List<List<int>> adjList = ReadGraph("kargerMinCut.txt");
            Fuse(adjList, 2, 3);
            
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
            Random r = new Random();
            int nbOfVertices = graphAdjList.Count;
            while (nbOfVertices > 2)
            {
                // Chose a random edge and fuse the vertices
                int rand = r.Next(0, nbOfVertices);
                int pivotVertice = graphAdjList[rand][0];
                int randomVertice = graphAdjList[rand][r.Next(1, graphAdjList[rand].Count)]; 
            }

            return 0;
        }

        static void Fuse(List<List<int>> graphAdjList, int pivot, int vertex)
        {
            // find the vertex adj list
            List<int> vList = graphAdjList.FirstOrDefault(list => list[0] == vertex);

            // find the pivot adj list
            List<int> pList = graphAdjList.FirstOrDefault(list => list[0] == pivot);

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
                    adjList.Remove(vertex);
            }

        }

    }
}
