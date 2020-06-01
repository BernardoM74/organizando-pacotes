using System.Collections.Generic;
using System.Drawing;

namespace GraphMaker
{
    class Vertex
    {
        public string Id { get; set; }
        public List<Vertex> adjacents;
        public string color;

        public int Key { get; set; }
        public Vertex Parent { get; set; }

        public Vertex()
        {
            adjacents = new List<Vertex>();
        }

        public Vertex(string id)
        {
            this.adjacents = new List<Vertex>();
            Id = id;
            this.color = "white";
        }

        public void addAdjacent(Vertex adjacent)
        {
            this.adjacents.Add(adjacent);
        }

    }
}
