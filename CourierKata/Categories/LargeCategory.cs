namespace CourierKata
{
    public class LargeCategory : Category
    {
        public override string Name => "Large";
        public override double SizeLimit => 100;
        public override double Price => 15;
        public override double WeightLimitKg => 6;
    }
}
