using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSwapMethodStrings
{
    public class Box<T>
    {
        private List<T> elements;

        public Box()
        {
            elements = new List<T>();
        }

        public void Add(T item)
        {
            elements.Add(item);
        }

        public void SwapElements(int firstIndex, int secondIndex)
        {
            if (firstIndex >= 0 && firstIndex < elements.Count && secondIndex >= 0 && secondIndex < elements.Count)
            {
                T first = elements[firstIndex];
                elements[firstIndex] = elements[secondIndex];
                elements[secondIndex] = first;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in elements)
            {
                sb.AppendLine($"System.Int32: {item}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
