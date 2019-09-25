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

        /// <summary>
        /// 取得呼叫同步或者非同步 API 的 Url
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        public static string GetAddAPIUrl(ValueAddDto addDto)
        {
            string url = "";
            if (addDto.IsAsync)
            {
                url = ConstantHelper.AddSyncUrl;
            }
            else
            {
                url = ConstantHelper.AddAsyncUrl;
            }
            //public static readonly string AddSyncUrl = "https://lobworkshop.azurewebsites.net/api/values/AddSync/value1/value2/millisecond";
            url = url.Replace("value1", addDto.Value1.ToString());
            url = url.Replace("value2", addDto.Value2.ToString());
            url = url.Replace("millisecond", addDto.DelayMillisecond.ToString());
            return url;
        }

        /// <summary>
        /// 取得呼叫 Web API 的 HTTP 非同步工作
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        public static Task<string> GetHttpTask(ValueAddDto addDto)
        {
            HttpClient client = new HttpClient();
            var task = client.GetStringAsync(GetAddAPIUrl(addDto));
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

        /// <summary>
        /// 取得 URL 清單
        /// </summary>
        /// <param name="AddDtos"></param>
        /// <returns></returns>
        public static List<string> GetAddAPIUrls(List<ValueAddDto> AddDtos)
        {
            List<string> result = new List<string>();
            foreach (var item in AddDtos)
            {
                result.Add(GetAddAPIUrl(item));
            }
            return result;
        }

        /// <summary>
        /// 取得 URL 清單
        /// </summary>
        /// <param name="AddDtos"></param>
        /// <returns></returns>
        public static List<string> GetAddAPIUrls(ValueAddDto AddDto, int num)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < num; i++)
            {
                result.Add(GetAddAPIUrl(AddDto));
            }
            return result;
        }

        /// <summary>
        /// 取得呼叫 Web API 的 HTTP 非同步工作清單
        /// </summary>
        /// <param name="AddDtos"></param>
        /// <returns></returns>
        public static List<Task<string>> GetHttpTasks(List<ValueAddDto> AddDtos)
        {
            List<Task<string>> tasks = new List<Task<string>>();
            foreach (var item in AddDtos)
            {
                HttpClient client = new HttpClient();
                var task = client.GetStringAsync(GetAddAPIUrl(item));
                tasks.Add(task);
            }
            return tasks;
        }

        /// <summary>
        /// 取得呼叫 Web API 的 HTTP 非同步工作清單
        /// </summary>
        /// <param name="addDto"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static List<Task<string>> GetHttpTasks(ValueAddDto addDto, int num)
        {
            List<Task<string>> tasks = new List<Task<string>>();
            for (int i = 0; i < num; i++)
            {
                HttpClient client = new HttpClient();
                var task = client.GetStringAsync(GetAddAPIUrl(addDto));
                tasks.Add(task);
            }
            return tasks;
        }

    }
}
