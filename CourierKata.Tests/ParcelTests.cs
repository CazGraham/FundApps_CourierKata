using NUnit.Framework;
using System;

namespace CourierKata.Tests
{
    public class ParcelTests
    {
        [TestCase(new double[] { 1, 1, 1 }, 0.5, "Small")]
        [TestCase(new double[] { 9.9, 9.9, 9.9 }, 1, "Small")]
        [TestCase(new double[] { 10, 10, 10 }, 1.1, "Medium")]
        [TestCase(new double[] { 49.9, 49.9, 49.9 }, 3, "Medium")]
        [TestCase(new double[] { 50, 50, 50 }, 3.01, "Large")]
        [TestCase(new double[] { 99.999, 99.999, 99.999 }, 6, "Large")]
        [TestCase(new double[] { 100, 100, 100 }, 6.1, "XL")]
        [TestCase(new double[] { 1000, 1000, 1000 }, 10, "XL")]
        public void CreateParcel_WhenDataIsValid_ExpectValidParcelType(double[] sizes, double weight, string expectedParcelCategory)
        {
            Parcel parcel = new Parcel(sizes, weight);

            Assert.AreEqual(expectedParcelCategory, parcel.Category.Name);
        }

        [TestCase(new double[] { 0, 0, 0 }, 1, "Size is not a valid value.")]
        [TestCase(new double[] { -3, -6, -100 }, 1, "Size is not a valid value.")]
        [TestCase(new double[] { 1, 1, 1 }, 0, "Weight is not a valid value.")]
        [TestCase(new double[] { 3, 6, 100 }, -100, "Weight is not a valid value.")]
        public void CreateParcel_WhenDataIsInvalid_ExpectException(double[] sizes, double weight, string expectedExceptionMessage)
        {
            var ex = Assert.Throws<ArgumentException>(() => new Parcel(sizes, weight));
            Assert.AreEqual(expectedExceptionMessage, ex?.Message);
        }

        [TestCase(new double[] { 1, 1, 1 }, 5, 8)]
        [TestCase(new double[] { 9.9, 9.9, 9.9 }, 2, 2)]
        [TestCase(new double[] { 10, 10, 10 }, 5, 4)]
        [TestCase(new double[] { 49.9, 49.9, 49.9 }, 3.5, 2)]
        [TestCase(new double[] { 50, 50, 50 }, 6.01, 2)]
        [TestCase(new double[] { 99.999, 99.999, 99.999 }, 16, 20)]
        [TestCase(new double[] { 100, 100, 100 }, 40, 60)]
        [TestCase(new double[] { 1000, 1000, 1000 }, 100, 180)]
        public void AdditionalWeightCost_WhenDataIsValid_ExpectCorrectCost(double[] sizes, double weight, double expectedCost)
        {
            Parcel parcel = new Parcel(sizes, weight);

            Assert.AreEqual(expectedCost, parcel.AdditionalWeightCost());
        }

        [TestCase(new double[] { 1, 1, 1 }, 5, 11)]
        [TestCase(new double[] { 10, 10, 10 }, 5, 12)]
        [TestCase(new double[] { 50, 50, 50 }, 6.01, 17)]
        [TestCase(new double[] { 100, 100, 100 }, 40, 85)]
        public void TotalCost_WhenDataIsValid_ExpectCorrectCost(double[] sizes, double weight, double expectedCost)
        {
            Parcel parcel = new Parcel(sizes, weight);

            Assert.AreEqual(expectedCost, parcel.TotalCost());
        }
    }
}