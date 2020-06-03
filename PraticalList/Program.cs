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
            Graph graph = new Graph(true);
            graph.createVertex("a");
            graph.createVertex("b");
            graph.createVertex("c");

            graph.addEdge("a", "b", 2);
            graph.addEdge("a", "c", 5);

            graph.print();

            //MinimumSpanningTree mst = new MinimumSpanningTree(graph, "a");
            //mst.Prim();

        }

    }
}
