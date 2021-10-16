using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    class Square:Figure
    {
        public int Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
            }
        }
        private int size;
        public Square (int size)
        {
            this.size = size;
        }
       
    }
}
