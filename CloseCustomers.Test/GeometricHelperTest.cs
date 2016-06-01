using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CloseCustomers.Core;

namespace CloseCustomers.Test
{
    [TestClass]
    public class GeometricHelperTest
    {
        /// <summary>
        /// Margin of error in meters because of the rounding errors 
        /// </summary>
        private const double metersMargin = 250;

        /// <summary>
        /// The approximate distance in meters per degree
        /// </summary>
        private const double distancePerDegree = 111000;

        #region GetDistance Method

        [TestMethod]
        public void NoDistance()
        {
            double p1Lat = 0;
            double p2Lat = 0;
            double p1Long = 0;
            double p2Long = 0;

            var dist = GeometricHelper.GetGeoDistance(p1Lat, p1Long, p2Lat, p2Long);

            Assert.AreEqual(dist, 0);
        }

        [TestMethod]
        public void OneDegreeDistance()
        {
            double p1Lat = -50;
            double p1Long = 10;
            double p2Lat = -49;
            double p2Long = 10;

            var dist = GeometricHelper.GetGeoDistance(p1Lat, p1Long, p2Lat, p2Long);

            Assert.IsTrue(dist - distancePerDegree < metersMargin);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InvalidP1Lat()
        {
            double p1Lat = 110;
            double p1Long = 10;
            double p2Lat = 49;
            double p2Long = 10;

            var dist = GeometricHelper.GetGeoDistance(p1Lat, p1Long, p2Lat, p2Long);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InvalidP2Lat()
        {
            double p1Lat = 50;
            double p1Long = 10;
            double p2Lat = -110;
            double p2Long = 10;

            var dist = GeometricHelper.GetGeoDistance(p1Lat, p1Long, p2Lat, p2Long);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InvalidP1Long()
        {
            double p1Lat = 50;
            double p1Long = -190;
            double p2Lat = 50;
            double p2Long = 10;

            var dist = GeometricHelper.GetGeoDistance(p1Lat, p1Long, p2Lat, p2Long);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InvalidP2Long()
        {
            double p1Lat = 50;
            double p1Long = 10;
            double p2Lat = 50;
            double p2Long = 190;

            var dist = GeometricHelper.GetGeoDistance(p1Lat, p1Long, p2Lat, p2Long);
        }

        #endregion GetDistance Method
    }
}
