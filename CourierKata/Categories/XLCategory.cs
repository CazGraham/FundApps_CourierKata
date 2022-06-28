namespace CourierKata
{
    public class XLCategory : Category
    {
        public override string Name => "XL";
        public override double SizeLimit => 100;
        public override double Price => 25;

        public override bool IsCategorySizeSuitable(double size)
        {
            return size >= SizeLimit;
        }
    }
}
