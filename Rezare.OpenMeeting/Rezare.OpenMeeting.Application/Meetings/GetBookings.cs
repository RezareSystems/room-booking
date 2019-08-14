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
        public string Name { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Title { get; set; }

        public List<string> Attendees { get; set; }

        public string Organizer { get; set; }
    }
}
