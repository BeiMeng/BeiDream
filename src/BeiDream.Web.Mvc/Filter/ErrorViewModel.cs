using System;

namespace BeiDream.Web.Mvc.Filter
{
    public class ErrorViewModel
    {
        public string ErrorInfo { get; set; }

        public Exception Exception { get; set; }

        public ErrorViewModel()
        {

        }

        public ErrorViewModel(Exception exception)
        {
            Exception = exception;
            ErrorInfo = exception.Message;
        } 
    }
}