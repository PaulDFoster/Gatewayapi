using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GatewayAPI.Models
{
    public class LoRaMessage
    {
        //{"tmst":2059569556,"time":"2018-06-14T16:11:58.751059Z","chan":3,"rfch":0,"freq":868.8,"stat":1,"modu":"LORA","datr":"SF8BW125","codr":"4/5","lsnr":11.2,"rssi":-33,"opts":"","size":1,"fcnt":47,"cls":0,"port":1,"mhdr":"406e215b00802f00","data":"NQ==","appeui":"11-11-22-22-33-33-44-44","deveui":"00-df-2a-d2-83-ca-52-e7","ack":false,"adr":true,"gweui":"00-80-00-00-00-00-c4-b4","seqn":47}

        public int tmst { get; set; }
        public string time { get; set; }
        public int chan { get; set; }
        public int rfch { get; set; }
        public double freq { get; set; }
        public int stat { get; set; }
        public string modu { get; set; }
        public string datr { get; set; }
        public string codr { get; set; }
        public double lsnr { get; set; }
        public int rssi { get; set; }
        public string opts { get; set; }
        public int size { get; set; }
        public int fcnt { get; set; }
        public int cls { get; set; }
        public int port { get; set; }
        public string mhdr { get; set; }
        public string data { get; set; }
        public string appeui { get; set; }
        public string deveui { get; set; }
        public bool ack { get; set; }
        public bool adr { get; set; }
        public string gweui { get; set; }
        public int seqn { get; set; }
    }

}