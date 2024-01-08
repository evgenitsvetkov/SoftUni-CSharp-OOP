using EDriveRent.Models.Contracts;
using System;

namespace EDriveRent.Models
{
    public class User : IUser
    {
        private string firstName;
        private string lastName;
        private string drivingLicenseNumber;
        private double rating;
        private bool isBlocked;

        public User(string firstName, string lastName, string drivingLicenseNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DrivingLicenseNumber = drivingLicenseNumber;
        }

        public string FirstName
        {
            get => firstName; 
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("FirstName cannot be null or whitespace!");
                }

                firstName = value;
            }
        }

        public string LastName 
        { 
            get => lastName; 
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("LastName cannot be null or whitespace!");
                }

                lastName = value;
            } 
        }
        public string DrivingLicenseNumber
        {
            get => drivingLicenseNumber; 
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Driving license number is required!");
                }

                drivingLicenseNumber = value;
            }
        }
        public double Rating
        {
            get => rating; 
            private set
            {
                rating = value;
            }
        }


        public bool IsBlocked
        {
            get => isBlocked; 
            private set
            {
                isBlocked = value;
            }
        }

        public void DecreaseRating()
        {
            this.Rating -= 2.0;

            if (this.Rating < 0)
            {
                this.Rating = 0;
                this.IsBlocked = true;
            }

        }

        public void IncreaseRating()
        {
            this.Rating += 0.5;

            if (this.Rating > 10)
            {
                this.Rating = 10;
            }
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} Driving license: {DrivingLicenseNumber} Rating: {Rating}";
        }
    }
}
