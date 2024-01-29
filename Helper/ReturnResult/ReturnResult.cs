using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginRegisterSystem.Helper.ReturnResult
{
    public class ReturnResult<T>
    {

        public ReturnResult(T data, bool success, string errorMessage)
        {
            this.Data = data;
            this.Success = success;
            this.ErrorMessage = errorMessage;
        }
        public T Data { get; set; }
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }
}
