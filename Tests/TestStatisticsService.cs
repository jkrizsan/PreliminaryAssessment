using System;
using NUnit.Framework;
using BusinessLogic.Statistics;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture]
    public class TestStatisticsService
    {
        private IStatisticsService _statistService = new StatisticsService();

        [Test]
        public void Test_ParseAndValidateInput_Double_Exception()
        {
            var ex = Assert.Throws<ValidationException>(()
                => _statistService.ParseAndValidateInput("1,2.0,3"));

            Assert.AreEqual("The '2.0' value is invalid!", ex.Message);
        }

        [Test]
        public void Test_ParseAndValidateInput_OK()
        {
            var ret = _statistService.ParseAndValidateInput("1,2,3");

            Assert.IsTrue(ret.Contains(1));
            Assert.IsTrue(ret.Contains(2));
            Assert.IsTrue(ret.Contains(3));
        }

        [Test]
        public void Test_CalcStatistics_OK()
        {
            var ret = _statistService.CalcStatistics(new List<int>() {1, 3, 4, 5, 6, 7, 5});

            Assert.AreEqual(7, ret.Max);
            Assert.AreEqual(1, ret.Min);
            Assert.AreEqual(4.43, Math.Round(ret.Average, 2));
            Assert.AreEqual(1.84, Math.Round(ret.StandardDeviation, 2));
        }
    }
}
