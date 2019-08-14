using System;
using System.Collections.Generic;
using System.Text;
using Amazon.DynamoDBv2.DataModel;

namespace Rezare.OpenMeeting.Application.Configuration
{
    [DynamoDBTable("Room")]
    class Room
    {
        [DynamoDBHashKey]
        public string RoomId { get; set; }

        public string Name { get; set; }
    }
}
