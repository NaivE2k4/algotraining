def BF(G, start):
    #Для нахождения кратчайших путей от одной вершины до всех остальных, воспользуемся методом динамического программирования. 
    #Построим матрицу {\displaystyle A_{ij}}A_{{ij}}, элементы которой будут обозначать следующее: {\displaystyle a_{ij}}a_{{ij}} — это длина кратчайшего пути 
    #из {\displaystyle s}s в {\displaystyle i}i, содержащего не более {\displaystyle j}j рёбер.
    edgeCount = 0
    for edges in G.values():
        edgeCount+=len(edges.values())
    d = [[-1 if x != start else 0 for x in range(len(G.keys()))] for _ in range(edgeCount+1)]
    #Строки - ребра, колонки - вершины
    for i in range(1,len(G.keys())): #i - кол-во ребер
        for vertexA, edges in G.items(): #Перебираем ребра
            for vertexB, value in edges.items():
                if d[vertexB][i] > d[vertexA][i-1] + value or d[vertexB][i-1] == -1:
                    d[vertexB][i] = d[vertexA][i-1] + value
    return d
