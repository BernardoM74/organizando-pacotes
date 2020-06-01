using System;
using System.Collections.Generic;
using System.Text;
using GraphMaker;

namespace PraticalList
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Graph graph = new Graph(false);
            graph.createVertex("a");
            graph.createVertex("b");
            graph.createVertex("c");
            graph.createVertex("d");
            graph.createVertex("e");
            graph.createVertex("f");

            graph.addEdge("a", "b", 2);
            graph.addEdge("a", "d", 5);
            graph.addEdge("a", "f", 6);

            MinimumSpanningTree mst = new MinimumSpanningTree(graph, "a");
            mst.Prim();

        }

    }
}
