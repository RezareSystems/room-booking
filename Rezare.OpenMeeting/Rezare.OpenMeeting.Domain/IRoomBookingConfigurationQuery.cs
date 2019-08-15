using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rezare.OpenMeeting.Domain
{
    public interface IRoomBookingConfigurationQuery : IApplicationLogging
    {
        /// <summary>
        /// Returns the configuration for a room
        /// </summary>
        /// <param name="roomId"></param>
        Task<RoomConfiguration> GetConfiguration(string roomId);
    }

    public class RoomConfiguration
    {
        public string Name { get; private set; }

        public string Username { get; private set; }

        public string Password { get; private set; }

        public RoomConfiguration(
            string name,
            string username,
            string password)
        {
            Name = name;
            Username = username;
            Password = password;
        }
    }
}
