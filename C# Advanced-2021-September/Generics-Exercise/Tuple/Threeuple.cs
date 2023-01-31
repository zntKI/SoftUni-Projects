using System;
using System.Collections.Generic;
using System.Text;

namespace Tuple
{
    public class Threeuple<T, K, J>
    {
        private T item1;
        private K item2;
        private J item3;

        public Threeuple(T item1, K item2, J item3)
        {
            this.item1 = item1;
            this.item2 = item2;
            this.item3 = item3;
        }

        public string Print()
        {
            return $"{item1} -> {item2} -> {item3}";
        }
    }
}
