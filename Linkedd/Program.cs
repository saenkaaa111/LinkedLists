﻿using System;

namespace List
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Node node = new Node(10);
            //node = node.Next;

            //LinkedList list = new LinkedList(new int[] {77,88,99 } );
            //LinkedList list2 = new LinkedList(new int[]{1,2,3,4,5} );
            //list2.AddAt(2,list);
            
            DoublyLinkedList list = new DoublyLinkedList(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 });
            //DoublyLinkedList list2 = new DoublyLinkedList(new int[] {6,7} );
            //Console.WriteLine(   list.GetLast());
            list.Reverse();
            //list.AddAt(2,78);
            //list.AddLast(20);
            //list.AddLast(28);
            //list.AddLast(29);
            
            

            //list.RemoveLastMultiple(8);
            //list.RemoveAtMultiple(1, 11);
            //int[] result2 = list.SortDesc();
            int[] result = list.ToArray();
            
            foreach (var item in result)
            {
                Console.Write(item+"\t");
            }
            
            //int[] result2 = list.Reverse();
            //Console.WriteLine("ghjgjgj");
            //foreach (var item in result2)
            //{
            //    Console.Write(item+"\t");
            //}
            //Console.WriteLine();
            //Console.WriteLine(   list.IndexOfMin());
            //Console.WriteLine(list.GetLast());

            //Console.WriteLine(list.IndexOfMax());
            //list.RemoveFirst();
            //list.RemoveFirst();
            //list.RemoveFirst();
            //list.RemoveFirst();
            //list.RemoveFirst();
            //list.RemoveFirst();
            //list.RemoveFirst();
            //list.AddLast(12);
            ////list.AddAt(0, 3333);
            //list.AddLast(45);
            //list.AddLast(89);
            //list.AddLast(81);
            //list.Set(9, 33333);
            ////list.AddFirst(7777);
            //list.RemoveAt(3);

            //Console.WriteLine("jj");
            //Console.WriteLine(list.GetLenght());

            //Console.WriteLine(list.ToArray());

        }
    }
}
