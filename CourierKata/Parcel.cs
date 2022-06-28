namespace CourierKata
{
    public class Parcel
    {
        public double Size { get; }
        public Category Category { get; }  

        public Parcel(double size)
        {
            Size = size;

            if (size <= 0)
            {
                throw new ArgumentException("Size is not a valid value.");
            }

            if (size < 10)
            {
                Category = new SmallCategory();
            }
            else if (size < 50)
            {
                Category=new MediumCategory();
            }
            else if (size < 100)
            {
                Category = new LargeCategory();
            }
            else if (size >= 100)
            {
                Category = new XLCategory();
            }
        }
    }
}
