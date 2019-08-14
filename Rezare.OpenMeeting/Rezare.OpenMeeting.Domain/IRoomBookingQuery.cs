using System;
using System.Collections.Generic;

namespace Rezare.OpenMeeting.Domain
{
    /// <summary>
    /// Queries the bookings for the rooms specified
    /// </summary>
    public interface IRoomBookingQuery
    {
        /// <summary>
        /// Returns the list of booking information based on the query parameters
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        List<RoomBooking> GetBookings(BookingQueryRequest request);
    }

    public struct BookingQueryRequest
    {
        public List<string> RoomId { get; set; }

        public DateTime? From { get; set; }

        public DateTime? To { get; set; }
    }

    public struct RoomBooking
    {
        public string Name { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Title { get; set; }

        public List<string> Attendees { get; set; }

        public string Organizer { get; set; }
    }

    public struct RoomConfig
    {
        public string EmailAddress { get; set; }
        public string Password { get; set }
    }

    public struct GraphData
    {

    }
}
