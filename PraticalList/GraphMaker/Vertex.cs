using System.Collections.Generic;
using System.Drawing;

namespace GraphMaker
{
    class Vertex
    {
        public string Id { get; set; }
        public List<Vertex> adjacents;

        public string Color { get; set; }
        public int Key { get; set; }
        public List<Edge> edges;

        public Vertex()
        {
            adjacents = new List<Vertex>();
            edges = new List<Edge>();
        }

        public Vertex(string id)
        {
            this.adjacents = new List<Vertex>();
            this.edges = new List<Edge>();
            Id = id;
            this.Color = "white";
        }

        public void addAdjacent(Vertex adjacent, Edge connection)
        {
            this.adjacents.Add(adjacent);
            this.edges.Add(connection);
        }

    }
}
