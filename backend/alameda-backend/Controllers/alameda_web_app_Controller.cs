using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace alameda_backend.Controllers
{
 

  [Route("api/[controller]")]
  public class alameda_web_app_Controller : Controller
  {
    public static string[] returnStrings;

    [HttpPost]
    public void ToSearchPost([FromBody] CodeModel sent)
    {
      Parser parser = new Parser(sent);
      parser.homeStringIsNullOrEmpty();//verifies user input
      parser.patternIsNullOrEmpty();
      parser.regexFunctionSelector();
      returnStrings = parser.returnStrings;
    }

    [HttpGet("results")]
    public ActionResult<string[]> Get()
    {
      return Ok(returnStrings);
    }
  }
}

