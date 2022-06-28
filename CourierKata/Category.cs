namespace CourierKata
{
    public abstract class Category
    {
        public abstract string Name { get; }
        public abstract double SizeLimit { get; }
        public abstract double Price { get; }
        public abstract double WeightLimitKg { get; }
        public virtual double AdditionalWeightPerKgCost => 2;

        public static IReadOnlyCollection<Category> GetCategories()
        {
            return new List<Category>
            {
                new SmallCategory(),
                new MediumCategory(),
                new LargeCategory(),
                new XLCategory(),
            };
        }

        public virtual bool IsCategorySizeSuitable(double size)
        {
            return size < SizeLimit;
        }
    }
}

// Additional changes would be needed for task 4
// A new category of HeavyCategory would be needed
// SizeLimit will need to be taken into account when checking if suitable
// Checking if suitable will need to be changed to take into account weight and overall cost
