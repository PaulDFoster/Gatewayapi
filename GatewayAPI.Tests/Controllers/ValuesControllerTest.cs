using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GatewayAPI;
using GatewayAPI.Controllers;

namespace GatewayAPI.Tests.Controllers
{
    [TestClass]
    public class ValuesControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            IEnumerable<string> result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("value1", result.ElementAt(0));
            Assert.AreEqual("value2", result.ElementAt(1));
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            string result = controller.Get(5);

            // Assert
            Assert.AreEqual("value", result);
        }

        [TestMethod]
        public void Post()
        {
            // Arrange
            ValuesController controller = new ValuesController();
            GatewayAPI.Models.LoRaMessage lm = new Models.LoRaMessage();
            lm.chan = 5;
            lm.codr = "4/5";
            lm.datr = "SF7BW125";
            lm.deveui = "00:11:22:33:44:55:66:88";
            lm.freq = 903.3;
            lm.lsnr = 85;
            lm.modu = "LORA";
            lm.data = "Hi World";
            lm.rfch = 1;
            lm.rssi = -55;
            lm.size = 12;
            lm.time = "2018-06-14T16:11:58.751059Z";
            lm.tmst = 67346764;

            // Act
            controller.Post(lm);
            // Assert
        }

        [TestMethod]
        public void Put()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            controller.Put(5, "value");

            // Assert
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            controller.Delete(5);

            // Assert
        }
    }
}
