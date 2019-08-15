using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Rezare.OpenMeeting.Domain;

namespace Rezare.OpenMeeting.Data.Dynamo.Configuration
{
    public class DynamoRoomBookingConfigurationQuery : IRoomBookingConfigurationQuery
    {
        public IApplicationLogger ApplicationLogger { get; set; }

        public DynamoRoomBookingConfigurationQuery()
        {
        }

        public async Task<RoomConfiguration> GetConfiguration(string roomId)
        {
            ApplicationLogger?.LogInformation("GetConfiguration", $"Querying dynamodb for room {roomId}");
            
            // Read a value from dynamo db for the configuration
            var client = new AmazonDynamoDBClient();
            using (var context = new DynamoDBContext(client))
            {
                var room = await context.LoadAsync<Room>($"{roomId}-azure");
                
                return new RoomConfiguration(
                    room.Name,
                    room.Username,
                    room.Password);
            }
        }
    }
}
