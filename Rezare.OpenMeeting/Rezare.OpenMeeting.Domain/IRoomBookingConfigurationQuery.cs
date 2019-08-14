using System;
using System.Collections.Generic;
using System.Text;

namespace Rezare.OpenMeeting.Domain
{
    public interface IRoomBookingConfigurationQuery
    {
        /// <summary>
        /// Returns the configuration for a room
        /// </summary>
        /// <param name="roomId"></param>
        RoomConfiguration GetConfiguration(string roomId);
    }

    public class RoomConfiguration
    {
        public string Name { get; private set; }
    }
}
