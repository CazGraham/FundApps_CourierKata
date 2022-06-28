namespace CourierKata
{
    public class MediumCategory : Category
    {
        public override string Name => "Medium";
        public override double SizeLimit => 50;
        public override double Price => 8;
        public override double WeightLimitKg => 3;
    }
}
