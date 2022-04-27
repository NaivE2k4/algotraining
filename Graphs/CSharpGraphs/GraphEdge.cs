namespace CSharpGraphs
{
    public class GraphEdge
    {
        public int V1 { get; }
        public int V2 { get; }
        public int Weight;
        public GraphEdge(int v1, int v2, int weight = 0)
        {
            V1 = v1;
            V2 = v2;
            Weight = weight;
        }
    }
}
