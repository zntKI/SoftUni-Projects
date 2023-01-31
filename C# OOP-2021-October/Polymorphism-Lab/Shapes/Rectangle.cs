using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        public int MyProperty { get; set; }
        public override double CalculateArea()
        {
            throw new NotImplementedException();
        }

        public override double CalculatePerimeter()
        {
            throw new NotImplementedException();
        }

        public override string Draw()
        {
            throw new NotImplementedException();
        }
    }
}
