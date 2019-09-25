using System;
using System.Collections.Generic;
using System.Text;

namespace Vulcan.Courses
{
    public class ThreadPoolInfo
    {
        public int WorkerThreadsAvailable;
        public int CompletionPortThreadsAvailable;
        public int WorkerThreadsMax;
        public int CompletionPortThreadsMax;
        public int WorkerThreadsMin;
        public int CompletionPortThreadsMin;
    }
}
