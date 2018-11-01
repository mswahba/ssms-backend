using System;

namespace SSMS
{
  public class Response<T> where T : class
  {
    public Response()
    {
      Error = null;
      Exception = null;
      Data = null;
    }
    public T Error { get; set; }
    public T Exception { get; set; }
    public T Data { get; set; }
  }
}