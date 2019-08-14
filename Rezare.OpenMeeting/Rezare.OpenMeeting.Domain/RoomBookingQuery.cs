using System;
using System.Collections.Generic;
using System.Text;

namespace Rezare.OpenMeeting.Domain
{
    class RoomBookingQuery : IRoomBookingQuery
    {
        public List<RoomBooking> GetBookings(BookingQueryRequest request)
        {
            // Get data needed to call Graph API
            RoomConfig config = GetRoomConfig(request.RoomId[0]);

            // Call Graph API
            GraphData data = GetRoomData(config, request);

            // Return just what we need from Graph data
            return new List<RoomBooking>
            {
                new RoomBooking
                {
                    Name = "Kakapo Room",
                    StartTime = new DateTime(2019, 8, 12, 10, 0, 0),
                    EndTime = new DateTime(2019, 8, 12, 11, 30, 0),
                    Title = "nProve elaboration",
                    Organizer = "Sailee Patel",
                    Attendees = new List<string>
                    {
                        "Sailee Patel",
                        "Deepika Fernando",
                        "Andre Wilson",
                        "Keenan Tisch",
                        "Gerard deLeon",
                        "John Davys"
                    }
                },
                new RoomBooking
                {
                    Name = "Kakapo Room",
                    StartTime = new DateTime(2019, 8, 12, 13, 0, 0),
                    EndTime = new DateTime(2019, 8, 12, 14, 0, 0),
                    Title = "iTexel retro",
                    Organizer = "Amanda Anderton",
                    Attendees = new List<string>
                    {
                        "Amanda Anderton",
                        "Daniel Buchanan",
                        "Pierre Ip",
                        "Tony Gray",
                    }
                },
                new RoomBooking
                {
                    Name = "Kakapo Room",
                    StartTime = new DateTime(2019, 8, 12, 16, 0, 0),
                    EndTime = new DateTime(2019, 8, 12, 16, 30, 0),
                    Title = "PGF discussion",
                    Organizer = "Anita Nagaraj",
                    Attendees = new List<string>
                    {
                        "Anita Nagaraj",
                        "Jinjin Ma",
                        "Kerry Johns"
                    }
                }
            };
        }

        private RoomConfig GetRoomConfig(string RoomId)
        {
            // TODO: look up from Dynamo DB to get O365 credentials

            return new RoomConfig
            {
                EmailAddress = "kakapo.room@rezare.co.nz",
                Password = "Rezare.99"
            };
        }

        private GraphData GetRoomData(RoomConfig config, BookingQueryRequest request)
        {
            // call Graph API

            return new GraphData { };
        }
    }
}
