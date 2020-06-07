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
            if (vertexes.Find(vertex => vertex.Id == id) == null)
            {
                vertexes.Add(new Vertex(id));
            }
        }

        public void addEdge(string originId, string destinyId, int weight, string idNewEdge)
        {
            try
            {
                Vertex v1 = vertexes.Find(vertex => vertex.Id.Equals(originId));
                Vertex v2 = vertexes.Find(vertex => vertex.Id.Equals(destinyId));

                if (directed)
                {
                    addDirectedEdge(weight, v1, v2, idNewEdge);
                    return;
                }
                addUndirectedEdge(weight, v1, v2, idNewEdge);
            }
            catch (KeyNotFoundException notFound)
            {
                throw new KeyNotFoundException(notFound.Message);
            }
        }

        private void addUndirectedEdge(int weight, Vertex origin, Vertex destiny, string idNewEdge)
        {
            Edge edge = new Edge(weight, origin, destiny, idNewEdge, "BRANCO");

            edge.v1.addAdjacent(edge.v2, edge);
            edge.v2.addAdjacent(edge.v1, edge);

            vertexes[vertexes.IndexOf(origin)] = edge.v1;
            vertexes[vertexes.IndexOf(destiny)] = edge.v2;
            edges.Add(edge);
        }

        private void addDirectedEdge(int weight, Vertex origin, Vertex destiny, string idNewEdge)
        {
            Edge edge = new Edge(weight, origin, destiny, idNewEdge, "BRANCO");

            edge.v1.addAdjacent(edge.v2, edge);

            vertexes[vertexes.IndexOf(origin)] = edge.v1;
            edges.Add(edge);
        }

        public void printColors()
        {
            vertexes.ForEach(delegate (Vertex v)
            {
                if (v.Id.Length != 1)
                {
                    Console.WriteLine("\n"+ v.Id + ": ");
                    v.adjacents.ForEach(delegate (Vertex adj)
                    {
                        Console.WriteLine("PERIODO: " + adj.Id);
                        if (adj.edges.Find(edge => edge.v1.Id == v.Id && edge.v2.Id == adj.Id ||
                                        edge.v2.Id == v.Id && edge.v1.Id == adj.Id) != null)
                        {
                            Console.Write("DISCIPLINA: " + adj.edges.Find(edge => edge.v1.Id == v.Id && edge.v2.Id == adj.Id ||
                                     edge.v2.Id == v.Id && edge.v1.Id == adj.Id).Id);

                            Console.WriteLine(" - COR " + adj.edges.Find(edge => edge.v1.Id == v.Id && edge.v2.Id == adj.Id ||
                                     edge.v2.Id == v.Id && edge.v1.Id == adj.Id).Color + "\n");
                        }
                    });
                }
            });
        }

        public void print()
        {
            vertexes.ForEach(delegate (Vertex v)
            {
                Console.WriteLine("Vertex = " + v.Id);
                Console.Write("\t\tAdjacents = ");
                if (v.adjacents.Count == 0)
                {
                    Console.WriteLine("Vertex " + v.Id + " doesn't have any adjacents.");
                }
                else
                {
                    v.adjacents.ForEach(delegate (Vertex adjacent)
                    {
                        Console.Write(adjacent.Id + " ");
                    });
                    Console.WriteLine("");
                }
                Console.WriteLine("\t\tColor = " + v.Color);

            });
            Console.WriteLine("");
        }

        public void printWithContext()
        {
            vertexes.ForEach(delegate (Vertex v)
            {
                if (v.Id.Length == 1)
                {
                    Console.Write(v.Id + "º periodo tem aula com: ");
                    v.adjacents.ForEach(delegate (Vertex v)
                    {
                        Console.Write(v.Id + ", ");
                    });
                }
                else
                {
                    Console.Write(v.Id + " da aula para o(s) periodos: ");
                    v.adjacents.ForEach(delegate (Vertex v)
                    {
                        Console.Write(v.Id + "º, ");
                    });
                }
                Console.WriteLine();
            });
            Console.WriteLine("\n");
        }
    }
}
