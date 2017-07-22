using BeerBeaconLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BeerBeaconLibraryTests
{
    [TestClass]
    public class BeerBeaconTests
    {
        [TestMethod]
        public void BeerBeaconEndTimeIsCorrect()
        {
            var beacon = new Beacon()
            {
                BeaconId = 1,
                UserId = 1,
                DrinkCounter = 3,
                StartTime = new DateTime(2017, 9, 2, 9, 0, 0),
                Latitude = 12.14123M,
                Longitude = 132.12412M
            };
            var end = new DateTime(2017, 9, 2, 10, 30, 0);
            Assert.AreEqual(end, beacon.EndTime);
        }

        [TestMethod]
        public void BeerBeaconDurationIsCorrect()
        {
            var beacon = new Beacon()
            {
                BeaconId = 1,
                UserId = 1,
                DrinkCounter = 3,
                StartTime = new DateTime(2017, 9, 2, 9, 0, 0),
                Latitude = 12.14123M,
                Longitude = 132.12412M
            };
            var span = new TimeSpan(1, 30, 0);
            Assert.AreEqual(span, beacon.Duration);
        }
    }
}
