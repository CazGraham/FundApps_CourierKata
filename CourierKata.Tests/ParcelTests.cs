using NUnit.Framework;
using System;

namespace CourierKata.Tests
{
    public class ParcelTests
    {
        [TestCase(new double[] { 1, 1, 1 }, "Small")]
        [TestCase(new double[] { 9.9, 9.9, 9.9 }, "Small")]
        [TestCase(new double[] { 10, 10, 10 }, "Medium")]
        [TestCase(new double[] { 49.9, 49.9, 49.9 }, "Medium")]
        [TestCase(new double[] { 50, 50, 50 }, "Large")]
        [TestCase(new double[] { 99.999, 99.999, 99.999 }, "Large")]
        [TestCase(new double[] { 100, 100, 100 }, "XL")]
        [TestCase(new double[] { 1000, 1000, 1000 }, "XL")]
        public void CreateParcel_WhenDataIsValid_ExpectValidParcelType(double[] sizes, string expectedParcelCategory)
        {
            Parcel parcel = new Parcel(sizes);

            Assert.AreEqual(expectedParcelCategory, parcel.Category.Name);
        }

        [TestCase(new double[] { 0, 0, 0 }, "Size is not a valid value.")]
        [TestCase(new double[] { -3, -6, -100 }, "Size is not a valid value.")]
        public void CreateParcel_WhenDataIsInvalid_ExpectException(double[] sizes, string expectedExceptionMessage)
        {
            var ex = Assert.Throws<ArgumentException>(() => new Parcel(sizes));
            Assert.AreEqual(expectedExceptionMessage, ex?.Message);
        }
    }
}