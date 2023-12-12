using System;

class BinaryTreeSort
{

    class Node
    {
        public int data;
        public Node left, right;


        public Node(int item)
        {
            data = item;
            left = right = null;
        }
    }

    Node root;

    BinaryTreeSort()
    {
        root = null;
    }

    void insert(int key)
    {
        root = insertRec(root, key);
    }

    Node insertRec(Node root, int key)
    {
        if (root == null)
        {
            root = new Node(key);
            return root;
        }


        if (key < root.data)
            root.left = insertRec(root.left, key);

        else if (key > root.data)
            root.right = insertRec(root.right, key);

        return root;
    }


    void storeSorted(Node root, int[] arr, ref int i)
    {
        if (root != null)
        {

            storeSorted(root.left, arr, ref i);

            arr[i++] = root.data;

            storeSorted(root.right, arr, ref i);
        }
    }


    void treeSort(int[] arr, int n)
    {
        for (int b = 0; b < n; b++)
            insert(arr[b]);

        int i = 0;
        storeSorted(root, arr, ref i);
    }


    static void Main()
    {
        BinaryTreeSort tree = new BinaryTreeSort();
        int[] arr = { 5, 4, 7, 2, 11, 14, 6 };
        int n = arr.Length;

        tree.treeSort(arr, n);

        Console.WriteLine("Arreglo ordenado:");
        foreach (var item in arr)
        {
            Console.Write(item + " ");
        }
    }
}