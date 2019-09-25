using System;
using System.Threading;

namespace Vulcan.Courses
{
    /// <summary>
    /// 這是 .NET C# 非同步程式設計會用到的共用API
    /// </summary>
    public class AsyncCourse
    {
        public static int WorkerThreadsAvailable;
        public static int CompletionPortThreadsAvailable;
        public static int WorkerThreadsMax;
        public static int CompletionPortThreadsMax;
        public static int WorkerThreadsMin;
        public static int CompletionPortThreadsMin;

        /// <summary>
        /// 按下任一按鍵以繼續
        /// </summary>
        public static void PressAnyKey()
        {
            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
        }

        /// <summary>
        /// 取得當前執行緒集區上的執行緒設定與數量資訊
        /// </summary>
        /// <returns></returns>
        public static string GetThreadPoolInfo(bool breakLine = false)
        {
            var lineSeparate = breakLine ? Environment.NewLine : "";
            DateTime Begin = DateTime.Now;
            ThreadPool.GetAvailableThreads(out WorkerThreadsAvailable, out CompletionPortThreadsAvailable);
            ThreadPool.GetMaxThreads(out WorkerThreadsMax, out CompletionPortThreadsMax);
            ThreadPool.GetMinThreads(out WorkerThreadsMin, out CompletionPortThreadsMin);
            DateTime Complete = DateTime.Now;
            return
                $"AW:{WorkerThreadsAvailable} / AIOC:{CompletionPortThreadsAvailable} " + lineSeparate +
                $"MaxW:{WorkerThreadsMax} / MaxIOC:{CompletionPortThreadsMax} " + lineSeparate +
                $"MinW:{WorkerThreadsMin} / MinIOC:{CompletionPortThreadsMin} "+ Environment.NewLine;

        }

        /// <summary>
        /// 取得執行緒集區的相關資訊標題說明
        /// </summary>
        /// <returns></returns>
        public static string GetThreadPoolHint(bool breakLine = false)
        {
            var lineSeparate = breakLine ? Environment.NewLine : "";
            return
                "AW:可用背景工作執行緒的數目 / " + lineSeparate +
                "AIOC:可用非同步 I/O 執行緒的數目" + lineSeparate +
                "MaxW:執行緒集區中的背景工作執行緒最大數目 / " + lineSeparate +
                "MaxIOC:執行緒集區中的非同步 I/O 執行緒最大數目" + lineSeparate +
                "MinW:執行緒集區視需要建立的背景工作執行緒最小數目 / " + lineSeparate +
                "MinIOC:執行緒集區視需要建立的非同步 I/O 執行緒最小數目"+ Environment.NewLine;
        }
        /// <summary>
        /// 取得當前執行緒 ID 的資訊字串
        /// </summary>
        public static string CurrentThreadId
        {
            get
            {
                return $"執行緒ID={Thread.CurrentThread.ManagedThreadId}";
            }
        }
    }
}
