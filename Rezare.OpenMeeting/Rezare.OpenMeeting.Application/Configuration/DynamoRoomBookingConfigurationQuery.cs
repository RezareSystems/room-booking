using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Rezare.OpenMeeting.Domain;

namespace Rezare.OpenMeeting.Application.Configuration
{
    internal class DynamoRoomBookingConfigurationQuery : IRoomBookingConfigurationQuery
    {
        public RoomConfiguration GetConfiguration(string roomId)
        {
            // Read a value from dynamo db for the configuration
            var client = new AmazonDynamoDBClient();
            var context = new DynamoDBContext(client);
            var room =  context.LoadAsync<Room>($"{roomId}-azure").GetAwaiter().GetResult();

            return new RoomConfiguration(room.Name);
        }
    }
}
