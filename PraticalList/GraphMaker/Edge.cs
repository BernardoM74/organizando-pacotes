namespace GraphMaker
{
    class Edge
    {
        public string Id { get; set; }
        public Vertex v1, v2;
        public int weight;

        public Edge()
        {
            this.v1 = new Vertex();
            this.v1 = new Vertex();
            this.weight = 0;
        }

        public Edge(int weight, Vertex origin, Vertex destiny)
        {
            this.v1 = origin;
            this.v2 = destiny;
            this.weight = weight;
        }
    }
}
