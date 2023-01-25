using System;

namespace MedianaMediaModa
{
    public class MyChain
    {
        private class Element
        {
            public Element prev;
            public int value;
            public Element next;
        }

        Element first = null;
        Element last = null;
        public int Count
        {
            get;
            private set;
        }

        public void Add(int value)
        {
            if (Count > 0)
            {
                Element newElement = new Element();
                newElement.value = value;
                newElement.prev = last;
                last.next = newElement;
                last = newElement;
            }
            else
            {
                Element newElement = new Element();
                newElement.value = value;
                first = newElement;
                last = newElement;
            }
            Count++;
        }
        public int Get(int index)
        {
            if (index < Count / 2)
            {
                Element actual = first;
                for (int i = 0; i < index; i++)
                {
                    actual = actual.next;
                }
                return actual.value;
            }
            else
            {
                Element actual = last;
                for (int i = index - 1; i >= 0; i--)
                {
                    actual = actual.prev;
                }
                return actual.value;
            }
        }

        public bool Search(int item)
        {
            Element actual = first;
            while(actual.value != item)
            {
                if(actual.next == null)
                {
                    return false;
                }
                actual = actual.next;
            }
            return true;
        }
    }
}
