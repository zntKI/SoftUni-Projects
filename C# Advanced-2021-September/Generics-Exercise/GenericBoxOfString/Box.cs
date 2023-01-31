using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBoxOfString
{
    public class Box<T>
    {
        private List<T> elements;
        public Box()
        {
            elements = new List<T>();
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

        public void Add(T element)
        {
            elements.Add(element);
        }
    }
}
