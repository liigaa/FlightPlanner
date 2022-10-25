using FlightPlanner.Core.Models;
using FlightPlanner.Core.Validation;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlightPlanner.Tests
{
    [TestClass]
    public class RequestValidatorTests
    {
        private readonly IRequestValidator _dateValidator = new DateRequestValidator();
        private readonly IRequestValidator _fromValidator = new FromRequestValidator();
        private readonly IRequestValidator _toValidator = new ToRequestValidator();

        [TestMethod]
        public void RequestDateValidator_IsNotEmptyOrNull_ResultBeTrue()
        {
            // Arrange
            var request = new Request
            {
                DepartureDate = "2022-10-12"
            };

            // Act
            var result = _dateValidator.IsValid(request);

            // Assert
            result.Should().BeTrue();
        }

        [TestMethod]
        [DataRow("")]
        [DataRow(null)]
        public void RequestDateValidator_IsEmptyOrNull_ResultBeFalse(string departure)
        {
            // Arrange
            var request = new Request
            {
                DepartureDate = departure
            };

            // Act
            var result = _dateValidator.IsValid(request);

            // Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        [DataRow("2022-10-36")]
        [DataRow("2022-15-12")]
        public void RequestDateValidator_IsNotEmptyOrNull_InvalidDate_ResultBeFalse(string departure)
        {
            // Arrange
            var request = new Request
            {
                DepartureDate = departure
            };

            // Act
            var result = _dateValidator.IsValid(request);

            // Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void RequestFromValidator_IsNotEmptyOrNull_ResultBeTrue()
        {
            // Arrange
            var request = new Request
            {
                From = "Rix"
            };

            // Act
            var result = _fromValidator.IsValid(request);

            // Assert
            result.Should().BeTrue();
        }

        [TestMethod]
        [DataRow("")]
        [DataRow(null)]
        public void RequestFromValidator_IsEmptyOrNull_ResultBeFalse(string from)
        {
            // Arrange
            var request = new Request
            {
                From = from
            };

            // Act
            var result = _fromValidator.IsValid(request);

            // Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void RequestToValidator_IsNotEmptyOrNull_ResultBeTrue()
        {
            // Arrange
            var request = new Request
            {
                To = "Rix"
            };

            // Act
            var result = _toValidator.IsValid(request);

            // Assert
            result.Should().BeTrue();
        }

        [TestMethod]
        [DataRow("")]
        [DataRow(null)]
        public void RequestToValidator_IsEmptyOrNull_ResultBeFalse(string to)
        {
            // Arrange
            var request = new Request
            {
                To = to
            };

            // Act
            var result = _toValidator.IsValid(request);

            // Assert
            result.Should().BeFalse();
        }
    }
}
