using System;
using System.Device.Location;

namespace CloseCustomers.Core
{
    public static class GeometricHelper
    {
        private const double earthRadio = 6371000;

        /// <summary>
        /// Returns the distance between the coordinates of two points based no the Wikipedia formula
        /// </summary>
        /// <param name="p1Lat"></param>
        /// <param name="p1Long"></param>
        /// <param name="p2Lat"></param>
        /// <param name="p2Long"></param>
        /// <returns></returns>
        public static double GetGeoDistance(double p1Lat, double p1Long, double p2Lat, double p2Long)
        {
            if (p1Lat < -90 || p1Lat > 90 || p2Lat < -90 || p2Lat > 90)
                throw new ArgumentOutOfRangeException("Latitud", "Latitud must be between -90 and 90");

            if (p1Long < -180 || p1Long > 180 || p2Long < -180 || p2Long > 180)
                throw new ArgumentOutOfRangeException("Longitud", "Longitud must be between -180 and 180");

            double deltaLong =  p2Long - p1Long;

            double radDist = Math.Acos(
                Math.Sin(DegreesToRadians(p1Lat)) * Math.Sin(DegreesToRadians(p2Lat)) +
                Math.Cos(DegreesToRadians(p1Lat)) * Math.Cos(DegreesToRadians(p2Lat)) * Math.Cos(DegreesToRadians(deltaLong)) );

            return earthRadio * radDist;
        }

        /// <summary>
        /// Returns the distance between the coordinates of two points using the .Net Framework
        /// </summary>
        /// <param name="p1Lat"></param>
        /// <param name="p1Long"></param>
        /// <param name="p2Lat"></param>
        /// <param name="p2Long"></param>
        /// <returns></returns>
        public static double GetGeoDistanceFW(double p1Lat, double p1Long, double p2Lat, double p2Long)
        {
            var point1 = new GeoCoordinate(p1Lat, p1Long);
            var point2 = new GeoCoordinate(p2Lat, p2Long);

            return point1.GetDistanceTo(point2);
        }

        private static double DegreesToRadians(double degree)
        {
            return (degree * Math.PI / 180.0);
        }

        private static double RadiansToDegrees(double radians)
        {
            return (radians / Math.PI * 180.0);
        }
    }
}
