using System;
using System.Text;

namespace _03_GenericList
{
    [Version(2,5)]
    public class GenericList<T>
    {
        private const int DefaultCapacity = 16;

        private T[] elements;
        private int count = 0;

        public GenericList(int capacity = DefaultCapacity)
        {
            this.elements = new T[capacity];
        }

        public int Count
        {
            get { return this.count; }
        }

        public int Capacity
        {
            get { return this.elements.Length; }
        }

        //public static T Min<T>(GenericList<T> list)
        //    where T : IComparable<T>
        //{
        //    T min = default(T);
        //    for (int i = 1; i < list.Count; i++)
        //    {
        //        if (list[i - 1].CompareTo(list[i]) <= 0)
        //        {
        //            min = list[i - 1];
        //        }
        //    }
        //    return min;
        //}

        //public static T Max<T>(GenericList<T> list)
        //    where T : IComparable<T>
        //{
        //    T max = default(T);
        //    for (int i = 1; i < list.Count; i++)
        //    {
        //        if (list[i-1].CompareTo(list[i]) <= 0)
        //        {
        //            max = list[i];
        //        }
        //    }
        //    return max;
        //} 

        public T this[int i]
        {
            get
            {
                if (i < 0 || i >= this.count)
                {
                    throw new IndexOutOfRangeException(String.Format(
                        "Invalid index: {0}.", i));
                }

                T result = this.elements[i];

                return result;
            }
        }

        public void Add(T element)
        {
            if (this.count + 1 >= this.elements.Length)
            {
                this.ResizeArrayLength();
            }
            this.elements[this.count] = element;
            count++;
        }

        public T GetElementByIndex(int index)
        {
            if (index < 0 || index >= this.count)
            {
                throw new IndexOutOfRangeException("Invalid index");
            }
            T element = this.elements[index];
            return element;
        }

        public void RemoveElementByIndex(int index)
        {
            if (index < 0 || index >= this.count)
            {
                throw new IndexOutOfRangeException("Invalid index.");
            }
            T[] removedElement = new T[this.elements.Length];
            Array.Copy(this.elements, 0, removedElement, 0, index);
            Array.Copy(this.elements, index + 1, removedElement, index, this.elements.Length - index - 1);
            this.elements = removedElement;
            this.count--;
        }

        public void InsertElementAtPos(int pos, T element)
        {
            if (pos < 0)
            {
                throw new IndexOutOfRangeException("Invalid position.");
            }
            if (pos + 1 >= this.elements.Length)
            {
                this.ResizeArrayLength();
            }
            T[] insertedElement = new T[elements.Length];
            Array.Copy(this.elements, 0, insertedElement, 0, pos);
            insertedElement[pos] = element;

            if (pos >= this.count)
            {
                this.count = pos;
            }
            else
            {
                this.count++;
                Array.Copy(this.elements, pos, insertedElement, pos + 1, this.Count - pos - 1);
            }
            this.elements = insertedElement;
        }

        public void ClearList()
        {
            this.elements = new T[this.elements.Length];
            this.count = 0;
        }

        public int FindIndexOfElement(T element)
        {
            for (int i = 0; i < this.count; i++)
            {
                if (this.elements[i].Equals(element))
                {
                    return i;
                }
            }
            return -1;
        }

        public bool CheckIfContains(T element)
        {
            bool contains = this.FindIndexOfElement(element) != -1;
            return contains;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < this.Count; i++)
            {
                sb.Append(this.elements[i]);
                if (i != this.count - 1)
                {
                    sb.Append(", ");
                }
            }
            return sb.ToString();
        }

        public void ResizeArrayLength()
        {
            T[] doubledElements = new T[elements.Length*2];
            Array.Copy(elements, doubledElements, elements.Length);
            this.elements = doubledElements;
        }
    }
}
