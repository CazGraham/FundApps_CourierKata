namespace CourierKata
{
    public class SmallCategory : Category
    {
        public override string Name => "Small";
        public override double SizeLimit => 10;
        public override double Price => 3;
        public override double WeightLimitKg => 1;
    }
}
