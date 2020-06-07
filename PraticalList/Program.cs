using System;
using System.Collections.Generic;
using System.Text;
using GraphMaker;
using System.IO;

namespace PraticalList
{
    public class Program
    {
        static Graph graph;
        public static void Main(string[] args)
        {
            bool isGraphDirected = false;
            graph = new Graph(isGraphDirected);

            string fileName = "dados_ti.txt";
            createVertexFromFile(fileName);

            GraphColoring gc = new GraphColoring("edge", graph);
            gc.start();
        }

        public static void createVertexFromFile (string fileName)
        {
            string[] fileData = File.ReadAllLines(fileName);
            foreach( string line in fileData){
                string[] tmp = line.Split(" ");
                string discipline = tmp[0];
                string teacherName = tmp[1];
                string period = tmp[2];
                graph.createVertex(teacherName);
                graph.createVertex(period);
                graph.addEdge(teacherName, period, 0, discipline);
            } 
        }

    }
}
