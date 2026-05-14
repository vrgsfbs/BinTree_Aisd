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
                else if (root.Data < data)
                {
                    root.Left = AddRecursive(root, data); //если данные меньше, чем данные текущего узла, добавляем в левую ветку
                }
                else
                {
                    root.Right = AddRecursive(root, data); //если данные больше, чем у текущего узла, добавляем в правую ветку 
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




        static void Main(string[] args)
        {
            BinTreeM bt = new BinTreeM();
            bt.AddElement(1);
        }
        

    }
}