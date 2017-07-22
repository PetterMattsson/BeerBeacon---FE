using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BeerBeaconLibrary.Models;
using BeerBeaconLibrary.Helpers;
using System.Collections.Generic;

namespace BeerBeaconLibraryTests
{
    [TestClass]
    public class ValidatorTests
    {
        [TestMethod]
        public void ValidateTest_BeaconIsValid()
        {
            var beacon = new Beacon()
            {
                BeaconId = 1,
                UserId = 1,
                DrinkCounter = 3,
                StartTime = new DateTime(2017, 9, 2),
                Latitude = 12.14123M,
                Longitude = 132.12412M
            };
            var result = Validator.Validate(beacon);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidateTest_DrinksIsZeroOrLess()
        {
            var drinks = 0;
            var drinks2 = -1;
            var result2 = Validator.Validate(drinks2);
            var result = Validator.Validate(drinks);
            Assert.IsFalse(result);
            Assert.IsFalse(result2);
        }

        [TestMethod]
        public void ValidateLatitudeTest_Validate_Fails()
        {
            var latitude1 = 91.12314;
            var latitude2 = -94.14141;
            var result1 = Validator.ValidateLatitude(latitude1);
            var result2 = Validator.ValidateLatitude(latitude2);
            Assert.IsFalse(result1);
            Assert.IsFalse(result2);
        }

        [TestMethod]
        public void ValidateLatitudeTest_Validate_Succeeds()
        {
            var latitude1 = 4.12314;
            var latitude2 = -89.14141;
            var result1 = Validator.ValidateLatitude(latitude1);
            var result2 = Validator.ValidateLatitude(latitude2);
            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
        }

        [TestMethod]
        public void ValidateLongitudeTest_Validate_Fails()
        {
            var longitude1 = 181.74171;
            var longitude2 = -190.87471;
            var result1 = Validator.ValidateLongitude(longitude1);
            var result2 = Validator.ValidateLongitude(longitude2);
            Assert.IsFalse(result1);
            Assert.IsFalse(result2);
        }

        [TestMethod]
        public void ValidateLongitudeTest_Validate_Succeeds()
        {
            var longitude1 = 179.74171;
            var longitude2 = -2.87471;
            var result1 = Validator.ValidateLongitude(longitude1);
            var result2 = Validator.ValidateLongitude(longitude2);
            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
        }

        [TestMethod]
        public void ValidateUserTest_Validate_Succeeds()
        {
            var user = new User
            {
                UserId = 1,
                UserName = "Nille",
                FaceBookId = "83819147419",
                InstagramId = null,
                Email = null,
                Beacons = new List<Beacon>()
            };
            Assert.IsTrue(Validator.Validate(user));
        }

        [TestMethod]
        public void ValidateUserTest_Validate_Fails()
        {
            var user = new User
            {
                UserId = -1,
                UserName = "Nille",
                FaceBookId = "83819147419",
                InstagramId = null,
                Email = null,
                Beacons = new List<Beacon>()
            };
            Assert.IsFalse(Validator.Validate(user));
        }
    }
}

