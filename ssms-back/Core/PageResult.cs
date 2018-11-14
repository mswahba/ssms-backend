using System.Collections.Generic;

namespace SSMS
{
  public class PageResult<TEntity> where TEntity : class
  {
    public List<dynamic> PageItems { get; set; }
    public int TotalItems { get; set; }
    public int TotalPages { get; set; }
  }
}