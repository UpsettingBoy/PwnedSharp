using Microsoft.VisualStudio.TestTools.UnitTesting;
using PwnedSharp.Models.HaveIBeenPwned;
using PwnedSharp.Providers.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace PwnedSharpTest.Providers
{
    [TestClass]
    public class HaveIBeenPwnedTest
    {
        private HaveIBeenPwned _service;

        [TestInitialize]
        public void InitilizeService()
        {
            _service = new HaveIBeenPwned("TestPwned");
        }

        [TestMethod]
        public void Test_Pwned_Password()
        {
            //I don't know why, but people still using this super-secure password.
            Assert.IsTrue(_service.CheckPwnedPassword("password").Result);
        }

        [TestMethod]
        public void Test_Pwned_GetBreach()
        {
            var data = _service.GetBreachFromSite("Adobe").Result;

            Assert.IsNotNull(data);
            Assert.AreEqual(data.Name, "Adobe");

            //Test cast to HIBPBreach

            var cast = data as HIBPBreach;

            Assert.IsNotNull(cast);

            Assert.IsTrue(cast.IsVerified);
        }

        [TestMethod]
        public void Test_Pwned_GetAllBreaches()
        {
            var data = _service.GetAllBreaches().Result;

            Assert.IsNotNull(data);
            Assert.IsTrue(data.Count > 1);

            foreach (var breach in data)
            {
                Assert.IsNotNull(breach);
            }
        }

        [TestMethod]
        public void Test_Pwned_GetBreachesOfAccount()
        {
            //Test email for HaveIBeenPwned API
            var data = _service.GetBreaches("test@example.com").Result;

            Assert.IsNotNull(data);
            Assert.IsTrue(data.Count > 0);

            foreach (var breach in data)
            {
                Assert.IsNotNull(breach);
            }
        }
    }
}
