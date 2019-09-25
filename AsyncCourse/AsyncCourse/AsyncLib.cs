using System;

namespace AsyncCourse
{
    public class AsyncLib
    {
        /// <summary>
        /// 按下任一按鍵以繼續
        /// </summary>
        public static void PressAnyKey()
        {
            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
        }
    }
}
