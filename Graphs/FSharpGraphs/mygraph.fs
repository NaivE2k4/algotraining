module mygraph

type TreeNode = 
    | Leaf
    | Node of int *  TreeNode *  TreeNode

//type Vertex = Id of int
type WeightedVertex = {Id: int; mutable Weight: int}
//type GraphEdge = {VertexA: Vertex; VertexB: Vertex}
type WeightedEdge = {VertexA: WeightedVertex; VertexB: WeightedVertex; Weight: int}
    
type WeightedGraph = {Edges: WeightedEdge list}
type DykstraGraph = {Graph: WeightedGraph; Vertexes: WeightedVertex list}
type VertexNeighbor = {Neighbor: WeightedVertex; EdgeWeight: int}
type VertexNeighbors = VertexNeighbor list
    
let getNeighbors graph vertex =
    List.filter (fun (edge:WeightedEdge) -> edge.VertexA.Id = vertex.Id) graph.Edges
    |> List.map (fun edge -> {Neighbor=edge.VertexB; EdgeWeight=edge.Weight})

    
//let Dykstra graph startid endid =
    
//let rec markNeighborRec vertex vertexNeighbors markedNeighbors= 
//    match vertexNeighbors with
//    | head :: tail -> 
//        if head.Neighbor.Weight > 
//    | [] -> ()
//let markNeighbors vertex neighbors markedneighbors = 

open System.Collections
//let Dykstra graph startid endid =
//    let a = Queue()

//Непонятно даже с какой стороны подойти к алгоритму в функциональном стиле
//SO говорит что BFS на F# не лучшая идея