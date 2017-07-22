using BeerBeaconLibrary.Enums;
using BeerBeaconLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BeerBeaconLibraryTests
{
    [TestClass]
    public class BuddyTests
    {
        [TestMethod]
        public void BuddyETA_IsCorrect()
        {
            var buddy = new Buddy
            {
                BeaconId = 1,
                UserId = 1,
                BuddyStatus = BuddyStatus.OnTheWay,
                ETAdrinks = 2
            };
            var datetimeNow = new DateTime(2017, 07, 12, 10, 30, 0);
            var expected = new DateTime(2017, 07, 12, 11, 30, 0);
            var actual = datetimeNow.AddMinutes(buddy.ETAdrinks * 30);
            Assert.AreEqual(expected, actual);
        }
    }
}
