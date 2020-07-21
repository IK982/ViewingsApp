using System.Collections.Generic;
using ViewingsApp.Models.Database;
using ViewingsApp.Models.Request;
using ViewingsApp.Models.ViewModel;

namespace ViewingsApp.Services
{
    public interface IBookingValidator
    {
        BookingValidation ValidateBooking(BookingRequest bookingRequest, IEnumerable<Agent> allAgents, IEnumerable<Property> allProperties);
    }
    
    public class BookingValidator : IBookingValidator
    {

        public bool noName(BookingRequest bookingRequest)
        {
            var name = bookingRequest.Name;
            if(name == "")
            {
                return true;
            }

                return false;
        }

        public bool noEmail(BookingRequest bookingRequest)
        {
            var email = bookingRequest.EmailAddress;
            if (email == "")
            {
                return true;
            }
            return false;
        }

        public BookingValidation ValidateBooking(BookingRequest bookingRequest, IEnumerable<Agent> allAgents, IEnumerable<Property> allProperties)
        {
            if(noName(bookingRequest))
            {

                return new BookingValidation
                {
                    IsValid = false,
                    ErrorMessage = "You must provide a name"
                };
            }
           
           if(noEmail(bookingRequest))
           {

               return new BookingValidation
               {
                   IsValid = false,
                   ErrorMessage = "You must provide an email address"
               };
           }

           return new BookingValidation
           {
               IsValid = true,
               ErrorMessage = ""
           };
        

        }

    }
}