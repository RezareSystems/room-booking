using System;
using System.Collections.Generic;
using System.Text;

namespace Rezare.OpenMeeting.Domain
{
    public interface IApplicationLogger
    {
        void LogException(string func, string message, Exception ex);

        void LogInformation(string func, string message);
    }
}
