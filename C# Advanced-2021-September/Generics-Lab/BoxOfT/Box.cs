using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> Elements = new List<T>();
        public int Count 
        {
            get
            {
                return Elements.Count;
            }
        }
        public void Add(T element)
        {
            Elements.Add(element);
        }
        public T Remove()
        {
            T element = Elements[Elements.Count - 1];
            Elements.RemoveAt(Elements.Count - 1);
            return element;
        }
    }
}
