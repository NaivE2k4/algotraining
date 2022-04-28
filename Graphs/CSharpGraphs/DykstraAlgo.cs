using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGraphs
{
    //Функции алгоритма дейкстры, без ООП
    public static class DykstraAlgo
    {
        /// <summary>
        /// Алгоритм Дейкстры с использованием очереди обхода графа
        /// Одна Вершина в нем может просматриваться несколько раз
        /// Требование: неотрицательные веса вершин
        /// </summary>
        /// <param name="graph">Граф в формате {индекс вершины:{Множество кортежей(индекс_вершины, вес)}}</param>
        /// <param name="startIndex">Вершина от которой ищем кратч пути</param>
        /// <returns>Список вершин, составляющих кратчайший путь</returns>
        public static List<int> DykstraQueue(Dictionary<int, Dictionary<int, int>> graph, int startIndex, int finishIndex)
        {
            var workDict = new Dictionary<int, int>(); //Словарь для учета стоимостей {вершина:текущая_мин_стоимость}
            foreach(var vertexIndex in graph.Keys)
            {
                workDict[vertexIndex] = -1; //-1 будем считать бесконечным расстоянием
            }
            workDict[startIndex] = 0; //добраться в стартовую вершину из самой себя бесплатно=)
            var workingQueue = new Queue<int>(new[]{ startIndex}); //Очередь для обхода в ширину (BFS)
            while(workingQueue.Count > 0)
            {
                var currentIndex = workingQueue.Dequeue();
                var currentWeight = workDict[currentIndex];
                foreach( var (neigh, weight) in graph[currentIndex])
                {
                    var edgeWeight = currentWeight + weight;
                    if(workDict[neigh] == -1 || currentWeight < workDict[neigh])
                    {
                        workDict[neigh] = edgeWeight;
                        workingQueue.Enqueue(neigh);
                    }
                }
            
            }

            return GetPath(graph, workDict, finishIndex,startIndex);
        }

        //Алгоритм без использования очереди, жадный. Не возвращается к уже обработанным вершинам
        public static List<int> DykstraGreedy(Dictionary<int, Dictionary<int, int>> graph, int startIndex, int finishIndex)
        {
            var workDict = new Dictionary<int, int>(); //Словарь для учета стоимостей {вершина:текущая_мин_стоимость}
            //var usedVertexes = new Dictionary<int, bool>();
            var nonUsedVertexes = new HashSet<int>();
            foreach(var vertexIndex in graph.Keys)
            {
                workDict[vertexIndex] = -1; //-1 будем считать бесконечным расстоянием
                //usedVertexes[vertexIndex] = false;
                nonUsedVertexes.Add(vertexIndex);
            }
            workDict[startIndex] = 0; //добраться в стартовую вершину из самой себя бесплатно=)
            //usedVertexes[startIndex] = true;
            var currentIndex = startIndex;
            while(nonUsedVertexes.Any())
            {
                nonUsedVertexes.Remove(currentIndex);
                foreach(var (neib, weight) in graph[currentIndex])
                {
                    if(nonUsedVertexes.Contains(neib))
                    {
                        if(workDict[neib] == -1 || workDict[neib] > workDict[currentIndex] + weight)
                        {
                            workDict[neib] = workDict[currentIndex] + weight; 
                        }
                    }
                }
                //Обновили соседние вершины
                var minVal = -1;
                var minIndex = 0;
                //Ищем минимальную по стоимости вершину
                foreach(var v in nonUsedVertexes)
                {
                    if(workDict[v] != -1 &&
                        (minVal == -1 || workDict[v] < minVal))
                    {
                        minVal = workDict[v];
                        minIndex = v;
                    }
                }
                if(minVal == -1)
                    break; //Возможно если есть несвязанные вершины
                currentIndex = minIndex;
            }
            return GetPath(graph, workDict, finishIndex, startIndex);
        }

        private static List<int> GetPath(Dictionary<int, Dictionary<int, int>> graph, Dictionary<int, int> vertexWeights, int finishIndex, int target)
        {
            var pathInverted = new Stack<int>();
            var result = new List<int>();
            pathInverted.Push(finishIndex);
            FindShortPath(graph, vertexWeights, pathInverted, target); //Рекурсивное нахождение обратного пути, DFS
            while(pathInverted.Any())
                result.Add(pathInverted.Pop());
            return result;

        }

        private static bool FindShortPath(Dictionary<int, Dictionary<int, int>> graph, Dictionary<int, int> vertexWeights, Stack<int> curPath, int target)
        {
            var curIndex = curPath.Peek();
            foreach(var (vertexId, edges) in graph)
            {
                if(!edges.ContainsKey(curIndex))
                    continue;

                if(vertexWeights[curIndex] == vertexWeights[vertexId] + edges[curIndex])
                {
                    curPath.Push(vertexId);
                    if(vertexId == target)
                        return true;
                    if(!FindShortPath(graph, vertexWeights, curPath, target))
                        curPath.Pop();
                    else return true;
                }
            }
            throw new Exception();
        }
    }
}
