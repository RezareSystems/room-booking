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
        List<RoomBooking> GetBookings(BookingQueryRequet request);
    }

    public struct BookingQueryRequet
    {
        public List<string> RoomId { get; set; }

        public DateTime? From { get; set; }

        public DateTime? to { get; set; }
    }

    public class RoomBooking
    {
        public string Name { get; private set; }
    }
}
