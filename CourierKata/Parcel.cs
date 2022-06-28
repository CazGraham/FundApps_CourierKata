namespace CourierKata
{
    public class Parcel
    {
        public double[] Sizes { get; }
        public Category Category { get; }
        public double Weight { get; }

        public Parcel(double[] sizes, double weight)
        {
            if (sizes.Any(s => s <= 0))
            {
                throw new ArgumentException("Size is not a valid value.");
            }

            if (weight <= 0)
            {
                throw new ArgumentException("Weight is not a valid value.");
            }

            var largestSize = sizes.Max();
            var category = PickCategory(largestSize);

            if (category == null)
            {
                throw new ArgumentException("Category is not a valid value.");
            }

            Sizes = sizes;
            Weight = weight;
            Category = category;
        }

        private Category? PickCategory(double size)
        {
            var categories = Category.GetCategories();
            var category = categories.Where(x => x.IsCategorySizeSuitable(size))
                                    .OrderBy(s => s.SizeLimit)
                                    .FirstOrDefault();
            return category;
        }
        public double AdditionalWeightCost()
        {
            var additionalWeight = Math.Ceiling(Weight) - Category.WeightLimitKg;
            return additionalWeight > 0 ? additionalWeight * Category.AdditionalWeightPerKgCost : 0;
        }

        public double TotalCost()
        {
            return Category.Price + AdditionalWeightCost();
        }
    }
}


// Additional tests would be needed for task 4
// PickCategory will need to be changed to take into account weight and overall cost
