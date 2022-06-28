using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierKata
{
    public class Parcel
    {
        public double Size { get; }
        public double Price { get; }
        public string? CategoryName { get; }

        public Parcel(double size)
        {
            Size = size;

            if (size <= 0)
            {
                throw new ArgumentException("Size is not a valid value.");
            }

            if(size < 10)
            {
                CategoryName = "Small";
                Price = 3;
            }
            else if (size < 50)
            {
                CategoryName = "Medium";
                Price = 8;
            }
            else if (size < 100)
            {
                CategoryName = "Large";
                Price = 15;
            }
            else if (size >= 100)
            {
                CategoryName = "XL";
                Price = 8;
            }
        }
    }
}
