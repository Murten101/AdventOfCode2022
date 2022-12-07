using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    internal class SolutionAttribute : Attribute
    {
        private int day;
        public SolutionAttribute(int day) { 
            this.day = day;
        }
        public virtual int Day => day;
    }
}
