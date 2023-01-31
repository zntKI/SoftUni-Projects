using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCountMethodStrings
{
    public class Box<T>
        where T : IComparable
    {
        private List<T> elements;
        public Box()
        {
            elements = new List<T>();
        }

        public int CountLargerElementsByValue(T element)
        {
            //int valueToCompare = 0;
            //foreach (var item in element.ToString())
            //{
            //    valueToCompare += item;
            //}

            //int count = 0;
            //foreach (var item in elements)
            //{
            //    int value = 0;
            //    foreach (var letter in item.ToString())
            //    {
            //        value += letter;
            //    }
            //    if (value > valueToCompare)
            //    {
            //        count++;
            //    }
            //}

            //return count;
            int count = 0;
            foreach (var item in elements)
            {
                if (item.CompareTo(element) > 0)
                {
                    count++;
                }
            }
            return count;
        }

        public void Add(T element)
        {
            elements.Add(element);
        }
    }
}
