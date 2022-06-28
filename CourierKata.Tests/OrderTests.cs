using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CourierKata.Tests
{
    public class OrderTests
    {
        private static Parcel _smallParcel = new Parcel(new double[] { 1, 1, 1 });
        private static Parcel _mediumParcel = new Parcel(new double[] { 10, 10, 10 });

        private static List<Parcel> _singleParcelList = new List<Parcel> { _smallParcel };
        private static List<Parcel> _multipleParcelList = new List<Parcel> { _smallParcel, _smallParcel, _smallParcel, _mediumParcel, _mediumParcel };

        private static readonly object[] _singleParcelOrderStandardShipping = { new object[] { new Order(_singleParcelList, false), 3 } };
        private static readonly object[] _multipleParcelOrderStandardShipping = { new object[] { new Order(_multipleParcelList, false), 25 } };
        private static readonly object[] _singleParcelOrderSpeedyShipping = { new object[] { new Order(_singleParcelList, true), 6 } };
        private static readonly object[] _multipleParcelOrderSpeedyShipping = { new object[] { new Order(_multipleParcelList, true), 50 } };

        [Test]
        public void CreateOrder_WithSingleParcel_ExpectCorrectParcelList()
        {
            Order order = new Order(_singleParcelList, false);

            Assert.AreEqual(_singleParcelList, order.Parcels);
        }

        [Test]
        public void CreateOrder_WithMultipleParcels_ExpectCorrectParcelList()
        {
            Order order = new Order(_multipleParcelList, false);

            Assert.AreEqual(_multipleParcelList, order.Parcels);
        }

        [Test]
        public void CreateOrder_WhenParcelListIsEmpty_ExpectException()
        {
            var ex = Assert.Throws<ArgumentException>(() => new Order(new List<Parcel> { }, false));
            Assert.AreEqual("Parcel list is empty.", ex?.Message);
        }

        [TestCaseSource(nameof(_singleParcelOrderStandardShipping))]
        public void TotalCost_WithSingleParcelOrderStandardShipping_ExpectCorrectTotal(Order order, double expectedTotal)
        {
            Assert.AreEqual(expectedTotal, order.TotalCost());
        }

        [TestCaseSource(nameof(_multipleParcelOrderStandardShipping))]
        public void TotalCost_WithMultipleParcelOrderStandardShipping_ExpectCorrectTotal(Order order, double expectedTotal)
        {
            Assert.AreEqual(expectedTotal, order.TotalCost());
        }

        [TestCaseSource(nameof(_singleParcelOrderSpeedyShipping))]
        public void TotalCost_WithSingleParcelOrderSpeedyShipping_ExpectCorrectTotal(Order order, double expectedTotal)
        {
            Assert.AreEqual(expectedTotal, order.TotalCost());
        }

        [TestCaseSource(nameof(_multipleParcelOrderSpeedyShipping))]
        public void TotalCost_WithMultipleParcelOrderSpeedyShipping_ExpectCorrectTotal(Order order, double expectedTotal)
        {
            Assert.AreEqual(expectedTotal, order.TotalCost());
        }
    }
}
