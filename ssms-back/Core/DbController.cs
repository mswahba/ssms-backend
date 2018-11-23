using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SSMS.MvcFilters;
using SSMS.ViewModels;
using SSMS.EntityModels;

namespace SSMS
{
  // [Authorize]
  [ApiExceptionFilter]
  [ApiController]
  [Route("[controller]")]
  public class DbController : ControllerBase
  {
    private readonly BaseService _service;

    public DbController(BaseService service)
    {
      _service = service;
    }
    // execute sql query statement [select] using Ado
    [HttpGet("query/{sql}")]
    public IActionResult Query([FromRoute] string sql)
    {
      var result = Ado.ExecuteQuery(sql);
      return Ok(result);
    }
    // execute sql Command statement [insert - update - delete] using Ado
    [HttpGet("sql-command/{sqlCommand}")]
    public IActionResult SqlCommand([FromRoute] string sqlCommand)
    {
      int rows = Ado.ExecuteNonQuery(sqlCommand);
      return Ok($"{rows} row(s) affected ...");
    }
    // dynamically get all sqlView rows by its viewName
    [HttpGet("views/{viewName}")]
    public IActionResult Views([FromRoute] string viewName)
    {
      Type viewType = Helpers.GetAllClasses("SSMS.ViewModels")
            .SingleOrDefault(t => t.Name == viewName);
      return Ok(_service.GetView(viewType));
    }
  }
}