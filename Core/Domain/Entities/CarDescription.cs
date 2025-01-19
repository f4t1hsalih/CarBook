namespace Domain.Entities
{
    internal class CarDescription
    {
        public int CarDescriptionID { get; set; }
        public int CarID { get; set; }
        public string Details { get; set; }

        public Car Car { get; set; }
    }
}
