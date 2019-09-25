using System;
using Vulcan.Courses;

namespace VulcanCoursesTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(AsyncCourse.GetThreadPoolHint(true));
            Console.WriteLine(AsyncCourse.GetThreadPoolInfo(true));
            Console.WriteLine(AsyncCourse.CurrentThreadId);
            AsyncCourse.PressAnyKey();
        }
    }
}
