using GraphMaker;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Text;

namespace PraticalList
{
    class GraphColoring
    {
        string[] availableColors = { "VERMELHO", "AZUL", "ROXO", "AMARELO", "VERDE", "ROSA", "LARANJA", "PRETO", "MARROM", "CINZA" };
        string coloringType;
        Graph graph;
        public int ChromaticNumber { get; set; }
        public GraphColoring(string coloringType, Graph graph)
        {
            this.coloringType = coloringType;
            this.graph = graph;
        }

        public void start()
        {
            if (coloringType == "vertex")
            {
                sequencial();
                return;
            }

            foreach( Edge e in graph.edges)
            {
                Console.WriteLine("( "+e.v1.Id+ ", "+e.v2.Id + ")\n Materia = "+e.Id);
                edgeColoring(e.v1, e.v2, e);
            }

        }

        private void sequencial()
        {
            int i = 0;
            graph.vertexes.ForEach(delegate (Vertex v)
            {
                if (v.Color == "white")
                {
                    if ((v.adjacents.Find(adjacent => adjacent.Color == availableColors[i])) == null)
                    {
                        v.Color = availableColors[i];
                    }
                    else
                    {
                        i++;
                        v.Color = availableColors[i];
                    }
                }
            });
            ChromaticNumber = i + 1;
        }
        // confere no vertice destino e no vertice de origem as cores que estão la
        public void edgeColoring(Vertex professor, Vertex period, Edge discipline)
        {
            foreach (string color in availableColors)
            {
                bool canIColor = true;
                professor.edges.ForEach(delegate (Edge discipline)
                {
                    if (discipline.Color == color)
                    {
                        canIColor = false;
                        return;
                    }
                });
                period.edges.ForEach(delegate (Edge discipline)
                {
                    if (discipline.Color == color)
                    {
                        canIColor = false;
                        return;
                    }
                });

                if (canIColor)
                {
                    Edge toReceiveColor = professor.edges.Find(edge => edge.v1.Id == professor.Id
                    && edge.v2.Id == period.Id && edge.Id == discipline.Id);

                    toReceiveColor.Color = color;
                    return;
                }
            }
        }

        public void print()
        {
            graph.vertexes.ForEach(delegate (Vertex v)
            {
                Console.Write("Vertex = " + v.Id + "\t");
                Console.WriteLine("Color = " + v.Color);
            });
            Console.WriteLine("\n");
        }

    }
}
