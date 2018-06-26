using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GatewayAPI.Models;

namespace GatewayAPI.Controllers
{
    public partial class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]LoRaMessage value)
        {
            System.Diagnostics.Debug.WriteLine(value.data);

            switch(value.deveui)
            {
                case "00:9D:5D:65:B2:3C:03:CF":
                    ParseTempAndSoilCayennePacket(value.deveui, value.data);
                    break;
                case "00:0F:B0:DE:9F:0B:E3:92"://still need second dev eui
                    ParseRiverCayennePacket(value.deveui, value.data);
                    break;
                case "paulfoeui":
                    ParseFosterPacket(value.deveui, value.data);
                    break;
                default:
                    InsertRecord(value.deveui, value.data);
                    break;
            }

        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
