using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace prolab3
{
    public class Liste<T> : IEnumerable<T>, IEnumerable, ICollection<T>
    {
        private const int baslangic = 10;
        private T[] items;
        private int boyut;
        

        public Liste()
        {
            items = new T[baslangic];
        }

        public int Count => boyut;

        public void Add(T item)
        {
            if (boyut == items.Length)
            {
                Array.Resize(ref items, items.Length * 2);
            }

            items[boyut++] = item;
        }

       public T this[int index]
        {
            get
            {
                if (index < 0 || index >= boyut)
                {
                    throw new IndexOutOfRangeException("Index is outside the bounds of the list!");
                }
                return items[index];
            }
            set
            {
                if (index < 0 || index >= boyut)
                {
                    throw new IndexOutOfRangeException("Index is outside the bounds of the list!");
                }
                items[index] = value;
            }
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= boyut)
            {
                throw new IndexOutOfRangeException("Index is outside the bounds of the list!");
            }

            Array.Copy(items, index + 1, items, index, boyut - index - 1);
            items[--boyut] = default;
        }

        public bool Contains(T item)
        {
            return items.Take(boyut).Contains(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < boyut; i++)
            {
                yield return items[i];
            }
        }

       IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Clear()
        {
            boyut = 0;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(items, 0, array, arrayIndex, boyut);
        }

        public bool Remove(T item)
        {
            int index = Array.IndexOf(items, item, 0, boyut);
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }
            return false;
        }

        public bool IsReadOnly => false;
    }
}
