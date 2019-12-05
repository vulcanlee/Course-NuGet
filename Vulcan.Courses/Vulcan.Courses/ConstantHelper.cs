using System;
using System.Collections.Generic;
using System.Text;

namespace Vulcan.Courses
{
    public class ConstantHelper
    {
        public static readonly string AddSyncUrl = "https://lobworkshop.azurewebsites.net/api/Course/AddSync/value1/value2/millisecond";
        public static readonly string AddAsyncUrl = "https://lobworkshop.azurewebsites.net/api/Course/AddASync/value1/value2/millisecond";
        public static readonly string AddSyncDetailUrl = "https://lobworkshop.azurewebsites.net/api/Course/AddSyncWithThreadPoolInformation/value1/value2/millisecond";
        public static readonly string AddAsyncDetailUrl = "https://lobworkshop.azurewebsites.net/api/Course/AddAsyncWithThreadPoolInformation/value1/value2/millisecond";
    }
}
