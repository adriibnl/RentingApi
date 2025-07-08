using System;
using System.Text.RegularExpressions;
using GtMotive.Estimate.Microservice.Domain.Exceptions;
using MongoDB.Bson.Serialization.Attributes;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
    /// <summary>
    /// Vehicle entity representing a vehicle in the system.
    /// </summary>
    public partial class Vehicle : IVehicle
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Vehicle"/> class.
        /// </summary>
        /// <param name="licensePlate">The license plate of the vehicle.</param>
        /// <param name="brand">The brand of the vehicle.</param>
        /// <param name="model">The model of the vehicle.</param>
        /// <param name="manufacturingYear">The manufacturing year of the vehicle.</param>
        public Vehicle(string licensePlate, string brand, string model, int manufacturingYear)
        {
            Id = Guid.NewGuid();
            LicensePlate = ValidateLicensePlate(licensePlate);
            Brand = ValidateBrand(brand);
            Model = ValidateModel(model);
            ManufacturingYear = ValidateManufacturingYear(manufacturingYear);
            Status = VehicleStatus.Available;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vehicle"/> class for MongoDB.
        /// </summary>
        /// <param name="id">The vehicle identifier.</param>
        /// <param name="licensePlate">The license plate of the vehicle.</param>
        /// <param name="brand">The brand of the vehicle.</param>
        /// <param name="model">The model of the vehicle.</param>
        /// <param name="manufacturingYear">The manufacturing year of the vehicle.</param>
        /// <param name="status">The status of the vehicle.</param>
        [BsonConstructor]
        public Vehicle(Guid id, string licensePlate, string brand, string model, int manufacturingYear, VehicleStatus status)
        {
            Id = id;
            LicensePlate = ValidateLicensePlate(licensePlate);
            Brand = ValidateBrand(brand);
            Model = ValidateModel(model);
            ManufacturingYear = ValidateManufacturingYear(manufacturingYear);
            Status = status;
        }

        /// <summary>
        /// Gets the vehicle identifier.
        /// </summary>
        [BsonId]
        public Guid Id { get; }

        /// <summary>
        /// Gets the license plate of the vehicle.
        /// </summary>
        [BsonElement("licensePlate")]
        public string LicensePlate { get; }

        /// <summary>
        /// Gets the brand of the vehicle.
        /// </summary>
        [BsonElement("brand")]
        public string Brand { get; }

        /// <summary>
        /// Gets the model of the vehicle.
        /// </summary>
        [BsonElement("model")]
        public string Model { get; }

        /// <summary>
        /// Gets the manufacturing year of the vehicle.
        /// </summary>
        [BsonElement("manufacturingYear")]
        public int ManufacturingYear { get; }

        /// <summary>
        /// Gets the status of the vehicle.
        /// </summary>
        [BsonElement("status")]
        public VehicleStatus Status { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the vehicle is available.
        /// </summary>
        public bool IsAvailable => Status == VehicleStatus.Available;

        /// <summary>
        /// Gets a value indicating whether the vehicle is rented.
        /// </summary>
        public bool IsRented => Status == VehicleStatus.Rented;

        /// <summary>
        /// Rents the vehicle.
        /// </summary>
        public void Rent()
        {
            if (!IsAvailable)
            {
                throw new VehicleNotAvailableException($"Vehicle {Id} is not available for rent.");
            }

            Status = VehicleStatus.Rented;
        }

        /// <summary>
        /// Returns the vehicle.
        /// </summary>
        public void ReturnVehicle()
        {
            if (!IsRented)
            {
                throw new VehicleNotRentedException($"Vehicle {Id} is not currently rented.");
            }

            Status = VehicleStatus.Available;
        }

        /// <summary>
        /// Checks if the vehicle is older than five years.
        /// </summary>
        /// <returns>True if the vehicle is older than five years; otherwise, false.</returns>
        public bool IsOlderThanFiveYears()
        {
            var currentYear = DateTime.UtcNow.Year;
            return currentYear - ManufacturingYear > 5;
        }

        /// <summary>
        /// Validates the license plate format.
        /// </summary>
        /// <param name="licensePlate">The license plate to validate.</param>
        /// <returns>The validated license plate.</returns>
        private static string ValidateLicensePlate(string licensePlate)
        {
            if (string.IsNullOrWhiteSpace(licensePlate))
            {
                throw new LicensePlateShouldNotBeEmptyException("License plate cannot be empty.");
            }

            var regex = LicensePlateRegex();
            return !regex.IsMatch(licensePlate)
                ? throw new InvalidLicensePlateFormatException($"License plate {licensePlate} has invalid format. Expected format: 1234ABC")
                : licensePlate;
        }

        /// <summary>
        /// Gets the license plate regex pattern.
        /// </summary>
        /// <returns>The license plate regex pattern.</returns>
        [GeneratedRegex(@"^[0-9]{4}[A-Z]{3}$")]
        private static partial Regex LicensePlateRegex();

        /// <summary>
        /// Validates the brand format.
        /// </summary>
        /// <param name="brand">The brand to validate.</param>
        /// <returns>The validated brand.</returns>
        private static string ValidateBrand(string brand)
        {
            if (string.IsNullOrWhiteSpace(brand))
            {
                throw new BrandShouldNotBeEmptyException("Brand cannot be empty.");
            }

            if (brand.Length > 50)
            {
                throw new BrandTooLongException("Brand cannot be longer than 50 characters.");
            }

            return brand.Trim();
        }

        /// <summary>
        /// Validates the model format.
        /// </summary>
        /// <param name="model">The model to validate.</param>
        /// <returns>The validated model.</returns>
        private static string ValidateModel(string model)
        {
            if (string.IsNullOrWhiteSpace(model))
            {
                throw new ModelShouldNotBeEmptyException("Model cannot be empty.");
            }

            if (model.Length > 50)
            {
                throw new ModelTooLongException("Model cannot be longer than 50 characters.");
            }

            return model.Trim();
        }

        /// <summary>
        /// Validates the manufacturing year.
        /// </summary>
        /// <param name="manufacturingYear">The manufacturing year to validate.</param>
        /// <returns>The validated manufacturing year.</returns>
        private static int ValidateManufacturingYear(int manufacturingYear)
        {
            var currentYear = DateTime.UtcNow.Year;
            return manufacturingYear < 1900 || manufacturingYear > currentYear
                ? throw new InvalidYearException($"Year {manufacturingYear} is invalid. Must be between 1900 and {currentYear}.")
                : manufacturingYear;
        }
    }
}
