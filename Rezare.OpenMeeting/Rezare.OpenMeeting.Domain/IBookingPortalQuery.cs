using System;
using System.Collections.Generic;
using System.Text;

namespace Rezare.OpenMeeting.Domain
{
    public interface IBookingPortalQuery
    {
        PortalConfiguration GetConfiguration();
    }

    public class PortalConfiguration
    {

    }
}
