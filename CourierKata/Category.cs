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
            IReadOnlyCollection<Category> Categories = new List<Category>
            {
                new SmallCategory(),
                new MediumCategory(),
                new LargeCategory(),
                new XLCategory(),
            };

            return Categories;
        }

        public virtual bool IsCategorySizeSuitable(double size)
        {
            return size < SizeLimit;
        }
    }
}
