using System;
using System.Collections.Generic;
using System.Net;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Rezare.OpenMeeting.Application.Configuration;
using Rezare.OpenMeeting.Application.Meetings;
using Rezare.OpenMeeting.Domain;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
namespace Rezare.OpenMeeting.Application
{
    public class Function
    {
        private readonly ILambdaConfiguration _configuration;
        private readonly IGetBookingsCommand _bookingsCommand;

        /// <summary>
        /// Initializes a new instance of the <see cref="Function"/> class.
        /// 
        /// Default constructor. This constructor is used by Lambda to construct the instance. When invoked in a Lambda environment
        /// the AWS credentials will come from the IAM role associated with the function and the AWS region will be set to the
        /// region the Lambda function is executed in.
        /// </summary>
        public Function()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();
            _configuration = serviceProvider.GetService<ILambdaConfiguration>();
            _bookingsCommand = serviceProvider.GetService<IGetBookingsCommand>();
        }

        /// <summary>
        /// Returns the bookings for the specified room based on it's ID
        /// </summary>
        public APIGatewayProxyResponse GetBookings(
            APIGatewayProxyRequest request, 
            ILambdaContext context)
        {
            // RoomId is required
            var roomId = request.QueryStringParameters["RoomId"];

            // Booking day is optional
            request.QueryStringParameters.TryGetValue("BookingDay", out string bookingDayQuery);
            
            var bookings = _bookingsCommand.GetBookings(new GetBookingsRequest()
            {
                RoomId = roomId,
                BookingDay = DateTime.TryParse(bookingDayQuery, out DateTime bookingDay) ? bookingDay : DateTime.Now
            });

            return new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = JsonConvert.SerializeObject(bookings),
                Headers = new Dictionary<string, string>
                { 
                    { "Content-Type", "application/json" }, 
                    { "Access-Control-Allow-Origin", "*" } 
                }
            };;
        }

        /// <summary>
        /// Configure any interfaces and their implementations here
        /// </summary>
        private void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ILambdaConfiguration, LambdaConfiguration>();
            serviceCollection.AddTransient<IGetBookingsCommand, GetBookingsCommand>();
            serviceCollection.AddTransient<IRoomBookingQuery, RoomBookingQuery>();
            serviceCollection.AddTransient<IRoomBookingConfigurationQuery, DynamoRoomBookingConfigurationQuery>();
        }
    }
}