namespace EDriveRent.Models
{
    public class CargoVan : Vehicle
    {
        public const int MaxMilage = 180;

        public CargoVan(string brand, string model, string licensePlateNumber) 
            : base(brand, model, MaxMilage, licensePlateNumber)
        {
        }
    }
}
