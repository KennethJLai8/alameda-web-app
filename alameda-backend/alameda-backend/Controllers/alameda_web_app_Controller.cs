using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860




namespace alameda_backend.Controllers
{
  public class CodeModel
  {
    public string Code { get; set; }
  }


  [Route("api/[controller]")]
    public class alameda_web_app_Controller : Controller
    {
    public static string returnedstring = "is this still working?";
        // GET: api/values
        /*
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }*/

        // GET api/values/5
        [HttpGet("BleachUpdated")]
        public string GetB()
        {
            return returnedstring;
        }

        // POST api/values
        [HttpPost]
        //[Route("UpdateBleach")]
        public bool GetDetails([FromBody]CodeModel sent)//this should be working
        {
            bool entered = false;
            returnedstring = sent.Code;
            entered = true;
            return entered;
     
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpGet("Bleach")]
        public string Get()
        {
          return "Bleach is Awesome";
        }
      }
    }

