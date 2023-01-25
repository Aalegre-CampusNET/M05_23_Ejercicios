using System;
using System.Collections.Generic;
using System.Text;

namespace MedianaMediaModa
{
    public class MyList<T>
    {
        private T[] array = new T[1];
        public int Count
        {
            get;
            private set;
        }
        //public int sum
        //{
        //    get
        //    {
        //        int suma = 0;
        //        for (int i = 0; i < Count; i++)
        //        {
        //            suma += array[i];
        //        }
        //        return suma;
        //    }
        //}

        public T Get(int index)
        {
            return array[index];
        }

        public void Add(T item)
        {
            if(Count < array.Length)
            {
                array[Count] = item;
            }
            else
            {
                T[] arrayTemp = new T[Count + Count / 2 + 1];
                for (int i = 0; i < array.Length; i++)
                {
                    arrayTemp[i] = array[i];
                }
                array = arrayTemp;
                array[Count] = item;
            }
            Count++;
        }

        public bool Search(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (array[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
