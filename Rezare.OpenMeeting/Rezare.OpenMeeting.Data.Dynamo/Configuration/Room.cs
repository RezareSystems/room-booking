using System;
using System.Collections.Generic;
using System.Text;
using Amazon.DynamoDBv2.DataModel;

namespace Rezare.OpenMeeting.Data.Dynamo.Configuration
{
    [DynamoDBTable("Room")]
    internal class Room
    {
        [DynamoDBHashKey]
        public string RoomId { get; set; }

        public string Name { get; set; }
        
        public string Username { get; set; }
        
        public string Password { get; set; }
    }
}
