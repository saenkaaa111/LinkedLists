using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linkedd
{
    public class LinkedList
    {
        private Node _head;
        private Node _tail;

        public LinkedList()
        {
            _head = null;
            _tail = _head;
        }
        public LinkedList(int value)
        {            
            _head = new Node(value);
            _tail = _head;
        }
        public LinkedList(int[] value)
        {
            if (value.Length != 0)
            {
                _head = new Node(value[0]);
                _tail = _head;
                for (int i = 0; i < value.Length; i++)
                {
                    _tail.Next = new Node(value[i]);
                    _tail = _tail.Next;
                }
            }
            else
            {
                _head = null;
                _tail = _head;
            }
        }
        public int GetLenght()
        {
            int lenght = 0;
            if (_head != null)
            {
                Node current = _head;
                lenght += 1;
                while (current.Next != null)
                {
                    lenght += 1;
                    current = current.Next;
                }
            }
            if (lenght == 1 || lenght == 0)
            {
                return lenght;
            }
            else
            {
                return lenght - 1;
            }

        }

        public int[] ToArray()
        {
            int length = GetLenght();
            int[] array=new int[0];
            if (length>1)
            {
                array = new int[length];
                Node current = _head.Next;
                for (int i = 0; i < length; i++)
                {
                    array[i] = current.Value;
                    current = current.Next;
                }
            }
            else if (length == 1)
            {
                array = new int[1] { _head.Value };                
            }
            return array;
        }


        public void AddLast(int val)
        {
            if (GetLenght() == 0)
            {
                AddFirst(val);
            }
            else
            {
                _tail.Next = new Node(val);
                _tail = _tail.Next;
            }
                
        }
        public void AddFirst(int val)
        {
            if (GetLenght() == 0)
            {
                LinkedList lst = new LinkedList(val);
                _head = lst._head;
            }
            else
            {
                Node current = _head;
                Node node = new Node(val);
                node.Next = current.Next;
                current.Next = node;
            }
            
        }
        public void AddAt(int idx, int val)
        {
            if (GetLenght() > idx)
            {
                Node current = _head;
                for (int i = 0; i < idx; i++)
                {
                    current = current.Next;
                }
                
                Node node = new Node(val);
                node.Next = current.Next;
                current.Next = node;
                current.Next.Value = node.Value;
            }
            else
            {
                throw new NullReferenceException("Индекс больше чем количество элементов");
            }
        }

        public void AddLast(LinkedList list)
        {

            if (GetLenght() == 0)
            {
                _head = list._head;
            }
            else if (list.GetLenght() == 0)
            {
                _head = _head;
            }
            else
            {
                _tail.Next = list._head.Next;
            }
        }
        public void AddFirst(LinkedList list)
        {

            if (GetLenght() == 0)
            {
                _head = list._head;
            }
            else if (list.GetLenght() == 0)
            {
                _head = _head;
            }
            else
            {
                Node current = _head;
                _head = list._head;
                list._tail.Next = current.Next;
            }
        }
        public void AddAt(int idx, LinkedList list)
        {

            if (list.GetLenght() == 0)
            {
                _head = _head;
            }
            else if (GetLenght() > idx)
            {
                Node current = _head;
                for (int i = 0; i < idx; i++)
                {
                    current = current.Next;
                }
                Node node = current.Next;
                current.Next = list._head.Next;

                list._tail.Next = node;
            }
            else
            {
                throw new NullReferenceException("Индекс больше чем количество элементов");
            }
        }

        public void Set(int idx, int val)
        {
            if (idx==0 && GetLenght()==1)
            {
                _head = new Node(val);
               
            }
            else if (GetLenght() > idx)
            {
                Node current = _head;
                for (int i = 0; i < idx; i++)
                {
                    current = current.Next;
                }
                Node node = new Node(val);
                node.Next = current.Next;
                current = node;
                current.Next.Value = node.Value;
            }
            else
            {
                throw new NullReferenceException("Индекс больше чем количество элементов");
            }

        }

        public void RemoveFirst()
        {
            if (GetLenght()==0)
            {
                throw new NullReferenceException("Нет элементов");
            }
            else
            {
                RemoveFirstMultiple(1);
            }
            

        }
        public void RemoveFirstMultiple(int n)
        {
            if (GetLenght() != 0)
            {
                if (GetLenght() > n)
                {
                    for (int i = 0; i < n; i++)
                    {
                        _head = _head.Next;
                    }
                }
                else
                {
                    _head = null;
                }
            }
            else
            {
                throw new NullReferenceException("Нет элементов");
            }

        }
        public int GetFirst()
        {
            if (GetLenght() != 0)
            {
                return _head.Value;
            }
            else
            {
                throw new NullReferenceException("Нет элементов");
            }
        }
        public void RemoveLast()
        {
            if (GetLenght()==1)
            {
                RemoveFirstMultiple(1);
            }
            else if (_head != null)
            {
                Node current = _head;
                if (current.Next != null)
                {
                    while (current.Next.Next != null)
                    {
                        current = current.Next;
                    }
                    current.Next = null;
                }
            }
            else
            {
                throw new NullReferenceException("Нет элементов");
            }
        }
        public void RemoveLastMultiple(int n)
        {
            if (GetLenght()==0 || GetLenght()<n)
            {
                throw new NullReferenceException("Нет элементов");
            }            
            for (int i = 0; i < n; i++)
            {
                RemoveLast();
            }
        }

        public int GetLast()
        {
            int value = -1; 
            if (_head != null)
            {
                Node current = _head;
                if (current.Next != null)
                {
                    while (current.Next.Next != null)
                    {
                        current = current.Next;
                    }
                    value = current.Next.Value;                    
                }
                
            }
            else
            {
                throw new NullReferenceException("Нет элементов");
            }
            return value;

        }
        public void RemoveAt(int idx)
        {
            if (GetLenght() > idx)
            {
                RemoveAtMultiple(idx, 1);
            }
            else
            {
                throw new NullReferenceException("Индекс за пределами");
            }
            
        }
        public void RemoveAtMultiple(int idx,int n)
        {
            int lenght = GetLenght();
            if (lenght == 1 && n > 0)
            {
                RemoveFirst();
            }
            else if (lenght > idx)
            {
                if (_head != null)
                {
                    Node current = _head;
                    for (int i = 0; i < idx; i++)
                    {
                        current = current.Next;
                    }
                    Node cur = current.Next;
                    int mid;
                    if (n < lenght - idx)
                    {
                        mid = idx + n;
                    }
                    else
                    {
                        mid = lenght;
                    }
                    for (int i = idx + 1; i < mid; i++)
                    {
                        cur = cur.Next;
                    }
                    current.Next = cur.Next;
                }
            }
            else
            {
                throw new NullReferenceException("Индекс за пределами");
            }
        }

        public int RemoveFirst(int val)
        {
            int idx = 0;
            if (GetLenght()==0)
            {
                throw new NullReferenceException("Нет элементов");
            }
            if (_head != null)
            {
                Node current = _head;
                if (current.Next != null)
                {
                    while (current.Next.Next != null)
                    {
                        if (val == current.Next.Value)
                        {
                            current.Next = current.Next.Next;
                            return idx;
                        }
                        current = current.Next;
                        idx += 1;
                    }
                }
            }
            idx = 0;
            if (_tail.Value == val)
            {
                int length = GetLenght();
                Node current = _head;
                for (int i = 0; i < length - 1; i++)
                {
                    current = current.Next;
                }
                current.Next = null;
                idx++;
            }
            return idx;
        }


        public int RemoveAll(int val)
        {
            int count = 0;
            while (Contains(val) == true)
            {
                RemoveFirst(val);
                count++;
            } 
            if (GetLenght()==0)
            {
                throw new NullReferenceException("Нет элементов");
            }
            return count;            
        }


        public int Get(int idx)
        {
            int value = -1;
            if (_head != null)
            {
                int lenght = GetLenght();
                if (lenght > idx)
                {
                    Node current = _head;
                    for (int i = 0; i < idx; i++)
                    {
                        current = current.Next;
                    }
                    value = current.Next.Value;
                }
            }
            else
            {
                throw new NullReferenceException("Нет элементов");
            }
            return value;
        }

        public int Max()
        {
            int val;
            if (_head != null)
            {
                val = _head.Value;
                Node current = _head;
                if (current.Next != null)
                {
                    while (current != null)
                    {
                        if (val < current.Value)
                        {
                            val = current.Value;
                        }
                        current = current.Next;
                    }
                }
            }
            else
            {
                throw new NullReferenceException("Нет элементов");
            }
            return val;
        }
        public int IndexOfMax()
        {
            if (GetLenght()==0)
            {
                throw new NullReferenceException("Нет элементов");
            }
            else
            {
                int max = Max();
                int idx = IndexOf(max);
                return idx;
            }
            
        }
        public int Min()
        {
            int val;
            if (_head != null)
            {
                val = _head.Value;
                Node current = _head;
                if (current.Next != null)
                {
                    while (current != null)
                    {
                        if (val > current.Value)
                        {
                            val = current.Value;
                        }
                        current = current.Next;
                    }
                }
            }
            else
            {
                throw new NullReferenceException("Нет элементов");
            }
            return val;
        }

        public int IndexOfMin()
        {
            if (GetLenght() == 0)
            {
                throw new NullReferenceException("Нет элементов");
            }
            else
            {
                int min = Min();
                int idx = IndexOf(min);
                return idx;
            }
        }


        public bool Contains(int val)
        {
            bool result = false;
            if (_head != null)
            {
                Node current = _head.Next;
                if (_tail != null)
                {
                    while (current != null)
                    {
                        if (val == current.Value)
                        {
                            result = true;
                            break;
                        }
                        current = current.Next;
                    }
                }
            }
            else
            {
                throw new NullReferenceException("Нет элементов");
            }
            return result;
        }

        public int IndexOf(int val)
        {
            int idx = 0;
            if (GetLenght()==0)
            {
                throw new NullReferenceException("Нет элементов");
            }
            if (_head != null)
            {
                Node current = _head.Next;
                if (_tail != null)
                {
                    while (current != null)
                    {
                        if (val == current.Value)
                        {
                            return idx;
                        }
                        idx += 1;
                        current = current.Next;
                    }
                }
                idx = -1;
            }
            return idx;
        }

        public int[] Reverse()
        {
            int length = GetLenght();
            int[] array;
            if (length==0)
            {
                array = new int[0];
            }
            else
            {
                array = new int[length];
                Node current = _head.Next;
                for (int i = length - 1; i >= 0; i--)
                {
                    array[i] = current.Value;
                    current = current.Next;
                }
            }
            
            return array;
        }

        public int[] Sort()
        {
            int length = GetLenght();
            int[] array = ToArray();
            int min;
            int variable;
            for (int i = 0; i < length - 1; i++)
            {
                min = i;
                for (int j = i + 1; j < length; j++)
                {
                    if (array[j] < array[min])
                    {
                        min = j;
                    }
                }
                variable = array[min];
                array[min] = array[i];
                array[i] = variable;
            }
            return array;

        }
        public int[] SortDesc()
        {
            int length = GetLenght();
            int[] array = ToArray();
            int variable;
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (j == length - 1)
                    {
                        continue;
                    }
                    while (array[j] < array[j + 1])
                    {
                        variable = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = variable;
                    }
                }
            }
            return array;

        }
    }
}

