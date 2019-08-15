using System;
using System.Collections.Generic;
using System.Text;

namespace Rezare.OpenMeeting.Domain
{
    /// <summary>
    /// Provides logging functionality within implemented classes
    /// </summary>
    public interface IApplicationLogging
    {
        IApplicationLogger ApplicationLogger { get; set; }
    }
}
