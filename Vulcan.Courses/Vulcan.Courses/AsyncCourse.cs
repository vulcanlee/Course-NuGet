using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Vulcan.Courses
{
    /// <summary>
    /// 這是 .NET C# 非同步程式設計會用到的共用API
    /// </summary>
    public class AsyncCourse
    {
        public static ThreadPoolInfo ThreadPoolInfo = new ThreadPoolInfo();

        /// <summary>
        /// 取得當前執行緒集區上的執行緒設定與數量資訊
        /// </summary>
        /// <returns></returns>
        public static string GetThreadPoolInfo(bool breakLine = false)
        {
            var lineSeparate = breakLine ? Environment.NewLine : "";
            DateTime Begin = DateTime.Now;
            QueryThreadPoolInfo(ThreadPoolInfo);
            DateTime Complete = DateTime.Now;
            return
                $"AW:{ThreadPoolInfo.WorkerThreadsAvailable} / AIOC:{ThreadPoolInfo.CompletionPortThreadsAvailable} " + lineSeparate +
                $"MaxW:{ThreadPoolInfo.WorkerThreadsMax} / MaxIOC:{ThreadPoolInfo.CompletionPortThreadsMax} " + lineSeparate +
                $"MinW:{ThreadPoolInfo.WorkerThreadsMin} / MinIOC:{ThreadPoolInfo.CompletionPortThreadsMin} " + Environment.NewLine;

        }

        public static void QueryThreadPoolInfo(ThreadPoolInfo threadPoolInfo)
        {
            ThreadPool.GetAvailableThreads(out threadPoolInfo.WorkerThreadsAvailable, out threadPoolInfo.CompletionPortThreadsAvailable);
            ThreadPool.GetMaxThreads(out threadPoolInfo.WorkerThreadsMax, out threadPoolInfo.CompletionPortThreadsMax);
            ThreadPool.GetMinThreads(out threadPoolInfo.WorkerThreadsMin, out threadPoolInfo.CompletionPortThreadsMin);
            DateTime Complete = DateTime.Now;
            return;
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
                "MinIOC:執行緒集區視需要建立的非同步 I/O 執行緒最小數目" + Environment.NewLine;
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

        public static string GetAddAPIUrl(int value1, int value2, int delayms, bool isAsync)
        {
            string url = "";
            if (isAsync)
            {
                url = ConstantHelper.AddAsyncUrl;
            }
            else
            {
                url = ConstantHelper.AddSyncUrl;
            }
            url = url.Replace("value1", value1.ToString());
            url = url.Replace("value2", value2.ToString());
            url = url.Replace("millisecond", delayms.ToString());
            return url;
        }

        public static List<string> GetAddAPIUrls(List<(int value1, int value2, int delayms, bool isAsyn)> addParas)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < addParas.Count; i++)
            {
                var item = addParas[i];
                result.Add(GetAddAPIUrl(item.value1, item.value2, item.delayms, item.isAsyn));
            }
            return result;
        }

        public static Task<string> GetHttpTask(int value1, int value2, int delayms, bool isAsync)
        {
            HttpClient client = new HttpClient();
            var task = client.GetStringAsync(GetAddAPIUrl(value1, value2, delayms, isAsync));
            return task;
        }

        /// <summary>
        /// 取得呼叫 Web API 的 HTTP 非同步工作
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static Task<string> GetHttpTask(string url)
        {
            HttpClient client = new HttpClient();
            var task = client.GetStringAsync(url);
            return task;
        }

        public static void Output(params (string content, CColor color)[] items)
        {
            ConsoleColor currentColor = Console.ForegroundColor;
            foreach (var item in items)
            {
                Console.ForegroundColor =(ConsoleColor)(Enum.Parse(typeof(ConsoleColor), item.color.ToString()));
                Console.Write(item.content);
            }
            Console.ForegroundColor = currentColor;
            Console.WriteLine();
        }

        public static void ShowThreadInformation(string msg)
        {
            Output((msg, CColor.White),
                ($" {AsyncCourse.CurrentThreadId}", CColor.Green));
        }

        /// <summary>
        /// 按下任一按鍵以繼續
        /// </summary>
        public static void PressAnyKey()
        {
            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
        }

    }
    public enum CColor
    {
        //
        // 摘要:
        //     The color black.
        Black = 0,
        //
        // 摘要:
        //     The color blue.
        Blue = 9,
        //
        // 摘要:
        //     The color cyan (blue-green).
        Cyan = 11,
        //
        // 摘要:
        //     The color dark blue.
        DarkBlue = 1,
        //
        // 摘要:
        //     The color dark cyan (dark blue-green).
        DarkCyan = 3,
        //
        // 摘要:
        //     The color dark gray.
        DarkGray = 8,
        //
        // 摘要:
        //     The color dark green.
        DarkGreen = 2,
        //
        // 摘要:
        //     The color dark magenta (dark purplish-red).
        DarkMagenta = 5,
        //
        // 摘要:
        //     The color dark red.
        DarkRed = 4,
        //
        // 摘要:
        //     The color dark yellow (ochre).
        DarkYellow = 6,
        //
        // 摘要:
        //     The color gray.
        Gray = 7,
        //
        // 摘要:
        //     The color green.
        Green = 10,
        //
        // 摘要:
        //     The color magenta (purplish-red).
        Magenta = 13,
        //
        // 摘要:
        //     The color red.
        Red = 12,
        //
        // 摘要:
        //     The color white.
        White = 0xF,
        //
        // 摘要:
        //     The color yellow.
        Yellow = 14
    }

}
