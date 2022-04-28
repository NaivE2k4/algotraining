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
