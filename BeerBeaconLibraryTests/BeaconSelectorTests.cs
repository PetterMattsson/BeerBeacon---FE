using BeerBeaconLibrary.Enums;
using BeerBeaconLibrary.Helpers;
using BeerBeaconLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BeerBeaconLibraryTests
{
    [TestClass]
    public class BeaconSelectorTests
    {
        [TestMethod]
        public void SelectTest_BeaconTypeIsPresent()
        {
            var type = BeaconType.BeerBeacon;
            var beacon = BeaconSelector.Select(type);
            Assert.AreEqual(beacon.GetType(), typeof(Beacon));
        }
    }
}
