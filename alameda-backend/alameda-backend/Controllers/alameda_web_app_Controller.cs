using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860




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
    /*
    public static string[] returnStrings =//won't show up until i click continue on the exception in httpPost
    { "Ichigo",                   //this is being returned becuase it's initialized outside of the httpPost function?
      "Rukia",
      "Naruto",
      "Rengi",
      "Itadori",
      "Megumi",
      "Nobara",
      "Shinji"
    };*/

    public static string[] returnStrings;





  // GET: api/values
  /*
  [HttpGet]
  public IEnumerable<string> Get()
  {
    return new string[] { "value1", "value2" };
  }*/


  // GET api/values/5
      

    // POST api/values
    [HttpPost]
    //[Route("UpdateBleach")]
    public bool ToSearchPost([FromBody]CodeModel sent)
    {
      bool regex = sent.regexFlag;
      bool matchCase = sent.matchCaseFlag;
      bool wholeWord = sent.wholeWordFlag;

      string toSearch = sent.homeString;
      string pattern = sent.pattern;

      //string toSearch = " ";//this works with the split. maybe have to initialze individiual words array first
      string[] individualWords;

      //break down string into substrings


 

      if (string.IsNullOrEmpty(toSearch))
      {
        string[] empty = { " " };
        individualWords = empty;
      
      }
      else
      {
        individualWords = toSearch.Split(' ');//delimeter in parameter?
        //alameda_web_app_Controller.returnStrings = individualWords;
        returnStrings = individualWords;
     
      }


      //string test = "te?st~?*";

      if (regex == true)
      {
        for (int i = 0; i < pattern.Length; i++)//turns query string(cod) into regex string
        {
          if (pattern[i] == '?')//change all "test" variables to "pattern"
          {
            pattern = pattern.Remove(i, 1).Insert(i, ".");
          }
          if (pattern[i] == '*')
          {
            //pattern = pattern.Replace("*", ".*");
            pattern = pattern.Remove(i, 1).Insert(i, ".*");
            i++;
          }
          if (pattern[i] == '~')
          {
            pattern = pattern.Remove(i, 1).Insert(i, "\\");
            i++;
          }
        }

        //Console.Write(pattern);//success outputs: co.e

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
          //(?-i)foobar
          //string caseInsReg = "(?-i)" + pattern;
          Regex regexCaseIns = new Regex(pattern, RegexOptions.IgnoreCase);
          foreach (String s in individualWords)
          {
            if (regexCaseIns.IsMatch(s))
            {
              regMatchCaseList.Add(s);
            }
          }


        }//end of matchCase



        string[] regMatchCaseArr = regMatchCaseList.ToArray();
        /*
        foreach (string s in regMatchCaseArr)//code is in the array here. c~de? is in here
        {
            Console.WriteLine(s);
        }*/


        //string[] matchCaseArray = list.ToArray();
        List<string> regwholeWordlist = new List<string>();

        if (wholeWord == true)
        {

          string patternRegex = "(\\b|^)" + pattern + "(\\b|$)";//need $ for strings at the end. case in point: c~~d?~?
          Regex regexCaseIns = new Regex(patternRegex, RegexOptions.IgnoreCase);//gotta do this because CODE get filtered out if the query is "code"


          foreach (string s in regMatchCaseArr)
          {
            if (regexCaseIns.IsMatch(s))
            {
              regwholeWordlist.Add(s);


            }
          }

          //return array
          string[] regWholeWordListArr = regwholeWordlist.ToArray();
         
          returnStrings = regWholeWordListArr;
          return false;
        }
        else
        {
          //return
          
          returnStrings = regMatchCaseArr;
          return false;
        }//end of wholeWord
      }
      else//regex = false
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
          //string[] matchCasearray = list.ToArray();
        }
        else
        {
          foreach (String s in individualWords)
          {
            if (s.Contains(pattern, System.StringComparison.CurrentCultureIgnoreCase))
            {
              list.Add(s);
            }
          }

        }//end of matchCase

        string[] matchCaseArray = list.ToArray();
        List<string> wholeWordlist = new List<string>();

        if (wholeWord == true)//have to ignore case here
        {
          string patternRegex = "\\b" + pattern + "\\b";
          Regex regexCaseIns = new Regex(patternRegex, RegexOptions.IgnoreCase);

          foreach (string s in matchCaseArray)
          {
            if (regexCaseIns.IsMatch(s))
            {
              wholeWordlist.Add(s);


            }
          }
          //return
          string[] wholeWordListArr = wholeWordlist.ToArray();
        
          returnStrings = wholeWordListArr;
          return false;

        }
        else
        {
          //string[] wholeWordListArr = matchCaseArray;
         

          returnStrings = matchCaseArray;
          return true;
        }

      }
      //return true;//for response
    }

       
       

    [HttpGet("Bleach")]
    public ActionResult<string[]> Get()
    {
      return Ok(returnStrings);
    }
  }
 }

