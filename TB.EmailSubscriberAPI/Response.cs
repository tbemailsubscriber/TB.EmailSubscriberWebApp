using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TB.EmailSubscriberAPI
{
    public class CustomResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }

        public static CustomResponseData CreateCustomResponseWithData(int code, string message, object obj)
        {
            return new CustomResponseData() { Code = code, Message = message, Object = obj };
        }

        public static CustomResponse CreateCustomResponse(int code, string message)
        {
            return new CustomResponse() { Code = code, Message = message };
        }

    }

    public class CustomResponseData : CustomResponse
    {
        public object Object { get; set; }
    }


}
