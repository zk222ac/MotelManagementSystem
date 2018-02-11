using System;
using BookingSystem.Model;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace UnitTestProject3
{
    [TestClass]
    public class ReservatioTest
    {
        Reservation testReservation = new Reservation();

        [TestMethod]
        public void TestFullName()
        {
            testReservation.FullName = "Full Name";
            Assert.AreEqual(testReservation.FullName, "Full Name");
        }

        [TestMethod]
        public void TestEmail()
        {
            testReservation.Email = "audrius@gmail.com";
            Assert.AreEqual(testReservation.Email, "audrius@gmail.com");
        }

        [TestMethod]
        public void TestPhone()
        {
            testReservation.TelephoneNumber = "0123456789";
            Assert.AreEqual(testReservation.TelephoneNumber, "0123456789");
        }

        [TestMethod]
        public void TestCard()
        {
            testReservation.CardNumber = 1012345678912345;
            Assert.AreEqual(testReservation.CardNumber, 1012345678912345);
        }

        [TestMethod]
        public void TestMonth()
        {
            testReservation.ExpirationMonth = 12;
            Assert.AreEqual(testReservation.ExpirationMonth, 12);
        }

        [TestMethod]
        public void TestYear()
        {
            testReservation.ExpirationYear = 17;
            Assert.AreEqual(testReservation.ExpirationYear, 17);
        }

        [TestMethod]
        public void TestCVV()
        {
            testReservation.Cvv = 222;
            Assert.AreEqual(testReservation.Cvv, 222);
        }
    }
}