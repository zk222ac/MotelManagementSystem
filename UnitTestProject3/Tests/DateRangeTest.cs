using System;
using BookingSystem.Model;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace UnitTestProject3
{
    [TestClass]
    public class DateRangeTest
    {
        

        [TestMethod]
        public void TestDateRange()
        {
            DateRange testDateRange = new DateRange(DateTime.Today, DateTime.MaxValue);
            Assert.IsTrue(testDateRange.Includes(DateTime.Today));
        }


        
    }
}