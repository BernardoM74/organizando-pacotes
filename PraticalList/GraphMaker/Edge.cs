namespace GraphMaker
{
    class Edge
    {
        public string Id { get; set; }
        public Vertex v1, v2;
        public int weight;
        public string Color { get; set; }

        public Edge()
        {
            this.v1 = new Vertex();
            this.v2 = new Vertex();
            this.weight = 0;
            this.Color = "BRANCO";
        }

        public Edge(int weight, Vertex origin, Vertex destiny, string idNewEdge, string color)
        {
            this.v1 = origin;
            this.v2 = destiny;
            this.weight = weight;
            this.Id = idNewEdge;
            this.Color = color;
        }
    }
}
