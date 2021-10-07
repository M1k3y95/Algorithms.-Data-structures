using System;

namespace lesson_2._1
{
    // Задание: Требуется реализовать класс двусвязного списка и операции вставки,
    // удаления и поиска элемента в нём в соответствии с интерфейсом.


    public class Node
    {
        public int Value { get; set; }
        public Node NextNode { get; set; }
        public Node PrevNode { get; set; }
    }

    //Начальную и конечную ноду нужно хранить в самой реализации интерфейса
    public interface ILinkedList
    {
        int GetCount(); // возвращает количество элементов в списке
        void AddNode(int value);  // добавляет новый элемент списка
        void AddNodeAfter(Node node, int value); // добавляет новый элемент списка после определённого элемента
        void RemoveNode(int index); // удаляет элемент по порядковому номеру
        void RemoveNode(Node node); // удаляет указанный элемент
        Node FindNode(int searchValue); // ищет элемент по его значению
    }

    class LinkList : ILinkedList
    {


        public Node FirstNode { get; set; }
        public Node LastNode { get; set; }

        public void AddNode(int value)
        {

            Node node = new Node() { Value = value, PrevNode = LastNode };
            if (LastNode == null)
            {
                FirstNode = node;
                LastNode = FirstNode;
            }
            else
            {
                LastNode.NextNode = node;
                LastNode = node;
            }
        }

        public void AddNodeAfter(Node node, int value)
        {
            Node newNode = new Node() { Value = value, PrevNode = node, NextNode = node.NextNode };

            if (node.NextNode != null)
            {
                node.NextNode.PrevNode = newNode;
            }

            node.NextNode = newNode;
            if (LastNode == node)
            {
                LastNode = newNode;
            }
        }

        public Node FindNode(int searchValue)
        {
            Node accioNode = new Node();
            accioNode = FirstNode;

            do
            {
                if (accioNode.Value == searchValue)
                {
                    return accioNode;
                }

                accioNode = accioNode.NextNode;

            } while (accioNode != null);

            return null;
        }

        public int GetCount()
        {
            Node someNode = new Node();
            someNode = FirstNode;

            int counter = 0;

            while (someNode != null)
            {
                counter++;
                someNode = someNode.NextNode;
            }

            return counter;
        }

        public void RemoveNode(int index)
        {
            Node removeNode = new Node();
            removeNode = FirstNode;

            for (int i = 0; i < index; i++)
            {
                removeNode = removeNode.NextNode;
                if (removeNode == null)
                {
                    Console.WriteLine("Указанный индекс в списке отсутствует!\n");
                    return;
                }
            }
            removeNode.PrevNode.NextNode = removeNode.NextNode;
            removeNode.NextNode.PrevNode = removeNode.PrevNode;
        }

        public void RemoveNode(Node node)
        {
            Node removeNode = new Node();
            removeNode = FindNode(node.Value);

            if (removeNode == LastNode)
            {
                removeNode.PrevNode.NextNode = null;
                LastNode = removeNode.PrevNode;
                return;
            }

            if (removeNode == null)
            {
                Console.WriteLine("Указанный элемент в списке отстутствует!\n");
                return;
            }


            removeNode.PrevNode.NextNode = removeNode.NextNode;
            removeNode.NextNode.PrevNode = removeNode.PrevNode;
        }
    }

    class Test
    {
        public void TestList()
        {
            LinkList linkList = new LinkList();

            linkList.AddNode(101); // 101

            linkList.AddNode(100500); // 101, 100500

            linkList.AddNode(1337); // 101, 100500, 1337

            linkList.AddNode(5051); // 101, 100500, 1337, 5051

            linkList.AddNode(9001); // 101, 100500, 1337, 5051, 9001

            linkList.AddNode(1408); // 101, 100500, 1337, 5051, 9001, 1408

            PrintList(linkList);

            linkList.AddNodeAfter(linkList.FirstNode, 666); // 101, 666, 100500, 1337, 5051, 9001, 1408

            linkList.AddNodeAfter(linkList.LastNode, 777); // 101, 666, 100500, 1337, 5051, 9001, 1408, 777

            PrintList(linkList);

            linkList.RemoveNode(3); // 101, 666, 100500, 5051, 9001, 1408, 777

            linkList.RemoveNode(99); // Указанный индекс в списке отсутствует!

            PrintList(linkList);

            Node node = new Node();
            node.Value = 444;
            linkList.RemoveNode(node); // Указанный элемент в списке отстутствует!

            PrintList(linkList);

            node.Value = 666;
            linkList.RemoveNode(node); // 101, 100500, 5051, 9001, 1408, 777

            node.Value = 777;
            linkList.RemoveNode(node); // 101, 100500, 5051, 9001, 1408

            PrintList(linkList);
        }

        private void PrintList(LinkList linkList)
        {
            Node node = linkList.FirstNode;
            while (node != null)
            {
                Console.Write($"| { node.Value} |");
                node = node.NextNode;
            }
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Test newTest = new Test();

            newTest.TestList();
        }
    }
}
