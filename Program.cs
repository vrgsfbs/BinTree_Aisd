﻿﻿using System.ComponentModel;
using System.Net.WebSockets;

namespace deque_lab
{
    internal class Program
    {
        public class TreeNode
        {
            public int Data {get; set;}
            public TreeNode Left {get;set;}
            public TreeNode Right {get;set;}

            public TreeNode(int data)
            {
                Data = data;
                Left = null;
                Right = null;
            }
        }

        public class BinTreeM
        {
            private int count = 0;
            public TreeNode Root {get; set;}

            public void AddElement(int data)
            {
                count++;
                Root = AddRecursive(Root, data);
            }
            private TreeNode AddRecursive(TreeNode root, int data)
            {
                if (root == null) //если элемент пустой, возвращаем узел с данными
                {
                    return new TreeNode(data);
                }
                else if (data < root.Data) //если данные меньше, чем данные текущего узла, добавляем в левую ветку
                {
                    root.Left = AddRecursive(root, data); 
                }
                else //если данные больше (или равны), чем у текущего узла, добавляем в правую ветку 
                {
                    root.Right = AddRecursive(root, data); 
                }
                return root;
            }
            public TreeNode Delete(TreeNode root, int data)
            {
                if (root == null) return null;
                
                if (data < root.Data) //если удаляемый элемент меньше, чем текущий
                    root.Left = Delete(root.Left, data);
                else if (data > root.Data)
                    root.Right = Delete(root.Right, data);
                else
                {
                    if (root.Left == null)
                        return root.Right;
                    else if (root.Right == null)
                        return root.Left;
                    else
                    {
                        TreeNode newcur = FindMin(root.Right);
                        root.Data = newcur.Data;
                        root.Right = Delete(root.Right, newcur.Data);
                    }
                }
                    count--;
                    return root;
            }
            public TreeNode FindMin(TreeNode root)
            {
                if (root == null) return null;
                if (root.Left == null) return root;
                return FindMin(root.Left);
                
            }
            public TreeNode FindMax(TreeNode root)
            {
                if (root == null) return null;
                if (root.Right == null) return root;
                return FindMin(root.Right);
                
            }
            public TreeNode Clear(TreeNode root) {return null;}

            public string PrintLKP()
            {
                if (Root == null) return "Дерево пустое";
                
                string result = PrintLKPRecursive(Root);
                return result;
            }
            private string PrintLKPRecursive(TreeNode current)
{
                if (current == null) return "";

                string ldata = PrintLKPRecursive(current.Left);

                string curdata = current.Data + " ";

                string rdata = PrintLKPRecursive(current.Right);

                return ldata + curdata + rdata;
            }
            public void PrintPretty()
            {
                if (Root == null)
                {
                    Console.WriteLine("Дерево пустое");
                    return;
                }
                PrintPrettyRecursive(Root, "", " ");
            }

            private void PrintPrettyRecursive(TreeNode root, string indent, string link)
            {
                if (root == null) return;

                PrintPrettyRecursive(root.Right, indent + (link == " /" ? "    " : "    "), " /");
                Console.WriteLine(indent + link + root.Data);
                PrintPrettyRecursive(root.Left, indent + (link == " \\" ? "    " : "    "), " \\");
            }
            public void LevelOrder()
            {
                if (Root == null) return;

                //очередь, в которую будем складывать узлы
                Queue<TreeNode> queue = new Queue<TreeNode>();

                // Кладем в очередь корень дерева
                queue.Enqueue(Root);

                while (queue.Count > 0)
                {
                    // первый узел из очереди
                    TreeNode node = queue.Dequeue();

                    Console.Write(node.Data + " ");

                    if (node.Left != null)
                    {
                        queue.Enqueue(node.Left);
                    }

                    if (node.Right != null)
                    {
                        queue.Enqueue(node.Right);
                    }
                }
            }
            // public string PrintLKR(TreeNode root)
            // {
            //     string result_string="";
            //     if (root == null) return result_string;
            //     PrintLKR(root.Left);
            //     result_string+=$"{root.Data} ";
            //     PrintLKR(root.Left);
            // }
            // public string PrintLRK(TreeNode root)
            // {
            //     string result_string="";
            //     if (root == null) return result_string;
            //     PrintLRK(root.Left);
            //     PrintLRK(root.Right);
            //     result_string+=$"{root.Data} ";
            // }

        }
        public static void Zadanie1(TreeNode root)
        {
            if (root == null) return;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            int level = 1;
            while (queue.Count > 0)
            {
                int nodesAtLevel = queue.Count; // Количество узлов на текущем "этаже"
                int maxVal = int.MinValue;    // Временная переменная для максимума

                // Проходим только те узлы, которые относятся к текущему уровню
                for (int i = 0; i < nodesAtLevel; i++)
                {
                    TreeNode node = queue.Dequeue();
                    
                    if (node.Data > maxVal) 
                        maxVal = node.Data;

                    if (node.Left != null) queue.Enqueue(node.Left);
                    if (node.Right != null) queue.Enqueue(node.Right);
                }

                Console.WriteLine($"Уровень {level}: Максимум = {maxVal}");
                level++;
            }
        }
        public static void Zadanie2(TreeNode root)
        {
            if (root == null) return;
            root.Data = root.Data * 2;
            // удваиваем в поддеревьях
            Zadanie2(root.Left);
            Zadanie2(root.Right);
        }



        static void Main(string[] args)
        {
            BinTreeM bt = new BinTreeM();
            bt.AddElement(1);
        }
        

    }
}