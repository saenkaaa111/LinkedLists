using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linkedd
{
    public class DoublyLinkedList
    {
        private DoublyNode _head;
        private DoublyNode _tail;

        public DoublyLinkedList()
        {
            _head = null;
            _tail = _head;
        }
        public DoublyLinkedList(int value)
        {
            _head = new DoublyNode(value);
            _tail = _head;
        }
        public DoublyLinkedList(int[] value)
        {
            if (value.Length != 0)
            {
                _head = new DoublyNode(value[0]);
                DoublyNode current;
                _tail = _head;
                for (int i = 0; i < value.Length; i++)
                {
                    _tail.Next = new DoublyNode(value[i]);
                    current = _tail;
                    _tail = _tail.Next;
                    _tail.Prev = current;
                    
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
                DoublyNode current = _head;
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
            int[] array = new int[0];
            if (length > 1)
            {
                array = new int[length];
                DoublyNode current = _head.Next;
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
        public void AddFirst(int val)
        {
            if (GetLenght() == 0)
            {
                DoublyLinkedList lst = new DoublyLinkedList(val);
                _head = lst._head;
            }
            else
            {
                DoublyNode current = _head;
                DoublyNode node = new DoublyNode(val);
                node.Next = current.Next;
                current.Next = node;
                current.Prev = null;
            }

        }
        public void AddLast(int val)
        {
            if (GetLenght() == 0)
            {
                AddFirst(val);
            }
            else
            {
                DoublyNode current = _tail;
                _tail.Next = new DoublyNode(val);
                _tail = _tail.Next;
                _tail.Prev = current;
            }

        }
        public void AddAt(int idx, int val)
        {
            if (GetLenght() > idx)
            {
                DoublyNode current = _head;
                for (int i = 0; i < idx; i++)
                {
                    current = current.Next;
                }

                DoublyNode node = new DoublyNode(val);
                node.Next = current.Next;
                node.Prev = current.Next.Prev;
                current.Next.Prev = node;
                current.Next = node;                
                current.Next.Value = node.Value;
                               
            }
            else
            {
                throw new NullReferenceException("Индекс больше чем количество элементов");
            }
        }

        public void Set(int idx, int val)
        {
            if (idx == 0 && GetLenght() == 1)
            {
                _head = new DoublyNode(val);

            }
            else if (GetLenght() > idx)
            {
                if (idx == GetLenght() - 1)
                {
                    DoublyNode nodep = new DoublyNode(val);
                    nodep.Prev = _tail.Prev;
                    nodep.Next = null;
                    _tail.Value = nodep.Value;

                }
                else
                {
                    DoublyNode current = _head;
                    for (int i = 0; i < idx; i++)
                    {
                        current = current.Next;
                    }
                    DoublyNode node = new DoublyNode(val);
                    node.Next = current.Next;
                    node.Prev = current.Prev;
                    current.Next.Next.Prev = node;
                    current = node;
                    current.Next.Value = node.Value;
                }
               
            }
            else
            {
                throw new NullReferenceException("Индекс больше чем количество элементов");
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
                        _head.Next.Prev = null;
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
        public void RemoveFirst()
        {
            if (GetLenght() == 0)
            {
                throw new NullReferenceException("Нет элементов");
            }
            else
            {
                RemoveFirstMultiple(1);
            }


        }
        public void RemoveLast()
        {
            if (_head != null)
            {
                DoublyNode current = _tail.Prev;
                _tail.Prev.Next = null;
                _tail = current;
            }
            else
            {
                throw new NullReferenceException("Нет элементов");
            }
        }
        public void RemoveLastMultiple(int n)
        {
            if (GetLenght() == 0 || GetLenght() < n)
            {
                throw new NullReferenceException("Нет элементов");
            }
            for (int i = 0; i < n; i++)
            {
                RemoveLast();
            }
        }

        public int IndexOf(int val)
        {
            int idx = 0;
            if (GetLenght() == 0)
            {
                throw new NullReferenceException("Нет элементов");
            }
            if (_head != null)
            {
                DoublyNode current = _head.Next;
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
            return idx;
        }

        public int Max()
        {
            int val;
            if (_head != null)
            {
                val = _head.Value;
                DoublyNode current = _head;
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
            if (GetLenght() == 0)
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
                DoublyNode current = _head;
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
                DoublyNode current = _head.Next;
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
            else
            {
                throw new NullReferenceException("Нет элементов");
            }
            return result;
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
        public int GetLast()
        {
            if (GetLenght() != 0)
            {
                return _tail.Value;
            }
            else
            {
                throw new NullReferenceException("Нет элементов");
            }

        }
        public int Get(int idx)
        {
            int value = -1;
            if (_head != null)
            {
                int lenght = GetLenght();
                if (lenght > idx)
                {
                    DoublyNode current = _head;
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
    }
}
