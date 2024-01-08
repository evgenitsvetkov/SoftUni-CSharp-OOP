namespace EDriveRent.Models
{
    public class PassengerCar : Vehicle
    {
        private const int MaxMilage = 450;

        public PassengerCar(string brand, string model, string licensePlateNumber) 
            : base(brand, model, MaxMilage, licensePlateNumber)
        {
        }
    }
}
