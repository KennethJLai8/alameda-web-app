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
      bool regex = sent.regexFlag;
      bool matchCase = sent.matchCaseFlag;
      bool wholeWord = sent.wholeWordFlag;

      string toSearch = sent.homeString;
      string pattern = sent.pattern;

      string[] individualWords;

      if (string.IsNullOrEmpty(toSearch))
      {
        string[] empty = { " " };
        individualWords = empty;
      }
      else
      {
        individualWords = toSearch.Split(' ');
  
      }

      Parser parser = new Parser(toSearch, pattern, matchCase, wholeWord, individualWords);

      if(regex == true)
      {
        parser.regexTrue();
        returnStrings = parser.returnStrings;
      }
      else
      {
        parser.regexFalse();
        returnStrings = parser.returnStrings;
      }

      
    }

    [HttpGet("results")]
    public ActionResult<string[]> Get()
    {
      return Ok(returnStrings);
    }
  }
}

