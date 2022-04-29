from collections import deque

def dijkstra(G, start):
    Q = deque()
    s = {}
    s[start] = 0
    Q.append(start)
    while Q:
        v = Q.popleft()
        for u in G[v]:
            if(u not in s or s[v]+G[v][u] < s[u]):
                s[u] = s[v] + G[v][u]
                Q.append(u)
    return s

def reveal_shortest_path(G, start, finish, shortest_distances):
    startD = shortest_distances[finish]
    cur = finish
    result = [finish]
    #Для неориентированного графа мы могли бы просто пройти по соседям вершины, но если граф ориентирован, надо искать вершины, у которых данная - соседняя
    while startD > 0:
        for vertex, edges in G.items(): #Ищем вершину у которой текущая сосед
            if cur in edges:
                if shortest_distances[vertex] ==  startD - edges[cur]:
                    result.append(vertex)
                    startD -= edges[cur]
                    cur = vertex
                    break
                    
    return result
