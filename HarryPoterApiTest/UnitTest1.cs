using System;
using HarryPotterApi;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace HarryPoterApiTest
{
    [TestFixture]
    public class HarryPotterApiTest
    {
        HarryPotterP HPI = new HarryPotterP();
        
        public HarryPotterApiTest()
        {
            //get Harry Potter details
            HPI.HarryPApiSingle("characters/5a12292a0f5ae10021650d7e");
            HPI.HarryPApiArray("characters");
        }

        [Test]
        public void CheckID()
        {
            Assert.AreEqual("5a12292a0f5ae10021650d7e", HPI.HarryPotterResponsSingle["_id"].ToString());
        }

        [Test]
        public void CheckNameHarry()
        {
            Assert.AreEqual("Harry Potter", HPI.HarryPotterResponsSingle["name"].ToString());
        }

        [Test]
        public void CheckNameInArray()
        {
            Assert.AreEqual("Hannah Abbott",HPI.HarryPotterResponsArray[0]["name"].ToString());
        }

        [Test]
        public void CheckStatus()
        {
            Assert.AreEqual("OK", HPI.Response.StatusCode.ToString());
        }

        [Test]
        public void CheckHeaderServer()
        {
            Assert.AreEqual("Server=cloudflare", HPI.Response.Headers[14].ToString());
        }

        [Test]
        public void CheckHeaderWhatPowersServer()
        {
            Assert.AreEqual("X-Powered-By=Express", HPI.Response.Headers[16].ToString());
        }

        [Test]
        public void CheckHeaderContentType()
        {
            Assert.AreEqual("Content-Type=application/json; charset=utf-8", HPI.Response.Headers[10].ToString());
        }

        [Test]
        public void CheckHeaderCount()
        {
            Assert.AreEqual(17, HPI.Response.Headers.Count);
        }

    }
}
