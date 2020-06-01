using System;
using System.Collections.Generic;
using System.Text;
using GraphMaker;

namespace PraticalList
{

    class MinimumSpanningTree
    {
        List<Edge> spanningTreeEdges;
        List<Vertex> spanningTreeVertex;

        List<Vertex> allVertex;
        List<Edge> allEdges;
        
        Vertex rootVertex;

        public MinimumSpanningTree(Graph G, string rootVertexVertexId)
        {
            spanningTreeEdges = new List<Edge>();
            spanningTreeVertex = new List<Vertex>();
            allVertex = G.vertexes;
            allEdges = G.edges;
            this.rootVertex = allVertex.Find(vertex => vertex.Id.Equals(rootVertexVertexId));
        }


        private Edge findLightestEdge(Vertex v) {
            Edge lightestEdge = null;
            int minorWeight = int.MaxValue;

            v.adjacents.ForEach(delegate (Vertex adjacent) {
                lightestEdge = allEdges.Find(edge => edge.v2 == adjacent && !spanningTreeEdges.Contains(edge));
                if(lightestEdge != null) {
                    if(lightestEdge.weight < minorWeight) {
                        minorWeight = lightestEdge.weight;
                    }
                }
            });

            return allEdges.Find(edge => edge.weight == minorWeight);
        }


        // 1) lightestEdge = findLightestEdge(root)
        // check if spanningTreeEdges.contains(lightestEdge) [ in findLightestEdge ]
        // 2) lightestEdge = findLightestEdge(root), nextLightestEdge = findLightestEdge(lightestEdge.v2)

        public void Prim() {
            spanningTreeVertex.Add(rootVertex);
            Edge lightestEdge = null;

            

            spanningTreeVertex.ForEach(delegate (Vertex v) {
                lightestEdge = findLightestEdge(v);
                if(lightestEdge != null) {
                    spanningTreeVertex.Add(lightestEdge.v2);
                    spanningTreeEdges.Add(lightestEdge);
                }
            });


            if(lightestEdge != null) {
                printEdge(lightestEdge);
            }

            spanningTreeEdges.Add(lightestEdge);
            //Console.WriteLine("Prim weights sum => ", getSum());
        }

        private void printEdge(Edge edge) {
            Console.WriteLine("Edge = (" + edge.v1.Id + ", " + edge.v2.Id + ")" +
                              "\nWeight = " + edge.weight);
        }

        public void Kruskal() {
            spanningTreeVertex.Add(rootVertex);
            Edge lightestEdge;

            while (spanningTreeEdges.Count < allVertex.Count - 1) {
            }
        }

        private int getSum()
        {
            int sum = 0;
            spanningTreeEdges.ForEach(delegate (Edge e){
                sum += e.weight;
            });

            return sum;
        }

    }
}
