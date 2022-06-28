namespace CourierKata
{
    public class Order
    {
        private const double SpeedyShipmentMultiplier = 2;
        public bool IsSpeedyShipment { get; }
        public IEnumerable<Parcel> Parcels { get; }

        public Order(IEnumerable<Parcel> parcels, bool isSpeedyShipment)
        {
            if (!parcels.Any() || parcels == null)
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

        private double CalculateSpeedyShipping()
        {
            return ParcelCost() * (SpeedyShipmentMultiplier - 1);
        }

        public double ShippingCost()
        {
            return IsSpeedyShipment ? CalculateSpeedyShipping() : 0;
        }

        public double TotalCost()
        {
            return ParcelCost() + ShippingCost();
        }
    }
}

// For task 5 I would look at creating an abstract Discount object which takes the parcel list of an order and applies any relevent rules
// It would would have child classes for each rule that was implemented
// It would need to check which parcels had been used and remove used parcels from the list as each discount is applied before checking for any further discount matches
