using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.Extensions.FileSystemGlobbing.Internal;

namespace alameda_backend
{
  public class Parser
  {

    public string[]? returnStrings;//return to user

    string? homeString;
    string? pattern;
    bool regex;
    bool matchCase;
    bool wholeWord;
    string[] individualWords;
    string[] individualPattern;

    public Parser(CodeModel sent)
    {
      this.homeString = sent.homeString;
      this.pattern = sent.pattern;
      this.regex = sent.regexFlag;
      this.matchCase = sent.matchCaseFlag;
      this.wholeWord = sent.wholeWordFlag;
    }

    public void homeStringIsNullOrEmpty()//string parameter
    {
      if (string.IsNullOrEmpty(homeString))
      {
        string[] empty = { " " };
        individualWords = empty;
      }
      else
      {
        individualWords = homeString.Split(' ');

      }
    }

    public void patternIsNullOrEmpty()//string
    {
      if (string.IsNullOrEmpty(pattern))
      {
        string[] empty = { " " };
        individualPattern = empty;
      }
      else
      {
        individualPattern = pattern.Split(' ');

      }
    }

    public void regexFunctionSelector()
    {
      if (regex == true)//regex flag determines which regex method we enter
      {
        regexTrue();
        //returnStrings = parser.returnStrings;
      }
      else
      {
        regexFalse();
        //returnStrings = parser.returnStrings;
      }
    }


    public void regexTrue()
    {
      for(int i = 0; i < individualPattern.Length; i++)
      {
        for (int j = 0; j < individualPattern[i].Length; j++)
        {
          if (individualPattern[i][j] == '?')
          {
            individualPattern[i] = individualPattern[i].Remove(j, 1).Insert(j, ".");
          }
          if (individualPattern[i][j] == '*')
          {
            individualPattern[i] = individualPattern[i].Remove(j, 1).Insert(j, ".*");
            i++;
          }
          if (individualPattern[i][j] == '~' && ((individualPattern[i][j] != '?') && (individualPattern[i][j] != '*')))
          {
            individualPattern[i] = individualPattern[i].Remove(j, 1).Insert(j, "\\");
            i++;
          }
          List<string> matchCaseList = regexTrueMatchCase();
          regexTrueWholeWord(matchCaseList);
        }//end of regexTrue
      }
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
          for (int i = 0; i < individualPattern.Length; i++)
          {
            foreach (String s in individualWords)
            {
              if (Regex.IsMatch(s, individualPattern[i]))
              {
                regMatchCaseList.Add(s);
              }
            }
          }
        }
        else
        {
        //array of Regex

         Regex[] rArray;
         List<Regex> rList = new List<Regex>();

        for (int i = 0; i < individualPattern.Length; i++)
        {
          Regex regexCaseIns = new Regex(individualPattern[i], RegexOptions.IgnoreCase);
          rList.Add(regexCaseIns);
        }
        rArray = rList.ToArray();

        for(int i = 0; i < rArray.Length; i++)
          foreach (String s in individualWords)
          {
            if (rArray[i].IsMatch(s))
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

        Regex[] rArray;
        List<Regex> rList = new List<Regex>();

        for (int i = 0; i < individualPattern.Length; i++)
        {
          string patternRegex = "(\\b|^)" + individualPattern[i] + "(\\b|$)";
          Regex regexCaseIns = new Regex(patternRegex, RegexOptions.IgnoreCase);
          rList.Add(regexCaseIns);
        }
        rArray = rList.ToArray();


        for (int i = 0; i < rArray.Length; i++)
        {
          foreach (string s in regMatchCaseArr)
          {
            if (rArray[i].IsMatch(s))
            {
              regwholeWordlist.Add(s);
            }
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
        for (int i = 0; i < individualPattern.Length; i++)
        {
          foreach (String s in individualWords)
          {
            if (s.Contains(individualPattern[i]))
            {
              list.Add(s);
            }
          }
        }
        }
        else
        {
          for (int i = 0; i < individualPattern.Length; i++)
          {
            foreach (String s in individualWords)
            {
              if (s.Contains(individualPattern[i], System.StringComparison.CurrentCultureIgnoreCase))
              {
                list.Add(s);
              }
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

        Regex[] rArray;
        List<Regex> rList = new List<Regex>();

        for (int i = 0; i < individualPattern.Length; i++)
        {
          string patternRegex = "(\\b|^)" + individualPattern[i] + "(\\b|$)";
          Regex regexCaseIns = new Regex(patternRegex, RegexOptions.IgnoreCase);
          rList.Add(regexCaseIns);
        }
        rArray = rList.ToArray();


        for (int i = 0; i < rArray.Length; i++)
        {
          foreach (string s in matchCaseArray)
          {
            if (rList[i].IsMatch(s))
            {
              wholeWordlist.Add(s);
            }
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


