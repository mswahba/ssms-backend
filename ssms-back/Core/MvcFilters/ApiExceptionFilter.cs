using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SSMS.MvcFilters
{
  public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
  {
    public override void OnException(ExceptionContext actionContext)
    {
      actionContext.Result = new BadRequestObjectResult(actionContext.Exception);
    }
  }
}