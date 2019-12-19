using System;
using System.Collections.Generic;
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
            var url=AsyncCourse.GetAddAPIUrl(3, 5, 2000, false);
            var urls = AsyncCourse.GetAddAPIUrls(new List<(int value1, int value2, int delayms, bool isAsync)>
            {
                (15,21,2000, true),
                (175,21,1000, true),
                (15,321,4000, true),
            });
            AsyncCourse.Output((url,CColor.Yellow), ("abcc", CColor.Red));
            AsyncCourse.ShowThreadInformation("Test...");
            AsyncCourse.PressAnyKey();
        }
    }
}
