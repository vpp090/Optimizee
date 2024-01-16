

using OptimalPackage.Models;

namespace OptimalPackage.Events
{
    public class CrossrefEvent : IntegrationBaseEvent
    {
        public CrossrefRequest Request { get; set; }
    }
}
