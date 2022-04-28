#копия из лекции Хирьянова
from Dykstra import dijkstra
def main():
    G = read_graph()
    start = input("С какйо вершины начать?")
    while start not in G:
        start = input("Такой вершины в графе нет. С какой вершины начать?")
    shortest_distances = dijkstra(G, start)
    finish = input("К какой вершине построить путь?")
    while start not in G:
        start = input("Такой вершины в графе нет. К какой вершине построить путь?")
    #TODO
        #shortest_path = reveal_shortest_path(start, finish, shortest_distances)


def read_graph():
    M = int(input()) # M - количество ребер, далее - строки "A B вес"
    G = {}
    for i in range(M):
        a,b,weight = input().split()
        weight = float(weight)
        add_edge(G, a, b, weight)
        add_edge(G, b, a, weight)
    return G

def add_edge(G, a, b, weight):
    if a not in G:
        G[a] = {b: weight}
    else:
        G[a][b] = weight


if __name__ == "__main__":
    main()
