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
        public void AirportCity_ShouldNotBeEmpty_ResultTrue()
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
        public void AirportCity_ShouldNotBeEmpty_ResultFalse()
        {
            // Arrange
            var airport = new Airport
            {
                City = ""
            };

            // Act
            var result = _airportCityValidator.IsValid(airport);

            // Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void AirportCode_ShouldNotBeEmpty_ResultTrue()
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
        public void AirportCode_ShouldNotBeEmpty_ResultFalse()
        {
            // Arrange
            var airport = new Airport
            {
                AirportCode = ""
            };

            // Act
            var result = _airportCodeValidator.IsValid(airport);

            // Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void AirportCountry_ShouldNotBeEmpty_ResultTrue()
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
        public void AirportCountry_ShouldNotBeEmpty_ResultFalse()
        {
            // Arrange
            var airport = new Airport
            {
                Country = ""
            };

            // Act
            var result = _airportCountryValidator.IsValid(airport);

            // Assert
            result.Should().BeFalse();
        }
    }
}
