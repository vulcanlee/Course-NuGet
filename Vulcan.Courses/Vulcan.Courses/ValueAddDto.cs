using System;
using System.Collections.Generic;
using System.Text;

namespace Vulcan.Courses
{
    public class ValueAddDto
    {
        public bool IsAsync { get; set; }
        public int Value1 { get; set; }
        public int Value2 { get; set; }
        public int DelayMillisecond { get; set; }
    }
}
