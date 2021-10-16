using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    class Circle:Figure
    {
        public int Radius {
            get
            {
                return radius;
            }
            set 
            {
                radius = value; 
            }
        }
        private int radius;
        public Circle(int radius)
        {
            this.radius = radius;
        }
    }
}
