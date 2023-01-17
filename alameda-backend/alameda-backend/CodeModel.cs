using System;
namespace alameda_backend
{
  public class CodeModel//follows format of json object we're sending from front end
  {
    public string pattern { get; set; }

    public string homeString { get; set; }

    public bool regexFlag { get; set; }

    public bool matchCaseFlag { get; set; }

    public bool wholeWordFlag { get; set; }
  }
}

