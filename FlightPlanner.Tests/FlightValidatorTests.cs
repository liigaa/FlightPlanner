using FlightPlanner.Core.Models;
using FlightPlanner.Core.Validation;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlightPlanner.Tests
{
    [TestClass]
    public class FlightValidatorTests
    {
        private readonly IFlightValidator _carrierValidator = new CarrierValidator();
        private readonly IFlightValidator _flightAirportValidator = new FlightAirportValidator();
        private readonly IFlightValidator _flightTimeValidator = new FlightTimeValidator();

        [TestMethod]
        public void CarrierValidator_IsNotEmptyOrNull_ResultBeTrue()
        {
            // Arrange
            var flight = new Flight
            {
                Carrier = "Air Baltic"
            };

            // Act
            var result = _carrierValidator.IsValid(flight);

            // Assert
            result.Should().BeTrue();

        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        public void CarrierValidator_IsEmptyOrNull_ResultBeFalse(string carrier)
        {
            // Arrange
            var flight = new Flight
            {
                Carrier = carrier
            };

            // Act
            var result = _carrierValidator.IsValid(flight);

            // Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void AirportValidator_IsNotNullAndFromAndToAreNotEqual_ResultBeTrue()
        {
            // Arrange
            var flight = new Flight
            {
                From = new Airport
                {
                    AirportCode = "Rix"
                },
                To = new Airport
                {
                    AirportCode = "OSL"
                }
            };

            // Act
            var result = _flightAirportValidator.IsValid(flight);

            // Assert
            result.Should().BeTrue();
        }

        [TestMethod]
        [DataRow("Rix  ", " rix")]
        [DataRow("  rix", "RIX  ")]
        public void AirportValidator_IsNotNullAndFromAndToAreEqual_ResultBeFalse(string fromCode, string toCode)
        {
            // Arrange
            var flight = new Flight
            {
                From = new Airport
                {
                    AirportCode = fromCode
                },
                To = new Airport
                {
                    AirportCode = toCode
                }
            };

            // Act
            var result = _flightAirportValidator.IsValid(flight);

            // Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void AirportValidator_AirportFromIsNull_ResultBeFalse()
        {
            // Arrange
            var flight = new Flight
            {
                From = null,
                To = new Airport()
            };

            // Act
            var result = _flightAirportValidator.IsValid(flight);

            // Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void AirportValidator_AirportToIsNull_ResultBeFalse()
        {
            // Arrange
            var flight = new Flight
            {
                From = new Airport(),
                To = null
            };

            // Act
            var result = _flightAirportValidator.IsValid(flight);

            // Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void AirportValidator_AirportIsNull_ResultBeFalse()
        {
            // Arrange
            var flight = new Flight
            {
                From = null,
                To = null
            };

            // Act
            var result = _flightAirportValidator.IsValid(flight);

            // Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void FlightTimeValidator_IsNotEmptyOrNull_ArrivalTimeAfterDepartureTime_ResultBeTrue()
        {
            // Arrange
            var flight = new Flight
            {
                DepartureTime = "2022-10-15 20:00",
                ArrivalTime = "2022-10-15 23:30"
            };

            // Act
            var result = _flightTimeValidator.IsValid(flight);

            // Assert
            result.Should().BeTrue();
        }

        [TestMethod]
        [DataRow("2022-10-15", "2022-10-15 25:30")]
        [DataRow("2022-10-15 20:00", "2022-10-15 18:00")]
        [DataRow("2022-15-12 20:00", "2022-10-12 23:00")]
        public void FlightTimeValidator_IsNotEmptyOrNull_InvalidDate_ResultBeFalse(string departure, string arrival)
        {
            // Arrange
            var flight = new Flight
            {
                DepartureTime = departure,
                ArrivalTime = arrival
            };

            // Act
            var result = _flightTimeValidator.IsValid(flight);

            // Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        [DataRow("", null)]
        [DataRow(null, "")]
        [DataRow("", "")]
        [DataRow(null, null)]
        public void FlightTimeValidator_IsEmptyOrNull_ResultBeFalse(string departure, string arrival)
        {
            // Arrange
            var flight = new Flight
            {
                DepartureTime = departure,
                ArrivalTime = arrival
            };

            // Act
            var result = _flightTimeValidator.IsValid(flight);

            // Assert
            result.Should().BeFalse();
        }
    }
}
