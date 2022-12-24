using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace alameda_backend
{
  public class Parser
  {
    public Parser(string toSearch, string pattern, bool matchCase, bool wholeWord, string[] individualWords)
    {
      this.toSearch = toSearch;
      this.pattern = pattern;
      this.matchCase = matchCase;
      this.wholeWord = wholeWord;
      this.individualWords = individualWords;
    }
    string toSearch;
    string pattern;
    public string[] returnStrings;
    string[] individualWords;
    bool regex;
    bool matchCase;
    bool wholeWord;

    public void regexTrue()
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
        if (pattern[i] == '~' && ((pattern[i] != '?') && (pattern[i] != '*')))
        {
          pattern = pattern.Remove(i, 1).Insert(i, "\\");
          i++;
        }
        List<string> matchCaseList = regexTrueMatchCase();
        regexTrueWholeWord(matchCaseList);
      }//end of regexTrue
    }

      public void regexFalse()
      {
        List<string> matchCaseList = regexFalseMatchCase();


        regexFalseWholeWord(matchCaseList);
      }

      List<string> regexTrueMatchCase()
      {
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
        }
        return regMatchCaseList;
      }

      void regexTrueWholeWord(List<string> matchCaseList)
      {
        string[] regMatchCaseArr = matchCaseList.ToArray();
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

      List<string> regexFalseMatchCase()
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
            if (s.Contains(pattern,System.StringComparison.CurrentCultureIgnoreCase))
            {
              list.Add(s);
            }
          }
          
        }
        return list;
      }

      void regexFalseWholeWord(List<string> matchCaseList)
      {
        string[] matchCaseArray = matchCaseList.ToArray();
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
        }
      }
    }
  }


