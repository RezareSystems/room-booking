using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Rezare.OpenMeeting.Application
{
    public interface ILambdaConfiguration
    {
        IConfiguration Configuration { get; }
    }

    public class LambdaConfiguration : ILambdaConfiguration
    {
        public IConfiguration Configuration  => new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
    }
}
