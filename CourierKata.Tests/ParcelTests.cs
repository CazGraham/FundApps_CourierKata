using NUnit.Framework;

namespace CourierKata.Tests
{
    public class ParcelTests
    {
        [TestCase(1, "Small")]
        [TestCase(9.9, "Small")]
        [TestCase(10,"Medium")]
        [TestCase(49.9, "Medium")]
        [TestCase(50, "Large")]
        [TestCase(99.999, "Large")]
        [TestCase(100, "XL")]
        [TestCase(1000, "XL")]
        public void CreateParcel_WhenDataIsValid_ExpectValidParcelType(double size, string expectedParcelCategory)
        {
            Parcel parcel = new Parcel(size);

            Assert.AreEqual(expectedParcelCategory, parcel.CategoryName);
        }

        [TestCase(0, "Size is not a valid value.")]
        [TestCase(-100, "Size is not a valid value.")]
        public void CreateParcel_WhenDataIsInvalid_ExpectException(double size, string expectedExceptionMessage)
        {
            var ex = Assert.Throws<ArgumentException>(() => new Parcel(size));
            Assert.AreEqual(expectedExceptionMessage, ex?.Message);
        }
    }
}