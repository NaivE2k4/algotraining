#копия из лекции Хирьянова
from Dykstra import dijkstra
from Dykstra import reveal_shortest_path
from FloydWarshall import FW
from BellmanFord import BF
def main():
    G = read_graph()
    start = int(input("С какой вершины начать?"))
    while start not in G:
        start = int(input("Такой вершины в графе нет. С какой вершины начать?"))
    BF(G, start)
        
        #FW(G)
    #shortest_distances = dijkstra(G, start)
    #finish = input("К какой вершине построить путь?")
    #while start not in G:
    #    start = input("Такой вершины в графе нет. К какой вершине построить путь?")
    #shortest_path = reveal_shortest_path(G, start, finish, shortest_distances)
    #print("Кратчайший путь:", shortest_path[::-1])

def read_graph():
    #M = int(input()) # M - количество ребер, далее - строки "A B вес"
    #G = {}
    #for i in range(M):
    #    a,b,weight = input().split()
    #    weight = float(weight)
    #    add_edge(G, a, b, weight)
    #    add_edge(G, b, a, weight)
    #return G
    #return {'A':{'B':2, 'H':15},
    #        'B':{'A':2, 'C':1,'D':5},
    #        'C':{'B':1, 'D':3, 'F':2, 'G':1},
    #        'D':{'B':5,'C':3,'F':4,'E':6},
    #        'E':{'D':6,'F':7,'I':2},
    #        'F':{'C':2,'D':4,'E':7,'G':1,'H':3},
    #        'G':{'C':1,'F':1},
    #        'H':{'A':15,'I':12},
    #        'I':{'E':2,'H':12},
    #        'J':{'K':2},
    #        'K':{'J':2},
    #        }
        return {0:{1:2, 7:15},
            1:{0:2, 2:1,3:5},
            2:{1:1, 3:3, 5:2, 6:1},
            3:{1:5,2:3,5:4,4:6},
            4:{3:6,5:7,8:2},
            5:{2:2,3:4,4:7,6:1,7:3},
            6:{2:1,5:1},
            7:{0:15,8:12},
            8:{4:2,7:12},
            9:{10:2},
            10:{9:2},
            }

###                { 0, new Dictionary<int, int>{ {1,2}, {7,15} } }, //A->B(2),H(15)
#                { 1, new Dictionary<int, int>{ {0,2}, {2,1}, {3,5} } }, //B->A(2),C(1),D(5)
#                { 2, new Dictionary<int, int>{ {1,1},{3,3},{5,2},{6,1} } }, //C-> B(1),D(3),F(2),G(1)
#                { 3, new Dictionary<int, int>{ {1,5},{2,3},{5,4},{4,6} } },//D->B(5),C(3),F(4),E(6)
#                { 4, new Dictionary<int, int>{ {3,6},{5,7},{8,2}} },//E->D(6),F(7),I(2)
#                { 5, new Dictionary<int, int>{ {2,2},{3,4},{4,7},{6,1},{7,3} } },//F->C(2),D(4),E(7),G(1),H(3)
#                { 6, new Dictionary<int, int>{ {2,1},{5,1} } }, //G->C(1),F(1)
#                { 7, new Dictionary<int, int>{ {0,15},{8,12} } }, //H->A(15),I(12)
#                { 8, new Dictionary<int, int>{ {4,2},{7,12} } }, //I->E(2),H(12)
#                { 9, new Dictionary<int, int>{ { 10,2} } }, //J
#                { 10, new Dictionary<int, int>{ { 9,2} } } //K
###

def add_edge(G, a, b, weight):
    if a not in G:
        G[a] = {b: weight}
    else:
        G[a][b] = weight


if __name__ == "__main__":
    main()
