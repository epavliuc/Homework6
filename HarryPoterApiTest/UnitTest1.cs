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
            HPI.HarryPApi(ApiConfig.BaseUri, $"characters/5a12292a0f5ae10021650d7e", ApiConfig.ApiKey);
        }



        [Test]
        public void CheckID()
        {
            Assert.AreEqual("5a12292a0f5ae10021650d7e", HPI.HarryPotterRespons["_id"].ToString());
        }

        [Test]
        public void CheckNameHarry()
        {
            Assert.AreEqual("Harry Potter", HPI.HarryPotterRespons["name"].ToString());
        }

    }
}
