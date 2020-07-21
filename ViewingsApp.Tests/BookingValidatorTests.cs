using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using ViewingsApp.Models.Database;
using ViewingsApp.Models.Request;
using ViewingsApp.Services;

namespace ViewingsApp.Tests
{
    public class Tests
    {
        private readonly List<Agent> _agents = new List<Agent>
        {
            new Agent
            {
                Id = 1,
                Name = "Mike",
                ImageUrl = "/images/person_01.jpg",
                StartTime = 9,
                EndTime = 17,
                Bookings = new List<Booking>(),
            }
        };
        
        private readonly List<Property> _properties = new List<Property>
        {
            new Property
            {
                Id = 3,
                Name = "Flat 1",
                Postcode = "NW5 1TL",
                Bookings = new List<Booking>(),
                ImageUrl = "/images/house_01.jpg"
            }
        };

        [Test]
        public void ValidBookingPassesValidation()
        {
            // Arrange
            var bookingRequest = new BookingRequest
            {
                AgentId  = 1,
                PropertyId = 3,
                Name = "Rebecca",
                EmailAddress = "rebecca@hotmail.com",
                StartsAt = DateTime.Now.AddHours(2),
                EndsAt = DateTime.Now.AddHours(3),
                PhoneNumber = "0300 547 873"
            };
            var bookingValidator = new BookingValidator();

            // Act
            var bookingValidation = bookingValidator.ValidateBooking(bookingRequest, _agents, _properties);

            // Assert
            bookingValidation.IsValid.Should().BeTrue();
            bookingValidation.ErrorMessage.Should().BeEmpty();
        }

        [Test]
        public void ShouldFailIfNameIsMissing()
        {
            // Arrange
            var bookingRequest = new BookingRequest
            {
                AgentId  = 1,
                PropertyId = 3,
                Name = "",
                EmailAddress = "rebecca@hotmail.com",
                StartsAt = DateTime.Now.AddHours(2),
                EndsAt = DateTime.Now.AddHours(3),
                PhoneNumber = "0300 547 873"
            };
            var bookingValidator = new BookingValidator();

            // Act
            var bookingValidation = bookingValidator.ValidateBooking(bookingRequest, _agents, _properties);

            // Assert
            bookingValidation.IsValid.Should().BeFalse();
            bookingValidation.ErrorMessage.Should().Be("You must provide a name");
        }

          [Test]
        public void ShouldFailIfEmailIsMissing()
        {
            // Arrange
            var bookingRequest = new BookingRequest
            {
                AgentId  = 1,
                PropertyId = 3,
                Name = "Rebecca",
                EmailAddress = "",
                StartsAt = DateTime.Now.AddHours(2),
                EndsAt = DateTime.Now.AddHours(3),
                PhoneNumber = "0300 547 873"
            };
            var bookingValidator = new BookingValidator();

            // Act
            var bookingValidation = bookingValidator.ValidateBooking(bookingRequest, _agents, _properties);

            // Assert
            bookingValidation.IsValid.Should().BeFalse();
            bookingValidation.ErrorMessage.Should().Be("You must provide an email address");
        }

             [Test]
        public void ShouldFailIfPhoneNumberIsMissing()
        {
            // Arrange
            var bookingRequest = new BookingRequest
            {
                AgentId  = 1,
                PropertyId = 3,
                Name = "Rebecca",
                EmailAddress = "rebecca@hotmail.com",
                StartsAt = DateTime.Now.AddHours(2),
                EndsAt = DateTime.Now.AddHours(3),
                PhoneNumber = ""
            };
            var bookingValidator = new BookingValidator();

            // Act
            var bookingValidation = bookingValidator.ValidateBooking(bookingRequest, _agents, _properties);

            // Assert
            bookingValidation.IsValid.Should().BeFalse();
            bookingValidation.ErrorMessage.Should().Be("You must provide a phone number");
        }

              [Test]
        public void ShouldFailIfAgentIdIsInvalid()
        {
            // Arrange
            var bookingRequest = new BookingRequest
            {
                AgentId  = 0,
                PropertyId = 3,
                Name = "Rebecca",
                EmailAddress = "rebecca@hotmail.com",
                StartsAt = DateTime.Now.AddHours(2),
                EndsAt = DateTime.Now.AddHours(3),
                PhoneNumber = "0300 547 873"
            };
            var bookingValidator = new BookingValidator();

            // Act
            var bookingValidation = bookingValidator.ValidateBooking(bookingRequest, _agents, _properties);

            // Assert
            bookingValidation.IsValid.Should().BeFalse();
            bookingValidation.ErrorMessage.Should().Be("This is not a valid Agent Id");
        }
    }
}