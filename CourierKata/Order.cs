using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierKata
{
    public class Order
    {
        private const double SpeedyShipmentMultiplier = 2;
        public bool IsSpeedyShipment { get; }
        public IEnumerable<Parcel> Parcels { get; }

        public Order(IEnumerable<Parcel> parcels, bool isSpeedyShipment)
        {
            if (!parcels.Any())
            {
                throw new ArgumentException("Parcel list is empty.");
            }

            Parcels = parcels;
            IsSpeedyShipment = isSpeedyShipment;
        }
        public double ParcelCost()
        {
            return Parcels.Sum(x => x.Category.Price);
        }

        public double ShippingCost()
        {
            return IsSpeedyShipment ? ParcelCost() * (SpeedyShipmentMultiplier - 1) : 0;
        }

        public double TotalCost()
        {
            return ParcelCost() + ShippingCost();
        }
    }
}
