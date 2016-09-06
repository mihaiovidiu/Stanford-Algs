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
                int randomVertice1 = r.Next(1, nbOfVertices + 1);
                int randomVertice2 = graphAdjList[randomVertice1][r.Next(0, graphAdjList[randomVertice1].Count)]];
            }

            return 0;
        }

    }
}
