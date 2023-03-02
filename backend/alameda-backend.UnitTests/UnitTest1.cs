namespace alameda_backend.UnitTests;
using alameda_backend;
using Microsoft.Extensions.FileSystemGlobbing.Internal;

/*
 * public Parser(string toSearch, bool matchCase, bool wholeWord, string[] individualWords,
      string[] individualPattern)
 */
[TestClass]
public class ParserTests
{
    [TestMethod]
    public string Post_CorrectString_ExpectEqual()//naming convention: methodWe'reTesting_Scenario_ExpectedBehavior
    {
    //Arrange
    var codeModel = new CodeModel();
    codeModel.pattern = "Blea";
    codeModel.homeString = "Bleach";
    codeModel.regexFlag = false;
    codeModel.matchCaseFlag = false;
    codeModel.wholeWordFlag = false;

    string[] individualWords = codeModel.homeString.Split(' ');
    string[] individualPattern = codeModel.pattern.Split(' ');





  }
}

