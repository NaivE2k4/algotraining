using System;

namespace CSharpSortings
{
    //public class HeapNode
    //{ 
    //    public HeapNode Left { get; set; }
    //    public HeapNode Right { get; set; }
    //    public int Value { get; set; }
    //} //Не нужно, куча можнет реализоваться через массив!
    public class MyHeap
    {
        public int[] _array;
        public int HeapSize { get; set; } = 0;
        private readonly int MaxSize;
        public MyHeap(int size = 50)
        {
            _array = new int[size];
            MaxSize = size;
        }

        public MyHeap(int[] arr, int heapLen)
        {
            _array = arr;
            HeapSize = heapLen;
            MaxSize = arr.Length;
            for(int i = HeapSize / 2; i >= 0; i--)
                Heapify_Down(i);
        }

        public int GetLeftChild(int parentIndex)
        {
            return _array[2 * parentIndex + 1];
        }

        public int GetLeftChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 1;
        }
        public int GetRightChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 2;
        }

        public int GetRightChild(int parentIndex)
        {
            return _array[2 * parentIndex + 2];
        }

        public int GetParent(int curIndex)
        {
            return _array[curIndex / 2];
        }

        public int GetParentIndex(int curIndex)
        {
            return (curIndex-1) / 2;
        }

        public void Add(int val)
        {
            if(HeapSize + 1 > MaxSize)
                throw new System.Exception();
            _array[HeapSize] = val;
            HeapSize++;
            Heapify_Up(HeapSize-1);

        }
        public void Heapify_Up(int index)
        {
            if(index == 0)
                return;
            var parentIndex = GetParentIndex(index);
            if(_array[parentIndex] < _array[index])
            {
                var tmp = _array[parentIndex];
                _array[parentIndex] = _array[index];
                _array[index] = tmp;
                Heapify_Up(parentIndex);
            }
        }

        public void Heapify_Down(int index)
        {
            var lci = GetLeftChildIndex(index);
            var rci = GetRightChildIndex(index);
            bool maxRight = false;
            int max;
            if(lci < HeapSize)
                max = _array[lci];
            else return;
            if(rci < HeapSize)
                if(_array[rci] > max)
                {
                    max = _array[rci];
                    maxRight = true;
                }
            if(max > _array[index])
            {
                var target = maxRight ? rci : lci;
                var tmp = _array[index];
                _array[index] = _array[target];
                _array[target] = tmp;
                Heapify_Down(target);
            }
        }

        public int? PopMax()
        {
            if(HeapSize == 0)
                return null;
            var tmp = _array[0]; //В array[0] хранится наш максимум
            HeapSize--;
            if(HeapSize == 0)
                return tmp;
            _array[0] = _array[HeapSize]; //Переставляем последний элемент в начало
            _array[HeapSize] = 0;
            Heapify_Down(0);
            return tmp;
        }


    }
}
