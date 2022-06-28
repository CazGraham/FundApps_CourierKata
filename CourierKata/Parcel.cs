namespace CourierKata
{
    public class Parcel
    {
        public double[] Sizes { get; }
        public Category Category { get; }
        public double Weight { get; private set; }

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

        public Category? PickCategory(double size)
        {
            var categories = Category.GetCategories();
            var category = categories.Where(x => x.IsCategorySizeSuitable(size))
                                    .OrderBy(s => s.SizeLimit)
                                    .FirstOrDefault();
            return category;
        }
    }
}
