namespace CourierKata
{
    public abstract class Category
    {
        public abstract string Name { get; }
        public abstract double SizeLimit { get; }
        public abstract double Price { get; }
    }
}
