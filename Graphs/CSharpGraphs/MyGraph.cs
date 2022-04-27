using System.Collections.Generic;
using System.Linq;

namespace CSharpGraphs
{
    public class MyGraph
    {
        public List<GraphEdge> Edges = new();
        public List<GraphNode> Nodes = new();
        public Dictionary<GraphEdge, List<GraphNode>> EdgesToNodes = new();

        public MyGraph()
        { 
        
        }

        public MyGraph(List<GraphEdge> edges)
        {
            foreach(var edge in edges)
            {
                if(Nodes.All(n => n.Id != edge.V1))
                    Nodes.Add(new GraphNode(edge.V1));
                if(Nodes.All(n => n.Id != edge.V2))
                    Nodes.Add(new GraphNode(edge.V2));

                Edges.Add(edge);

            }
        }

    }
}
