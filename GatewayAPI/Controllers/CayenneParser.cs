using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http;

namespace GatewayAPI.Controllers
{
    public partial class ValuesController 
        : ApiController
    {
        public void ParseTempAndSoilCayennePacket(string deveui, string b64data)
        { 
            byte[] asBytes = Convert.FromBase64String(b64data);
            int byteIndex = 0;
            StringBuilder payloadBuilder = new StringBuilder();
            float? temp = null;
            float? moisture = null;

            while(byteIndex < asBytes.Length)
            {
                byte Channel = asBytes[byteIndex];
                byteIndex++;

                byte type = asBytes[byteIndex];
                byteIndex++;

                switch(type)
                {
                    case 2:
                    case 3:
                        var _msb = asBytes[byteIndex];
                        var _lsb = asBytes[byteIndex + 1];
                        short value2 = BitConverter.ToInt16(new byte[] { _lsb, _msb }, 0);
                        byteIndex += 2;
                        moisture = value2 * 0.01f;
                        break;
                    case 103:
                        var msb = asBytes[byteIndex];
                        var lsb = asBytes[byteIndex + 1];
                        short value = BitConverter.ToInt16(new byte[] { lsb, msb }, 0);
                        byteIndex += 2;
                        temp = value * 0.1f;
                        break;                    
                }
            }

            if(temp.HasValue && moisture.HasValue)
                InsertSoilMoistureRecord(deveui, temp.Value, moisture.Value);
        }


        public void ParseRiverCayennePacket(string deveui, string b64data)
        {
            byte[] asBytes = Convert.FromBase64String(b64data);
            int byteIndex = 0;
            StringBuilder payloadBuilder = new StringBuilder();
            float? waterlevel = null;

            while (byteIndex < asBytes.Length)
            {
                byte Channel = asBytes[byteIndex];
                byteIndex++;

                byte type = asBytes[byteIndex];
                byteIndex++;

                switch (type)
                {
                    case 2:
                    case 3:
                        var msb = asBytes[byteIndex];
                        var lsb = asBytes[byteIndex + 1];
                        short value = BitConverter.ToInt16(new byte[] { lsb, msb }, 0);
                        byteIndex += 2;
                        waterlevel = value * 0.01f;
                        break;
                    default:
                        break;
                }
            }

            if (waterlevel.HasValue)
                InsertWaterRecord(deveui, waterlevel.Value);
        }
    }
}