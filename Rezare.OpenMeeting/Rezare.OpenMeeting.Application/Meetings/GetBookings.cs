using System;
using System.Collections.Generic;
using System.Text;

namespace Rezare.OpenMeeting.Application.Meetings
{
    public class GetBookingsRequest
    {
        /// <summary>
        /// The room id used to query bookings on
        /// </summary>
        public string RoomId { get; set; }

        /// <summary>
        /// The day of bookings we are interested for. If not set then the current day is assumed
        /// </summary>
        public DateTime? BookingDay { get; set; }
    }

    public class GetBookingsResponse
    {
        public string RoomName { get; set; }

        public List<RoomBookingDetails> Bookings { get; set; }

        public GetBookingsResponse()
        {
            Bookings = new List<RoomBookingDetails>();
        }
    }

    public class RoomBookingDetails
    {
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Title { get; set; }

        public List<string> Attendees { get; set; }

        public string Organizer { get; set; }
    }

    public interface IGetBookingsCommand
    {
        /// <summary>
        /// Taking the request provided returns all bookings for that request
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetBookingsResponse GetBookings(GetBookingsRequest request);
    }

    public class GetBookingsCommand : IGetBookingsCommand
    {
        public GetBookingsResponse GetBookings(GetBookingsRequest request)
        {
            return new GetBookingsResponse()
            {
                RoomName = "Kakapo",
                Bookings = new List<RoomBookingDetails>()
                {
                    new RoomBookingDetails()
                    {
                        Title = "Test",
                        Organizer = "Andre",
                        Attendees = new List<string>()
                        {
                            "Don", "Dean"
                        },
                        StartTime = request.BookingDay ?? DateTime.Now,
                        EndTime = DateTime.Now.AddHours(1)
                    }
                }
            };
        }
    }
}
