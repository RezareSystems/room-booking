using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rezare.OpenMeeting.Domain;

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

    /// <summary>
    /// Command handler for a request to list the bookings for a room
    /// </summary>
    public interface IGetBookingsCommand
    {
        /// <summary>
        /// Taking the request provided returns all bookings for that request
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<GetBookingsResponse> GetBookings(GetBookingsRequest request);
    }

    public class GetBookingsCommand : IGetBookingsCommand
    {
        private readonly IRoomBookingQuery _bookingRoomQuery;
        private readonly IRoomBookingConfigurationQuery _roomBookingConfigurationQuery;

        public GetBookingsCommand(
            IRoomBookingQuery bookingRoomQuery,
            IRoomBookingConfigurationQuery roomBookingConfigurationQuery)
        {
            _bookingRoomQuery = bookingRoomQuery;
            _roomBookingConfigurationQuery = roomBookingConfigurationQuery;
        }

        public async Task<GetBookingsResponse> GetBookings(GetBookingsRequest request)
        {
            var bookings = _bookingRoomQuery.GetBookings(new BookingQueryRequest()
            {
                RoomId = new List<string>()
                {
                    request.RoomId
                },
                From = request.BookingDay.GetValueOrDefault(),
                To = request.BookingDay.GetValueOrDefault()
            });

            var roomConfiguration = await _roomBookingConfigurationQuery.GetConfiguration(request.RoomId);

            return new GetBookingsResponse
            {
                RoomName = roomConfiguration?.Name,
                Bookings = bookings.Select(p => new RoomBookingDetails()
                {
                    Organizer = p.Organizer,
                    Title = p.Title,
                    StartTime = p.StartTime,
                    Attendees = p.Attendees,
                    EndTime = p.EndTime
                }).ToList()
            };
        }
    }
}
