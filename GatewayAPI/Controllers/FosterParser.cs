using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace GatewayAPI.Controllers
{

    public partial class ValuesController
        : ApiController
    {

        public void ParseFosterPacket(string deveui, string data)
        {
            var bytes = Convert.FromBase64String(data);
            //for negative and positive celsius degree
            var t = ((bytes[0] & 0x80) != 0 ? 0xFFFF << 16 : 0) | bytes[0] << 8 | bytes[1];
            var h = bytes[2];
            var p = bytes[3] << 8 | bytes[4];

            float temp = t / 100;
            float humid = h;
            float pressure = p / 10;

            InsertFosterRecord(deveui, temp, humid, pressure);
        }
    }
}