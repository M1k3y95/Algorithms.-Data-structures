using System;
using System.Collections.Generic;
using System.Threading;

namespace BFS
{
    /// <summary>
    /// Узел дерева, содержащий значение, текущий уровень и ссылки на родителя и потомков
    /// </summary>
    class Node
    {
        public int Value { get; set; } // Значение ноды
        public int Level { get; set; }
        public Node LeftNode { get; set; } // левый потомок
        public Node RightNode { get; set; } // правый потомок
        public Node ParentNode { get; set; } // родительская нода
    }

    class MyTree
    {
        public Node RootNode { get; set; } // корень дерева

        public MyTree()
        {
            Node rootNode = new Node()
            {
                Value = 8,
                Level = 1,
                LeftNode = new()
                {
                    Value = 4,
                    Level = 2,
                    LeftNode = new()
                    {
                        Value = 2,
                        Level = 3,
                        LeftNode = new() 
                        { 
                            Value = 1, 
                            Level = 4
                        },
                        RightNode = new()
                        {
                            Value = 3,
                            Level = 4
                        }
                    },
                    RightNode = new()
                    {
                        Value = 6,
                        Level = 3,
                        LeftNode = new() 
                        { 
                            Value = 5,
                            Level = 4
                        },
                        RightNode = new()
                        {
                            Value = 7,
                            Level = 4
                        }
                    }
                },
                RightNode = new()
                {
                    Value = 12,
                    Level = 2,
                    LeftNode = new()
                    {
                        Value = 10,
                        Level = 3,
                        LeftNode = new() 
                        { 
                            Value = 9,
                            Level = 4
                        },
                        RightNode = new()
                        {
                            Value = 11,
                            Level = 4
                        }
                    },
                    RightNode = new()
                    {
                        Value = 14,
                        Level = 3,
                        LeftNode = new() 
                        {
                            Value = 13,
                            Level = 4
                        },
                        RightNode = new()
                        {
                            Value = 15,
                            Level = 4
                        }
                    }
                }
            };
            RootNode = rootNode;
        }
    }

    /// <summary>
    /// Поиск в ширину
    /// </summary>
    class SearchBFS
    {
        public MyTree Tree { get; set; }
        public Queue<Node> QueueBFS { get; set; }

        public SearchBFS()
        {
            QueueBFS = new();
            Tree = new();
        }

        public void BFSearch(Node head, int requiredValue)
        {
            QueueBFS.Enqueue(head);

            Console.WriteLine();
            while (QueueBFS.Count > 0)
            {
                Node node = QueueBFS.Dequeue();
                Console.Write($"{new string(' ', node.Level * 2)}{node.Value}");

                if (node.Value == requiredValue)
                {
                    Console.Write( " - искомое значение!");
                    return;
                }
                if (node.RightNode != null) 
                {
                    QueueBFS.Enqueue(node.RightNode);
                }
                if (node.LeftNode != null)
                {
                    QueueBFS.Enqueue(node.LeftNode);
                }
                Console.WriteLine();
                Thread.Sleep(50);
            }
        }

    }

    /// <summary>
    /// Поиск в глубину
    /// </summary>
    class SearchDFS
    {
        public MyTree Tree { get; set; }
        public Stack<Node> StackDFS { get; set; }

        public SearchDFS()
        {
            StackDFS = new();
            Tree = new();
        }

        public void DFSearch(Node head, int requiredValue)
        {
            StackDFS.Push(head);

            Console.WriteLine();
            while (StackDFS.Count > 0)
            {
                Node node = StackDFS.Pop();
                Console.Write($"{new string(' ', node.Level * 2)}{node.Value}");

                if (node.Value == requiredValue)
                {
                    Console.Write(" - искомое значение!");
                    return;
                }
                if (node.LeftNode != null)
                {
                    StackDFS.Push(node.LeftNode);
                }
                if (node.RightNode != null)
                {
                    StackDFS.Push(node.RightNode);
                }
                Console.WriteLine();
                Thread.Sleep(50);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SearchBFS bfs = new();
            bfs.BFSearch(bfs.Tree.RootNode, 9);

            SearchDFS dfs = new();
            dfs.DFSearch(dfs.Tree.RootNode, 1);

            Console.ReadKey();
        }
    }
}
