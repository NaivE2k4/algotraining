#Вместо буквенных идентификаторов вершин должны быть числовые (индексы), причем начинающиеся с 1!
# не беллмана-форда!
#Алгоритм находит матрицу кратчайших расстояний из любой вершины в любую
#Использует три цикла, сложность n^3
#Алгоритм с помощью динамического программирования вычисляет путь между вершинами i,j через набор вершин с индексами (1..k)
#Получается примерно как в щалаче о рюкзаке с рюкзаком меньшего размера - здесь на каждой итерации рассматриваются графы меньшего размера
def FW(G):
    vertexNum = len(G.keys())
    matrixSet = [[[-1 for _ in range(vertexNum)] for _ in range(vertexNum)] for _ in range(vertexNum+1)]
    #Первая координата - допустимый радиус соседей, вторая и третья - вершины графа
    baseMatrix = matrixSet[0]
    #Заполним опорную первую матрицу весами между ребрами
    for vertex, edges in G.items():
        for edge in edges.keys():
            baseMatrix[vertex][edge] = edges[edge]
    #baseMatrix[0][0] = 0
    for k in range(1, vertexNum + 1): #ищем путь из i в j использующий вершину с индексом k-1
        for i in range(0, vertexNum): #
            for j in range(0, vertexNum):
                #здесь много if'ов изза представления бесконечно большого веса с помощью -1
                if(matrixSet[k-1][i][k-1] == -1 or matrixSet[k-1][k-1][j] == -1): #нет ребра от i до k или от j до K 
                    if matrixSet[k-1][i][j] == -1:
                        continue
                    matrixSet[k][i][j] = matrixSet[k-1][i][j]
                else:
                    sum = matrixSet[k-1][i][k-1] + matrixSet[k-1][k-1][j]
                    if(matrixSet[k-1][i][j] == -1):
                        matrixSet[k][i][j] = sum
                    else:
                        matrixSet[k][i][j] = min(matrixSet[k-1][i][j], sum)

    return matrixSet
