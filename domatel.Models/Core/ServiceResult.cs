using System;
using System.Collections.Generic;
using System.Text;

namespace domatel.Models.Core
{
    public class ServiceResult<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public int Status { get; set; }
    }
    
    public class ServiceResult
    {
        public string Message { get; set; }
        public int Status { get; set; }
    }
}
