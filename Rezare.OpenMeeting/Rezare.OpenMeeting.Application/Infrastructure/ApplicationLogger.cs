using System;
using System.Collections.Generic;
using System.Text;
using Amazon.Lambda.Core;
using Microsoft.Extensions.Logging;
using Rezare.OpenMeeting.Domain;

namespace Rezare.OpenMeeting.Application.Infrastructure
{
    public class ApplicationLogger : IApplicationLogger
    {
        private readonly ILambdaLogger _logger;

        public ApplicationLogger(ILambdaLogger logger)
        {
            _logger = logger;
        }
        public void LogException(string func, string message, Exception ex)
        {
            _logger.LogLine($"{func} :: {message} :: {ex.Message}");
        }

        public void LogInformation(string func, string message)
        {
            _logger.LogLine($"{func} :: {message}");
        }
    }
}
