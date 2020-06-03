using System;
using System.Collections.Generic;

namespace GraphMaker
{
    class Graph
    {
        public List<Vertex> vertexes;
        public List<Edge> edges;
        public bool directed;

        public Graph(bool directed)
        {
            this.directed = directed;
            vertexes = new List<Vertex>();
            edges = new List<Edge>();
        }

        public void createVertex(string id)
        {
            vertexes.Add(new Vertex(id));
        }

        public void addEdge(string originId, string destinyId, int weight)
        {
            try
            {
                Vertex v1 = vertexes.Find(vertex => vertex.Id.Equals(originId));
                Vertex v2 = vertexes.Find(vertex => vertex.Id.Equals(destinyId));

                if (directed)
                {
                    addDirectedEdge(weight, v1, v2);
                    return;
                }
                addUndirectedEdge(weight, v1, v2);
            }
            catch (KeyNotFoundException notFound)
            {
                throw new KeyNotFoundException(notFound.Message);
            }
        }

        private void addUndirectedEdge(int weight, Vertex origin, Vertex destiny)
        {
            Edge edge = new Edge(weight, origin, destiny);

            edge.v1.addAdjacent(edge.v2);
            edge.v2.addAdjacent(edge.v1);

            vertexes[vertexes.IndexOf(origin)] = edge.v1;
            vertexes[vertexes.IndexOf(destiny)] = edge.v2;
            edges.Add(edge);
        }

        private void addDirectedEdge(int weight, Vertex origin, Vertex destiny)
        {
            Edge edge = new Edge(weight, origin, destiny);

            edge.v1.addAdjacent(edge.v2);

            vertexes[vertexes.IndexOf(origin)] = edge.v1;
            edges.Add(edge);
        }

        public void print()
        {
            vertexes.ForEach(delegate (Vertex v)
            {
                Console.WriteLine("Vertex = " + v.Id);
                Console.Write("Adjacents = ");
                v.adjacents.ForEach(delegate (Vertex adjacent)
                {
                    if (adjacent != null)
                    {
                        Console.Write(adjacent.Id + " ");
                    }
                    else
                    {
                        Console.Write("Vertex " + v.Id + " doesn't have adjacent.");
                    }
                });
                Console.WriteLine("\n");
            });
        }
    }
}
