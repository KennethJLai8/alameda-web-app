using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace alameda_backend.Controllers
{
  public class CodeModel
  {
    public string pattern { get; set; }

    public string homeString { get; set; }

    public bool regexFlag { get; set; }

    public bool matchCaseFlag { get; set; }

    public bool wholeWordFlag { get; set; }
  }

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
        returnStrings = individualWords;
      }

      if (regex == true)
      {
        for (int i = 0; i < pattern.Length; i++)
        {
          if (pattern[i] == '?')
          {
            pattern = pattern.Remove(i, 1).Insert(i, ".");
          }
          if (pattern[i] == '*')
          {
            pattern = pattern.Remove(i, 1).Insert(i, ".*");
            i++;
          }
          if (pattern[i] == '~')
          {
            pattern = pattern.Remove(i, 1).Insert(i, "\\");
            i++;
          }
        }

        List<string> regMatchCaseList = new List<string>();

        if (matchCase == true)
        {
          foreach (String s in individualWords)
          {
            if (Regex.IsMatch(s, pattern))
            {
              regMatchCaseList.Add(s);
            }
          }
        }
        else
        {
          Regex regexCaseIns =
              new Regex(pattern, RegexOptions.IgnoreCase);
          foreach (String s in individualWords)
          {
            if (regexCaseIns.IsMatch(s))
            {
              regMatchCaseList.Add(s);
            }
          }
        } //end of matchCase

        string[] regMatchCaseArr = regMatchCaseList.ToArray();

        List<string> regwholeWordlist = new List<string>();

        if (wholeWord == true)
        {
          string patternRegex = "(\\b|^)" + pattern + "(\\b|$)";
          Regex regexCaseIns =
              new Regex(patternRegex, RegexOptions.IgnoreCase);

          foreach (string s in regMatchCaseArr)
          {
            if (regexCaseIns.IsMatch(s))
            {
              regwholeWordlist.Add(s);
            }
          }
          string[] regWholeWordListArr = regwholeWordlist.ToArray();

          returnStrings = regWholeWordListArr;
        }
        else
        {
          returnStrings = regMatchCaseArr;
        } //end of wholeWord
      }
      else
      {
        List<string> list = new List<string>();

        if (matchCase == true)
        {
          foreach (String s in individualWords)
          {
            if (s.Contains(pattern))
            {
              list.Add(s);
            }
          }
        }
        else
        {
          foreach (String s in individualWords)
          {
            if (
                s
                    .Contains(pattern,
                    System
                        .StringComparison
                        .CurrentCultureIgnoreCase)
            )
            {
              list.Add(s);
            }
          }
        } //end of matchCase

        string[] matchCaseArray = list.ToArray();
        List<string> wholeWordlist = new List<string>();

        if (wholeWord == true)
        {
          string patternRegex = "\\b" + pattern + "\\b";
          Regex regexCaseIns =
              new Regex(patternRegex, RegexOptions.IgnoreCase);

          foreach (string s in matchCaseArray)
          {
            if (regexCaseIns.IsMatch(s))
            {
              wholeWordlist.Add(s);
            }
          }

          string[] wholeWordListArr = wholeWordlist.ToArray();

          returnStrings = wholeWordListArr;
        }
        else
        {
          returnStrings = matchCaseArray;
        } //end of wholeWord
      } //end of regex
    }

    [HttpGet("Bleach")]
    public ActionResult<string[]> Get()
    {
      return Ok(returnStrings);
    }
  }
}

