

using System;
using System.Collections.Generic;

namespace CSharpBinTree
{
    public class MyBinTree
    {
        public BinTreeNode Root { get; set; } = null;
        public int CurrentHeight = 0;

        public void Print()
        {
            //if(CurrentHeight == 0)
            //{
            //    Console.WriteLine("Tree is empty");
            //    return;
            //}
            //var q = new Dictionary<int, List<int?>>();
            //var curNode = Root;
            //var curLevel = 1;
            //q[1] = new List<int?> { Root.Value };
            //while(true)
            //{
                
            //}

            //for(int level = 0; level < CurrentHeight; level++)
            //{ 
                
            //}
        
        }

        public void Add(int val)
        {
            var newNode = new BinTreeNode(val);
            if(Root == null)
            {
                Root = newNode;
                return;
            }
            var curNode = Root;
            while(true)
            {
                if(curNode.Left == null && curNode.Right == null)
                    CurrentHeight++;

                if(val < curNode.Value)
                {
                    if(curNode.Left == null)
                    {
                        curNode.Left = newNode;
                        return;
                    }
                    else
                    { 
                        curNode = curNode.Left;
                    }
                }
                else if(val > curNode.Value)
                {
                    if(curNode.Right == null)
                    {
                        curNode.Right = newNode;
                        return;
                    }
                    else
                        curNode = curNode.Right;
                }
                else return;
            }
        }

        private void SetNodeChild(BinTreeNode node, BinTreeNode child, bool isLeft)
        {
            if(isLeft)
                node.Left = child;
            else
                node.Right = child;
        }

        public void Remove(int val)
        {
            if(Root == null)
                return;
            var curNode = Root;
            BinTreeNode parent = null;
            bool parentLeft = false;
            while(true)
            {
                if(curNode.Value > val)
                {
                    parent = curNode;
                    parentLeft = true;
                    curNode = curNode.Left;
                    continue;
                }
                else if(curNode.Value < val)
                {
                    parent = curNode;
                    parentLeft = false;
                    curNode = curNode.Right;
                    continue;
                }
                //нашли элемент
                //4 варианта - у элемента нет детей, левый, правый или оба
                if(curNode.Right == null && curNode.Left == null)
                {
                    SetNodeChild(parent, null, parentLeft);
                    return;
                }

                if(curNode.Right != null && curNode.Left == null)
                {
                    SetNodeChild(parent, curNode.Right, parentLeft);
                    return;
                }
                if(curNode.Right == null && curNode.Left != null)
                {
                    SetNodeChild(parent, curNode.Left, parentLeft);
                    return;
                }
                else //найти самый левый узел правого поддерева
                {
                    var curNode2 = curNode.Right; //Начало правого поддерева
                    BinTreeNode parent2 = null; 
                    while(curNode2.Left != null) //Перемещаем указатель левее пока можно
                    {
                        parent2 = curNode2;
                        curNode2 = curNode2.Left;
                    }
                    //Левее потомков нет но может быть правее
                    if(parent2 != null) parent2.Left = curNode2.Right;
                    curNode2.Left = curNode.Left;
                    SetNodeChild(parent, curNode2, parentLeft);
                    if(curNode.Right != curNode2) //Если это не первый потомок, а то зациклимся...
                        curNode2.Right = curNode.Right;
                    return;
                }

            }
        }

        public bool Search(int val)
        {
            return SearchRec(Root, val);
        }

        private bool SearchRec(BinTreeNode node, int val)
        {
            if(node == null)
                return false;
            if(node.Value == val)
                return true;
            if(node.Value > val)
                return SearchRec(node.Left, val);
            else
                return SearchRec(node.Right, val);
        }
    }
}
