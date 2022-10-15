using FlightPlanner.Core.Models;
using FlightPlanner.Core.Validation;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlightPlanner.Tests
{
    [TestClass]
    public class AirportValidatorTests
    {
        private readonly IAirportValidator _airportCityValidator = new AirportCityValidator();
        private readonly IAirportValidator _airportCodeValidator = new AirportCodeValidator();
        private readonly IAirportValidator _airportCountryValidator = new AirportCountryValidator();

        [TestMethod]
        public void AirportCity_IsNotEmptyOrNull_ResultTrue()
        {
            // Arrange
            var airport = new Airport
            {
                City = "Riga"
            };

            // Act
            var result = _airportCityValidator.IsValid(airport);

            // Assert
            result.Should().BeTrue();
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        public void AirportCity_IsEmptyOrNull_ResultFalse(string city)
        {
            // Arrange
            var airport = new Airport
            {
                City = city
            };

            // Act
            var result = _airportCityValidator.IsValid(airport);

            // Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void AirportCode_IsNotEmptyOrNull_ResultTrue()
        {
            // Arrange
            var airport = new Airport
            {
                AirportCode = "RIX"
            };

            // Act
            var result = _airportCodeValidator.IsValid(airport);

            // Assert
            result.Should().BeTrue();
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        public void AirportCode_IsEmptyOrNull_ResultFalse(string code)
        {
            // Arrange
            var airport = new Airport
            {
                AirportCode = code
            };

            // Act
            var result = _airportCodeValidator.IsValid(airport);

            // Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void AirportCountry_IsNotEmptyOrNull_ResultTrue()
        {
            // Arrange
            var airport = new Airport
            {
                Country = "Latvia"
            };

            // Act
            var result = _airportCountryValidator.IsValid(airport);

            // Assert
            result.Should().BeTrue();
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        public void AirportCountry_IsEmptyOrNull_ResultFalse(string country)
        {
            // Arrange
            var airport = new Airport
            {
                Country = country
            };

            // Act
            var result = _airportCountryValidator.IsValid(airport);

            // Assert
            result.Should().BeFalse();
        }
    }
}
