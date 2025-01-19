namespace Domain.Entities
{
    internal class Pricing
    {
        public int PricingID { get; set; }
        public string Name { get; set; }

        public List<CarPricing> CarPricings { get; set; }
    }
}
