using System;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using CommonWebsite.Infrastructure.Utilities;

namespace CommonWebsite.Infrastructure.Mvc
{
    public class StandardJsonResult : ActionResult, IStandardResult
    {
        public string ContentType { get; set; }

        #region Implementation of ICustomResult

        public bool Success { get; set; }

        public string Message { get; set; }

        public void Succeed()
        {
            Success = true;
        }

        public void Fail()
        {
            Success = false;
        }

        public void Succeed(string message)
        {
            Success = true;
            Message = message;
        }

        public void Fail(string message)
        {
            Success = false;
            Message = message;
        }

        public void Try(Action action)
        {
            try
            {
                action();
                Succeed();
            }
            catch (Exception)
            {
            
            }
        }

        #endregion

        public override void ExecuteResult(ControllerContext context)
        {
            var response = context.HttpContext.Response;
            WriteToResponse(response);
        }

        protected virtual IStandardResult ToCustomResult()
        {
            var result = new StandardResult {Success = Success, Message = Message};
            return result;
        }

        public void ValidateModelState(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid)
            {
                var message = "<h5>Please clear the errors first:</h5><ul>";
                foreach (var error in modelState.Values.SelectMany(x => x.Errors))
                {
                    if (!string.IsNullOrEmpty(error.ErrorMessage))
                    {
                        message += "<li>" + error.ErrorMessage + "</li>";
                    }
                }
                message += "</ul>";
                Fail(message);
            }
            else
            {
                Succeed();
            }
        }

        public void WriteToResponse(HttpResponseBase response)
        {
            if (string.IsNullOrEmpty(ContentType))
            {
                response.ContentType = "application/json";
            }
            else
            {
                response.ContentType = ContentType;
            }
            response.ContentEncoding = Encoding.UTF8;
            response.Write(Serializer.ToJson(ToCustomResult()));
        }
    }
}
